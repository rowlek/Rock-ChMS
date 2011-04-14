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
using System.Text;

using Rock.Models.Cms;
using Rock.Repository.Cms;

namespace Rock.Services.Cms
{
    public partial class SiteDomainService : Rock.Services.Service
    {
        private ISiteDomainRepository _repository;

        public SiteDomainService()
			: this( new EntitySiteDomainRepository() )
        { }

        public SiteDomainService( ISiteDomainRepository SiteDomainRepository )
        {
            _repository = SiteDomainRepository;
        }

        public IQueryable<Rock.Models.Cms.SiteDomain> Queryable()
        {
            return _repository.AsQueryable();
        }

        public Rock.Models.Cms.SiteDomain GetSiteDomain( int id )
        {
            return _repository.FirstOrDefault( t => t.Id == id );
        }
		
        public SiteDomain GetSiteDomainByDomain( string domain )
        {
            return _repository.FirstOrDefault( t => t.Domain == domain );
        }
		
        public IEnumerable<Rock.Models.Cms.SiteDomain> GetSiteDomainsByGuid( Guid guid )
        {
            return _repository.Find( t => t.Guid == guid );
        }
		
        public IEnumerable<Rock.Models.Cms.SiteDomain> GetSiteDomainsBySiteIdAndDomain( int siteId, string domain )
        {
            return _repository.Find( t => t.SiteId == siteId && t.Domain == domain );
        }
		
        public void AddSiteDomain( Rock.Models.Cms.SiteDomain SiteDomain )
        {
            if ( SiteDomain.Guid == Guid.Empty )
                SiteDomain.Guid = Guid.NewGuid();

            _repository.Add( SiteDomain );
        }

        public void DeleteSiteDomain( Rock.Models.Cms.SiteDomain SiteDomain )
        {
            _repository.Delete( SiteDomain );
        }

        public void Save( Rock.Models.Cms.SiteDomain SiteDomain, int? personId )
        {
            List<Rock.Models.Core.EntityChange> entityChanges = _repository.Save( SiteDomain, personId );

			if ( entityChanges != null )
            {
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();

                foreach ( Rock.Models.Core.EntityChange entityChange in entityChanges )
                {
                    entityChange.EntityId = SiteDomain.Id;
                    entityChangeService.AddEntityChange ( entityChange );
                    entityChangeService.Save( entityChange, personId );
                }
            }
        }
    }
}