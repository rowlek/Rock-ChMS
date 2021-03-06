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
	/// Page POCO Service Layer class
	/// </summary>
    public partial class PageService : Service<Rock.CMS.Page>
    {
		/// <summary>
		/// Gets Pages by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>An enumerable list of Page objects.</returns>
	    public IEnumerable<Rock.CMS.Page> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid ).OrderBy( t => t.Order );
        }
		
		/// <summary>
		/// Gets Pages by Parent Page Id
		/// </summary>
		/// <param name="parentPageId">Parent Page Id.</param>
		/// <returns>An enumerable list of Page objects.</returns>
	    public IEnumerable<Rock.CMS.Page> GetByParentPageId( int? parentPageId )
        {
            return Repository.Find( t => ( t.ParentPageId == parentPageId || ( parentPageId == null && t.ParentPageId == null ) ) ).OrderBy( t => t.Order );
        }
		
    }
}
