//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System.ServiceModel;

namespace Rock.REST.CMS
{
	/// <summary>
	/// Represents a REST WCF service for Sites
	/// </summary>
	[ServiceContract]
    public partial interface ISiteService
    {
		/// <summary>
		/// Gets a Site object
		/// </summary>
		[OperationContract]
        Rock.CMS.DTO.Site Get( string id );

		/// <summary>
		/// Gets a Site object
		/// </summary>
		[OperationContract]
        Rock.CMS.DTO.Site ApiGet( string id, string apiKey );

		/// <summary>
		/// Updates a Site object
		/// </summary>
        [OperationContract]
        void UpdateSite( string id, Rock.CMS.DTO.Site Site );

		/// <summary>
		/// Updates a Site object
		/// </summary>
        [OperationContract]
        void ApiUpdateSite( string id, string apiKey, Rock.CMS.DTO.Site Site );

		/// <summary>
		/// Creates a new Site object
		/// </summary>
        [OperationContract]
        void CreateSite( Rock.CMS.DTO.Site Site );

		/// <summary>
		/// Creates a new Site object
		/// </summary>
        [OperationContract]
        void ApiCreateSite( string apiKey, Rock.CMS.DTO.Site Site );

		/// <summary>
		/// Deletes a Site object
		/// </summary>
        [OperationContract]
        void DeleteSite( string id );

		/// <summary>
		/// Deletes a Site object
		/// </summary>
        [OperationContract]
        void ApiDeleteSite( string id, string apiKey );
    }
}
