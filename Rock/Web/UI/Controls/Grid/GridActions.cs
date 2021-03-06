﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxData( "<{0}:GridActions runat=server></{0}:GridActions>" )]
    public class GridActions : CompositeControl
    {
        HtmlGenericControl aAdd;
        LinkButton lbAdd;

        HtmlGenericControl aExcelExport;
        LinkButton lbExcelExport;

        /// <summary>
        /// Gets or sets a value indicating whether [enable add].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable add]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableAdd
        {
            get 
            {
                bool? b = ViewState["EnableAdd"] as bool?;
                return ( b == null ) ? false : b.Value;
            }
            set
            {
                ViewState["EnableAdd"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable add].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [enable add]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableExcelExport
        {
            get
            {
                bool? b = ViewState["EnableExcelExport"] as bool?;
                return ( b == null ) ? false : b.Value;
            }
            set
            {
                ViewState["EnableExcelExport"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the client add script.
        /// </summary>
        /// <value>
        /// The client add script.
        /// </value>
        public string ClientAddScript
        {
            get
            {
                EnsureChildControls();
                return aAdd.Attributes["onclick"];
            }
            
            set
            {
                EnsureChildControls();
                aAdd.Attributes["onclick"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the client excel export script.
        /// </summary>
        /// <value>
        /// The client excel export script.
        /// </value>
        public string ClientExcelExportScript
        {
            get
            {
                EnsureChildControls();
                return aExcelExport.Attributes["onclick"];
            }

            set
            {
                EnsureChildControls();
                aExcelExport.Attributes["onclick"] = value;
            }
        }

        /// <summary>
        /// Writes the <see cref="T:System.Web.UI.WebControls.CompositeControl"/> content to the specified <see cref="T:System.Web.UI.HtmlTextWriter"/> object, for display on the client.
        /// </summary>
        /// <param name="writer">An <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        protected override void Render( HtmlTextWriter writer )
        {
            aAdd.Visible = EnableAdd && !String.IsNullOrWhiteSpace( ClientAddScript );
            lbAdd.Visible = EnableAdd && String.IsNullOrWhiteSpace( ClientAddScript );

            aExcelExport.Visible = EnableExcelExport && !String.IsNullOrWhiteSpace( ClientExcelExportScript );
            lbExcelExport.Visible = EnableExcelExport && String.IsNullOrWhiteSpace( ClientExcelExportScript );

            base.Render( writer );
        }

        /// <summary>
        /// Recreates the child controls in a control derived from <see cref="T:System.Web.UI.WebControls.CompositeControl"/>.
        /// </summary>
        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag( HtmlTextWriter writer )
        {
            writer.AddAttribute( "class", "grid-actions" );
            base.RenderBeginTag( writer );
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();

            // controls for add
            aAdd = new HtmlGenericControl( "a" );
            aAdd.ID = "aAdd";
            aAdd.Attributes.Add( "href", "#" );
            aAdd.Attributes.Add( "class", "add" );
            aAdd.InnerText = "Add";
            Controls.Add( aAdd );

            lbAdd = new LinkButton();
            lbAdd.ID = "lbAdd";
            lbAdd.CssClass = "add";
            lbAdd.Text = "Add";
            lbAdd.Click += lbAdd_Click;
            lbAdd.CausesValidation = false;
            Controls.Add( lbAdd );

            // controls for excel export
            aExcelExport = new HtmlGenericControl( "a" );
            aExcelExport.ID = "aExcelExport";
            aExcelExport.Attributes.Add( "href", "#" );
            aExcelExport.Attributes.Add( "class", "excel-export" );
            aExcelExport.InnerText = "Export To Excel";
            Controls.Add( aExcelExport );

            lbExcelExport = new LinkButton();
            lbExcelExport.ID = "lbExcelExport";
            lbExcelExport.CssClass = "excel-export";
            lbExcelExport.Text = "Export to Excel";
            lbExcelExport.Click += lbExcelExport_Click;
            lbExcelExport.CausesValidation = false;
            Controls.Add( lbExcelExport );
        }

        void lbAdd_Click( object sender, EventArgs e )
        {
            if ( AddClick != null )
                AddClick( sender, e );
        }

        void lbExcelExport_Click( object sender, EventArgs e )
        {
            if ( ExcelExportClick != null )
                ExcelExportClick( sender, e );
        }

        /// <summary>
        /// Occurs when add action is clicked.
        /// </summary>
        public event EventHandler AddClick;

        /// <summary>
        /// Occurs when add action is clicked.
        /// </summary>
        public event EventHandler ExcelExportClick;
    }
}