﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Rock.Address.Geocode
{
    /// <summary>
    /// The EZ-Locate geocoding service from <a href="http://www.geocode.com/">Tele Atlas</a>
    /// </summary>
    [Description( "Address Geocoding service from Tele Atlas (EZ-Locate)" )]
    [Export( typeof( GeocodeComponent ) )]
    [ExportMetadata( "ComponentName", "TelaAtlas" )]
    [Rock.Attribute.Property( 1, "User Name", "Security", "The Tele Atlas User Name", true, "" )]
    [Rock.Attribute.Property( 2, "Password", "Security", "The Tele Atlas Password", true, "" )]
    [Rock.Attribute.Property( 2, "EZ-Locate Service", "EZLocateService", "Service", "The EZ-Locate Service to use (default: USA_Geo_002)", true, "USA_Geo_002" )]
    public class TelaAtlas : GeocodeComponent
    {
        /// <summary>
        /// Geocodes the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="result">The result.</param>
        /// <returns>
        /// True/False value of whether the address was standardized was succesfully
        /// </returns>
        public override bool Geocode( Rock.CRM.Address address, out string result )
        {
            if ( address != null )
            {
                var aptc = new Rock.TeleAtlas.Authentication.AuthenticationPortTypeClient();

                int encryptedId;
                int rc = aptc.requestChallenge( AttributeValues["UserName"].Value, 0, out encryptedId );
                if ( rc == 0)
                {
                    int key = elfHash(AttributeValues["Password"].Value);
				    int unencryptedChallenge = encryptedId ^ key;
				    int permutedChallenge = permute(unencryptedChallenge);
				    int response = permutedChallenge ^ key;

                    int cred;

                    rc = aptc.answerChallenge( response, encryptedId, out cred );
                    if (rc == 0 )
                    {
                        var addressParts = new Rock.TeleAtlas.Geocoding.NameValue[5];
                        addressParts[0] = NameValue( "Addr", string.Format( "{0} {1}", address.Street1, address.Street2 ) );
                        addressParts[1] = NameValue( "City", address.City );
                        addressParts[2] = NameValue( "State", address.State );
                        addressParts[3] = NameValue( "ZIP", address.Zip );
                        addressParts[4] = NameValue( "Plus4", string.Empty );

                        var gptc = new Rock.TeleAtlas.Geocoding.GeocodingPortTypeClient();

                        Rock.TeleAtlas.Geocoding.Geocode returnedGeocode;
                        rc = gptc.findAddress( AttributeValues["EZLocateService"].Value, addressParts, cred, out returnedGeocode );
                        if ( rc == 0 )
                        {
                            if ( returnedGeocode.resultCode == 0 )
                            {
                                Rock.TeleAtlas.Geocoding.NameValue matchType = null;
                                Rock.TeleAtlas.Geocoding.NameValue latitude = null;
                                Rock.TeleAtlas.Geocoding.NameValue longitude = null;

                                foreach ( var attribute in returnedGeocode.mAttributes )
                                    switch ( attribute.name )
                                    {
                                        case "MAT_TYPE":
                                            matchType = attribute;
                                            break;
                                        case "MAT_LAT":
                                            latitude = attribute;
                                            break;
                                        case "MAT_LONG":
                                            longitude = attribute;
                                            break;
                                    }

                                if ( matchType != null )
                                {
                                    result = matchType.value;

                                    if ( matchType.value == "1" )
                                    {
                                        address.Latitude = double.Parse( latitude.value );
                                        address.Longitude = double.Parse( longitude.value );

                                        return true;
                                    }
                                }
                                else
                                    result = "No Match";
                            }
                            else
                                result = string.Format( "No Match (requestChallenge result: {0})", rc );
                        }
                        else
                            result = string.Format( "No Match (geocode result: {0})", rc );
                    }
                    else
                        result = string.Format( "Could not authenticate (answerChallenge result: {0})", rc );
                }
                else
                    result = string.Format( "Could not authenticate (findAddress result: {0})", rc );
            }
            else
                result = "Null Address";

            return false;
        }

        private int elfHash( string foo )
        {
            long result;
            result = 0;
            CharEnumerator ce = foo.GetEnumerator();
            while ( ce.MoveNext() )
            {

                result = ( result << 4 ) + ce.Current;
                long x = result & 0xf0000000;
                if ( x != 0 )
                {
                    result = result ^ ( x >> 24 );
                    result = result & ( ~x );
                }
            }

            return ( int )result;
        }

        private int permute( int inputValue )
        {
            long result = inputValue;
            result *= 39371;
            return ( int )( result % 0x3fffffff );
        }

        private int makeKey( string account )
        {
            return elfHash( account ) % 0x3fffffff;
        }

        private Rock.TeleAtlas.Geocoding.NameValue NameValue( string name, string value )
        {
            var nameValue = new Rock.TeleAtlas.Geocoding.NameValue();
            nameValue.name = name;
            nameValue.value = value;

            return nameValue;
        }
    }
}