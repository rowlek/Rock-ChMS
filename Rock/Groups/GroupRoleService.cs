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

namespace Rock.Groups
{
	/// <summary>
	/// Group Role POCO Service Layer class
	/// </summary>
    public partial class GroupRoleService : Service<Rock.Groups.GroupRole>
    {
		/// <summary>
		/// Gets Group Roles by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>An enumerable list of GroupRole objects.</returns>
	    public IEnumerable<Rock.Groups.GroupRole> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid );
        }
		
		/// <summary>
		/// Gets Group Roles by Order
		/// </summary>
		/// <param name="order">Order.</param>
		/// <returns>An enumerable list of GroupRole objects.</returns>
	    public IEnumerable<Rock.Groups.GroupRole> GetByOrder( int? order )
        {
            return Repository.Find( t => ( t.Order == order || ( order == null && t.Order == null ) ) );
        }
		
    }
}
