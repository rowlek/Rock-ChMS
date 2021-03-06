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
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.REST.CRM
{
	/// <summary>
	/// REST WCF service for EmailTemplates
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CRM/EmailTemplate")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class EmailTemplateService : IEmailTemplateService, IService
    {
		/// <summary>
		/// Gets a EmailTemplate object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CRM.DTO.EmailTemplate Get( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
				Rock.CRM.EmailTemplate EmailTemplate = EmailTemplateService.Get( int.Parse( id ) );
				if ( EmailTemplate.Authorized( "View", currentUser ) )
					return EmailTemplate.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this EmailTemplate", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a EmailTemplate object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CRM.DTO.EmailTemplate ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
					Rock.CRM.EmailTemplate EmailTemplate = EmailTemplateService.Get( int.Parse( id ) );
					if ( EmailTemplate.Authorized( "View", user ) )
						return EmailTemplate.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this EmailTemplate", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a EmailTemplate object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateEmailTemplate( string id, Rock.CRM.DTO.EmailTemplate EmailTemplate )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
				Rock.CRM.EmailTemplate existingEmailTemplate = EmailTemplateService.Get( int.Parse( id ) );
				if ( existingEmailTemplate.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingEmailTemplate).CurrentValues.SetValues(EmailTemplate);
					
					if (existingEmailTemplate.IsValid)
						EmailTemplateService.Save( existingEmailTemplate, currentUser.PersonId );
					else
						throw new WebFaultException<string>( existingEmailTemplate.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this EmailTemplate", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a EmailTemplate object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateEmailTemplate( string id, string apiKey, Rock.CRM.DTO.EmailTemplate EmailTemplate )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
					Rock.CRM.EmailTemplate existingEmailTemplate = EmailTemplateService.Get( int.Parse( id ) );
					if ( existingEmailTemplate.Authorized( "Edit", user ) )
					{
						uow.objectContext.Entry(existingEmailTemplate).CurrentValues.SetValues(EmailTemplate);
					
						if (existingEmailTemplate.IsValid)
							EmailTemplateService.Save( existingEmailTemplate, user.PersonId );
						else
							throw new WebFaultException<string>( existingEmailTemplate.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this EmailTemplate", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new EmailTemplate object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateEmailTemplate( Rock.CRM.DTO.EmailTemplate EmailTemplate )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
				Rock.CRM.EmailTemplate existingEmailTemplate = new Rock.CRM.EmailTemplate();
				EmailTemplateService.Add( existingEmailTemplate, currentUser.PersonId );
				uow.objectContext.Entry(existingEmailTemplate).CurrentValues.SetValues(EmailTemplate);

				if (existingEmailTemplate.IsValid)
					EmailTemplateService.Save( existingEmailTemplate, currentUser.PersonId );
				else
					throw new WebFaultException<string>( existingEmailTemplate.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
            }
        }

		/// <summary>
		/// Creates a new EmailTemplate object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateEmailTemplate( string apiKey, Rock.CRM.DTO.EmailTemplate EmailTemplate )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
					Rock.CRM.EmailTemplate existingEmailTemplate = new Rock.CRM.EmailTemplate();
					EmailTemplateService.Add( existingEmailTemplate, user.PersonId );
					uow.objectContext.Entry(existingEmailTemplate).CurrentValues.SetValues(EmailTemplate);

					if (existingEmailTemplate.IsValid)
						EmailTemplateService.Save( existingEmailTemplate, user.PersonId );
					else
						throw new WebFaultException<string>( existingEmailTemplate.ValidationResults.AsDelimited(", "), System.Net.HttpStatusCode.BadRequest );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a EmailTemplate object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteEmailTemplate( string id )
        {
            var currentUser = Rock.CMS.UserService.GetCurrentUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
				Rock.CRM.EmailTemplate EmailTemplate = EmailTemplateService.Get( int.Parse( id ) );
				if ( EmailTemplate.Authorized( "Edit", currentUser ) )
				{
					EmailTemplateService.Delete( EmailTemplate, currentUser.PersonId );
					EmailTemplateService.Save( EmailTemplate, currentUser.PersonId );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this EmailTemplate", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a EmailTemplate object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteEmailTemplate( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CRM.EmailTemplateService EmailTemplateService = new Rock.CRM.EmailTemplateService();
					Rock.CRM.EmailTemplate EmailTemplate = EmailTemplateService.Get( int.Parse( id ) );
					if ( EmailTemplate.Authorized( "Edit", user ) )
					{
						EmailTemplateService.Delete( EmailTemplate, user.PersonId );
						EmailTemplateService.Save( EmailTemplate, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this EmailTemplate", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
