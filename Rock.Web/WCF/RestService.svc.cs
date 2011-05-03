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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Rock.Web.WCF
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestService : IRestService
    {
		#region Auth
		
        public Rock.Models.Cms.Auth GetAuthJson( string id )
        {
            return GetAuth( id );
        }

        public Rock.Models.Cms.Auth GetAuthXml( string id )
        {
            return GetAuth( id );
        }

        private Rock.Models.Cms.Auth GetAuth( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.AuthService authService = new Rock.Services.Cms.AuthService();
                Rock.Models.Cms.Auth auth = authService.GetAuth( int.Parse( id ) );
                if ( auth.Authorized( "View", currentUser ) )
                    return auth;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Block
		
        public Rock.Models.Cms.Block GetBlockJson( string id )
        {
            return GetBlock( id );
        }

        public Rock.Models.Cms.Block GetBlockXml( string id )
        {
            return GetBlock( id );
        }

        private Rock.Models.Cms.Block GetBlock( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlockService blockService = new Rock.Services.Cms.BlockService();
                Rock.Models.Cms.Block block = blockService.GetBlock( int.Parse( id ) );
                if ( block.Authorized( "View", currentUser ) )
                    return block;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region BlockInstance
		
        public Rock.Models.Cms.BlockInstance GetBlockInstanceJson( string id )
        {
            return GetBlockInstance( id );
        }

        public Rock.Models.Cms.BlockInstance GetBlockInstanceXml( string id )
        {
            return GetBlockInstance( id );
        }

        private Rock.Models.Cms.BlockInstance GetBlockInstance( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlockInstanceService blockInstanceService = new Rock.Services.Cms.BlockInstanceService();
                Rock.Models.Cms.BlockInstance blockInstance = blockInstanceService.GetBlockInstance( int.Parse( id ) );
                if ( blockInstance.Authorized( "View", currentUser ) )
                    return blockInstance;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Blog
		
        public Rock.Models.Cms.Blog GetBlogJson( string id )
        {
            return GetBlog( id );
        }

        public Rock.Models.Cms.Blog GetBlogXml( string id )
        {
            return GetBlog( id );
        }

        private Rock.Models.Cms.Blog GetBlog( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlogService blogService = new Rock.Services.Cms.BlogService();
                Rock.Models.Cms.Blog blog = blogService.GetBlog( int.Parse( id ) );
                if ( blog.Authorized( "View", currentUser ) )
                    return blog;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region BlogCategory
		
        public Rock.Models.Cms.BlogCategory GetBlogCategoryJson( string id )
        {
            return GetBlogCategory( id );
        }

        public Rock.Models.Cms.BlogCategory GetBlogCategoryXml( string id )
        {
            return GetBlogCategory( id );
        }

        private Rock.Models.Cms.BlogCategory GetBlogCategory( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlogCategoryService blogCategoryService = new Rock.Services.Cms.BlogCategoryService();
                Rock.Models.Cms.BlogCategory blogCategory = blogCategoryService.GetBlogCategory( int.Parse( id ) );
                if ( blogCategory.Authorized( "View", currentUser ) )
                    return blogCategory;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region BlogPost
		
        public Rock.Models.Cms.BlogPost GetBlogPostJson( string id )
        {
            return GetBlogPost( id );
        }

        public Rock.Models.Cms.BlogPost GetBlogPostXml( string id )
        {
            return GetBlogPost( id );
        }

        private Rock.Models.Cms.BlogPost GetBlogPost( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlogPostService blogPostService = new Rock.Services.Cms.BlogPostService();
                Rock.Models.Cms.BlogPost blogPost = blogPostService.GetBlogPost( int.Parse( id ) );
                if ( blogPost.Authorized( "View", currentUser ) )
                    return blogPost;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region BlogPostComment
		
        public Rock.Models.Cms.BlogPostComment GetBlogPostCommentJson( string id )
        {
            return GetBlogPostComment( id );
        }

        public Rock.Models.Cms.BlogPostComment GetBlogPostCommentXml( string id )
        {
            return GetBlogPostComment( id );
        }

        private Rock.Models.Cms.BlogPostComment GetBlogPostComment( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlogPostCommentService blogPostCommentService = new Rock.Services.Cms.BlogPostCommentService();
                Rock.Models.Cms.BlogPostComment blogPostComment = blogPostCommentService.GetBlogPostComment( int.Parse( id ) );
                if ( blogPostComment.Authorized( "View", currentUser ) )
                    return blogPostComment;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region BlogTag
		
        public Rock.Models.Cms.BlogTag GetBlogTagJson( string id )
        {
            return GetBlogTag( id );
        }

        public Rock.Models.Cms.BlogTag GetBlogTagXml( string id )
        {
            return GetBlogTag( id );
        }

        private Rock.Models.Cms.BlogTag GetBlogTag( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.BlogTagService blogTagService = new Rock.Services.Cms.BlogTagService();
                Rock.Models.Cms.BlogTag blogTag = blogTagService.GetBlogTag( int.Parse( id ) );
                if ( blogTag.Authorized( "View", currentUser ) )
                    return blogTag;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region HtmlContent
		
        public Rock.Models.Cms.HtmlContent GetHtmlContentJson( string id )
        {
            return GetHtmlContent( id );
        }

        public Rock.Models.Cms.HtmlContent GetHtmlContentXml( string id )
        {
            return GetHtmlContent( id );
        }

        private Rock.Models.Cms.HtmlContent GetHtmlContent( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.HtmlContentService htmlContentService = new Rock.Services.Cms.HtmlContentService();
                Rock.Models.Cms.HtmlContent htmlContent = htmlContentService.GetHtmlContent( int.Parse( id ) );
                if ( htmlContent.Authorized( "View", currentUser ) )
                    return htmlContent;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Page
		
        public Rock.Models.Cms.Page GetPageJson( string id )
        {
            return GetPage( id );
        }

        public Rock.Models.Cms.Page GetPageXml( string id )
        {
            return GetPage( id );
        }

        private Rock.Models.Cms.Page GetPage( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.PageService pageService = new Rock.Services.Cms.PageService();
                Rock.Models.Cms.Page page = pageService.GetPage( int.Parse( id ) );
                if ( page.Authorized( "View", currentUser ) )
                    return page;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region PageRoute
		
        public Rock.Models.Cms.PageRoute GetPageRouteJson( string id )
        {
            return GetPageRoute( id );
        }

        public Rock.Models.Cms.PageRoute GetPageRouteXml( string id )
        {
            return GetPageRoute( id );
        }

        private Rock.Models.Cms.PageRoute GetPageRoute( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.PageRouteService pageRouteService = new Rock.Services.Cms.PageRouteService();
                Rock.Models.Cms.PageRoute pageRoute = pageRouteService.GetPageRoute( int.Parse( id ) );
                if ( pageRoute.Authorized( "View", currentUser ) )
                    return pageRoute;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Role
		
        public Rock.Models.Cms.Role GetRoleJson( string id )
        {
            return GetRole( id );
        }

        public Rock.Models.Cms.Role GetRoleXml( string id )
        {
            return GetRole( id );
        }

        private Rock.Models.Cms.Role GetRole( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.RoleService roleService = new Rock.Services.Cms.RoleService();
                Rock.Models.Cms.Role role = roleService.GetRole( int.Parse( id ) );
                if ( role.Authorized( "View", currentUser ) )
                    return role;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Site
		
        public Rock.Models.Cms.Site GetSiteJson( string id )
        {
            return GetSite( id );
        }

        public Rock.Models.Cms.Site GetSiteXml( string id )
        {
            return GetSite( id );
        }

        private Rock.Models.Cms.Site GetSite( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.SiteService siteService = new Rock.Services.Cms.SiteService();
                Rock.Models.Cms.Site site = siteService.GetSite( int.Parse( id ) );
                if ( site.Authorized( "View", currentUser ) )
                    return site;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region SiteDomain
		
        public Rock.Models.Cms.SiteDomain GetSiteDomainJson( string id )
        {
            return GetSiteDomain( id );
        }

        public Rock.Models.Cms.SiteDomain GetSiteDomainXml( string id )
        {
            return GetSiteDomain( id );
        }

        private Rock.Models.Cms.SiteDomain GetSiteDomain( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.SiteDomainService siteDomainService = new Rock.Services.Cms.SiteDomainService();
                Rock.Models.Cms.SiteDomain siteDomain = siteDomainService.GetSiteDomain( int.Parse( id ) );
                if ( siteDomain.Authorized( "View", currentUser ) )
                    return siteDomain;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region User
		
        public Rock.Models.Cms.User GetUserJson( string id )
        {
            return GetUser( id );
        }

        public Rock.Models.Cms.User GetUserXml( string id )
        {
            return GetUser( id );
        }

        private Rock.Models.Cms.User GetUser( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Cms.UserService userService = new Rock.Services.Cms.UserService();
                Rock.Models.Cms.User user = userService.GetUser( int.Parse( id ) );
                if ( user.Authorized( "View", currentUser ) )
                    return user;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Attribute
		
        public Rock.Models.Core.Attribute GetAttributeJson( string id )
        {
            return GetAttribute( id );
        }

        public Rock.Models.Core.Attribute GetAttributeXml( string id )
        {
            return GetAttribute( id );
        }

        private Rock.Models.Core.Attribute GetAttribute( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.AttributeService attributeService = new Rock.Services.Core.AttributeService();
                Rock.Models.Core.Attribute attribute = attributeService.GetAttribute( int.Parse( id ) );
                if ( attribute.Authorized( "View", currentUser ) )
                    return attribute;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region AttributeQualifier
		
        public Rock.Models.Core.AttributeQualifier GetAttributeQualifierJson( string id )
        {
            return GetAttributeQualifier( id );
        }

        public Rock.Models.Core.AttributeQualifier GetAttributeQualifierXml( string id )
        {
            return GetAttributeQualifier( id );
        }

        private Rock.Models.Core.AttributeQualifier GetAttributeQualifier( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.AttributeQualifierService attributeQualifierService = new Rock.Services.Core.AttributeQualifierService();
                Rock.Models.Core.AttributeQualifier attributeQualifier = attributeQualifierService.GetAttributeQualifier( int.Parse( id ) );
                if ( attributeQualifier.Authorized( "View", currentUser ) )
                    return attributeQualifier;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region AttributeValue
		
        public Rock.Models.Core.AttributeValue GetAttributeValueJson( string id )
        {
            return GetAttributeValue( id );
        }

        public Rock.Models.Core.AttributeValue GetAttributeValueXml( string id )
        {
            return GetAttributeValue( id );
        }

        private Rock.Models.Core.AttributeValue GetAttributeValue( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.AttributeValueService attributeValueService = new Rock.Services.Core.AttributeValueService();
                Rock.Models.Core.AttributeValue attributeValue = attributeValueService.GetAttributeValue( int.Parse( id ) );
                if ( attributeValue.Authorized( "View", currentUser ) )
                    return attributeValue;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region DefinedType
		
        public Rock.Models.Core.DefinedType GetDefinedTypeJson( string id )
        {
            return GetDefinedType( id );
        }

        public Rock.Models.Core.DefinedType GetDefinedTypeXml( string id )
        {
            return GetDefinedType( id );
        }

        private Rock.Models.Core.DefinedType GetDefinedType( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.DefinedTypeService definedTypeService = new Rock.Services.Core.DefinedTypeService();
                Rock.Models.Core.DefinedType definedType = definedTypeService.GetDefinedType( int.Parse( id ) );
                if ( definedType.Authorized( "View", currentUser ) )
                    return definedType;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region DefinedValue
		
        public Rock.Models.Core.DefinedValue GetDefinedValueJson( string id )
        {
            return GetDefinedValue( id );
        }

        public Rock.Models.Core.DefinedValue GetDefinedValueXml( string id )
        {
            return GetDefinedValue( id );
        }

        private Rock.Models.Core.DefinedValue GetDefinedValue( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.DefinedValueService definedValueService = new Rock.Services.Core.DefinedValueService();
                Rock.Models.Core.DefinedValue definedValue = definedValueService.GetDefinedValue( int.Parse( id ) );
                if ( definedValue.Authorized( "View", currentUser ) )
                    return definedValue;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region EntityChange
		
        public Rock.Models.Core.EntityChange GetEntityChangeJson( string id )
        {
            return GetEntityChange( id );
        }

        public Rock.Models.Core.EntityChange GetEntityChangeXml( string id )
        {
            return GetEntityChange( id );
        }

        private Rock.Models.Core.EntityChange GetEntityChange( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.EntityChangeService entityChangeService = new Rock.Services.Core.EntityChangeService();
                Rock.Models.Core.EntityChange entityChange = entityChangeService.GetEntityChange( int.Parse( id ) );
                if ( entityChange.Authorized( "View", currentUser ) )
                    return entityChange;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region FieldType
		
        public Rock.Models.Core.FieldType GetFieldTypeJson( string id )
        {
            return GetFieldType( id );
        }

        public Rock.Models.Core.FieldType GetFieldTypeXml( string id )
        {
            return GetFieldType( id );
        }

        private Rock.Models.Core.FieldType GetFieldType( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Core.FieldTypeService fieldTypeService = new Rock.Services.Core.FieldTypeService();
                Rock.Models.Core.FieldType fieldType = fieldTypeService.GetFieldType( int.Parse( id ) );
                if ( fieldType.Authorized( "View", currentUser ) )
                    return fieldType;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Person
		
        public Rock.Models.Crm.Person GetPersonJson( string id )
        {
            return GetPerson( id );
        }

        public Rock.Models.Crm.Person GetPersonXml( string id )
        {
            return GetPerson( id );
        }

        private Rock.Models.Crm.Person GetPerson( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Crm.PersonService personService = new Rock.Services.Crm.PersonService();
                Rock.Models.Crm.Person person = personService.GetPerson( int.Parse( id ) );
                if ( person.Authorized( "View", currentUser ) )
                    return person;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region PhoneNumber
		
        public Rock.Models.Crm.PhoneNumber GetPhoneNumberJson( string id )
        {
            return GetPhoneNumber( id );
        }

        public Rock.Models.Crm.PhoneNumber GetPhoneNumberXml( string id )
        {
            return GetPhoneNumber( id );
        }

        private Rock.Models.Crm.PhoneNumber GetPhoneNumber( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Crm.PhoneNumberService phoneNumberService = new Rock.Services.Crm.PhoneNumberService();
                Rock.Models.Crm.PhoneNumber phoneNumber = phoneNumberService.GetPhoneNumber( int.Parse( id ) );
                if ( phoneNumber.Authorized( "View", currentUser ) )
                    return phoneNumber;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Group
		
        public Rock.Models.Groups.Group GetGroupJson( string id )
        {
            return GetGroup( id );
        }

        public Rock.Models.Groups.Group GetGroupXml( string id )
        {
            return GetGroup( id );
        }

        private Rock.Models.Groups.Group GetGroup( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Groups.GroupService groupService = new Rock.Services.Groups.GroupService();
                Rock.Models.Groups.Group group = groupService.GetGroup( int.Parse( id ) );
                if ( group.Authorized( "View", currentUser ) )
                    return group;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region GroupRole
		
        public Rock.Models.Groups.GroupRole GetGroupRoleJson( string id )
        {
            return GetGroupRole( id );
        }

        public Rock.Models.Groups.GroupRole GetGroupRoleXml( string id )
        {
            return GetGroupRole( id );
        }

        private Rock.Models.Groups.GroupRole GetGroupRole( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Groups.GroupRoleService groupRoleService = new Rock.Services.Groups.GroupRoleService();
                Rock.Models.Groups.GroupRole groupRole = groupRoleService.GetGroupRole( int.Parse( id ) );
                if ( groupRole.Authorized( "View", currentUser ) )
                    return groupRole;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region GroupType
		
        public Rock.Models.Groups.GroupType GetGroupTypeJson( string id )
        {
            return GetGroupType( id );
        }

        public Rock.Models.Groups.GroupType GetGroupTypeXml( string id )
        {
            return GetGroupType( id );
        }

        private Rock.Models.Groups.GroupType GetGroupType( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Groups.GroupTypeService groupTypeService = new Rock.Services.Groups.GroupTypeService();
                Rock.Models.Groups.GroupType groupType = groupTypeService.GetGroupType( int.Parse( id ) );
                if ( groupType.Authorized( "View", currentUser ) )
                    return groupType;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
		#region Member
		
        public Rock.Models.Groups.Member GetMemberJson( string id )
        {
            return GetMember( id );
        }

        public Rock.Models.Groups.Member GetMemberXml( string id )
        {
            return GetMember( id );
        }

        private Rock.Models.Groups.Member GetMember( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
                Rock.Services.Groups.MemberService memberService = new Rock.Services.Groups.MemberService();
                Rock.Models.Groups.Member member = memberService.GetMember( int.Parse( id ) );
                if ( member.Authorized( "View", currentUser ) )
                    return member;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		#endregion
		
    }
}