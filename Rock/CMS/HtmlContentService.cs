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
using System;
using System.Collections.Generic;
using System.Linq;

using Rock.Data;

namespace Rock.CMS
{
	/// <summary>
	/// Html Content POCO Service Layer class
	/// </summary>
    public partial class HtmlContentService : Service<Rock.CMS.HtmlContent>
    {
		/// <summary>
		/// Gets Html Content by Block Id And Entity Value And Version
		/// </summary>
		/// <param name="blockId">Block Id.</param>
		/// <param name="entityValue">Entity Value.</param>
		/// <param name="version">Version.</param>
		/// <returns>HtmlContent object.</returns>
	    public Rock.CMS.HtmlContent GetByBlockIdAndEntityValueAndVersion( int blockId, string entityValue, int version )
        {
            return Repository.FirstOrDefault( t => t.BlockId == blockId && ( t.EntityValue == entityValue || ( entityValue == null && t.EntityValue == null ) ) && t.Version == version );
        }
		
    }
}
