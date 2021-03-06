﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.ServiceModel.Activation;
using System.Web.Routing;

namespace Rock.REST
{
    /// <summary>
    /// Helper class that is used by the Global.ascx.cs class to load all <see cref="Rock.REST.IService"/> 
    /// classes found through MEF and add service routes for them.  
    /// </summary>
    public class ServiceHelper
    {
        // MEF Container
        private CompositionContainer container;

        // MEF Import definition
#pragma warning disable
        [ImportMany( typeof( IService ) )]
        IEnumerable<Lazy<IService, IServiceData>> services;
#pragma warning restore

        /// <summary>
        /// Adds service routes for every <see cref="IService"/> class found through MEF.
        /// </summary>
        /// <param name="routes">The route collection.</param>
        /// <param name="routePrefix">The route prefix.</param>
        public void AddRoutes( RouteCollection routes, string routePrefix = "" )
        {
            container.ComposeParts( this );

            var factory = new WebServiceHostFactory();

            foreach ( Lazy<IService, IServiceData> i in services )
                routes.Add( new ServiceRoute( routePrefix + i.Metadata.RouteName, factory, i.Value.GetType() ) );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceHelper"/> class.  Creates the MEF catalog
        /// and container.  Will load all <see cref="IService"/> classes in the Rock.dll or any dll in 
        /// the Extensions folder
        /// </summary>
        /// <param name="extensionFolder">The extension folder.</param>
        public ServiceHelper( string extensionFolder )
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add( new AssemblyCatalog( typeof( ServiceHelper ).Assembly ) );

            if ( Directory.Exists( extensionFolder ) )
                catalog.Catalogs.Add( new DirectoryCatalog( extensionFolder ) );

            container = new CompositionContainer( catalog );
        }
    }
}

