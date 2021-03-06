﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace RockWeb.Blocks.Cms
{
    [Rock.Attribute.Property( 0, "XSLT File", "Menu XSLT", "The path to the XSLT File ", true, "~/Assets/XSLT/PageList.xslt" )]
    [Rock.Attribute.Property( 1, "Root Page", "XML", "The root page to use for the page collection. Defaults to the current page instance if not set.", false, "" )]
    [Rock.Attribute.Property( 2, "Number of Levels", "XML", "Number of parent-child page levels to display. Default 3.", true, "3" )]
    public partial class PageXslt : Rock.Web.UI.Block
    {
		private static readonly string ROOT_PAGE = "RootPage";
		private static readonly string NUM_LEVELS = "NumberofLevels";

        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            this.AttributesUpdated += PageXslt_AttributesUpdated;
            //this.AddAttributeUpdateTrigger( upContent );
			//upContent.ContentTemplateContainer.Controls.Add( )

            TransformXml();
        }

        void PageXslt_AttributesUpdated( object sender, EventArgs e )
        {
            TransformXml();
        }

        private void TransformXml()
        {
            XslCompiledTransform xslTransformer = new XslCompiledTransform();
            xslTransformer.Load( Server.MapPath( AttributeValue("XSLTFile") ) );

            Rock.Web.Cache.Page rootPage;
			if ( AttributeValue( ROOT_PAGE ) != string.Empty )
            {
				int pageId = Convert.ToInt32( AttributeValue( ROOT_PAGE ) );
                if ( pageId == -1 )
                    rootPage = PageInstance;
                else
                    rootPage = Rock.Web.Cache.Page.Read( pageId );
            }
            else
                rootPage = PageInstance;

			int levelsDeep = Convert.ToInt32( AttributeValue( NUM_LEVELS ) );

			XDocument pageXml = rootPage.MenuXml( levelsDeep, CurrentUser );

            StringBuilder sb = new StringBuilder();
            TextWriter tw = new StringWriter( sb );
            xslTransformer.Transform( pageXml.CreateReader(), null, tw );

            phContent.Controls.Clear();
            phContent.Controls.Add( new LiteralControl( sb.ToString() ) );
        }
    }
}