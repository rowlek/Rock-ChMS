﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// <see cref="Grid"/> Column for editing the security of an item in a row in a grid
    /// </summary>
    [ToolboxData( "<{0}:SecurityField BoundField=server></{0}:SecurityField>" )]
    public class SecurityField : TemplateField
    {
        /// <summary>
        /// Gets or sets the type of the entity being secured
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public string EntityType { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string title = "Security";

        /// <summary>
        /// Performs basic instance initialization for a data control field.
        /// </summary>
        /// <param name="sortingEnabled">A value that indicates whether the control supports the sorting of columns of data.</param>
        /// <param name="control">The data control that owns the <see cref="T:System.Web.UI.WebControls.DataControlField"/>.</param>
        /// <returns>
        /// Always returns false.
        /// </returns>
        public override bool Initialize( bool sortingEnabled, Control control )
        {
            this.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            this.ItemStyle.CssClass = "grid-icon-cell security";

            SecurityFieldTemplate editFieldTemplate = new SecurityFieldTemplate(EntityType, Title);
            this.ItemTemplate = editFieldTemplate;

            return base.Initialize( sortingEnabled, control );
        }
    }

    /// <summary>
    /// Template used by the <see cref="SecurityField"/> control
    /// </summary>
    public class SecurityFieldTemplate : ITemplate
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity.
        /// </summary>
        /// <value>
        /// The type of the entity.
        /// </value>
        public string EntityType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityFieldTemplate"/> class.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="title">The title.</param>
        public SecurityFieldTemplate( string entityType, string title )
        {
            this.EntityType = entityType;
            this.Title = title;
        }

        /// <summary>
        /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control"/> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
        /// </summary>
        /// <param name="container">The <see cref="T:System.Web.UI.Control"/> object to contain the instances of controls from the inline template.</param>
        public void InstantiateIn( Control container )
        {
            DataControlFieldCell cell = container as DataControlFieldCell;
            if ( cell != null )
            {
                HtmlGenericControl aSecure = new HtmlGenericControl( "a" );
                aSecure.Attributes.Add( "class", "show-modal-iframe" );
                aSecure.Attributes.Add( "href", container.Page.ResolveUrl( string.Format( "~/Secure/{0}/{1}",
                    Security.Authorization.EncodeEntityTypeName( EntityType ), "1" ) ) );
                aSecure.Attributes.Add( "title", Title );
                cell.Controls.Add( aSecure );
            }
        }
    }
}