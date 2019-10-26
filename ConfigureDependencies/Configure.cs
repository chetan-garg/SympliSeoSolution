using Microsoft.Extensions.DependencyInjection;
using IL = SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.Orchestration;
using SympliSEOSolution.Utilities;
using System;
using GoogleSeoEngine;
using SeoFactory;
using SympliSEOSolution.SeoEntitiesImplementations;

namespace SympliSEOSolution.ConfigureDependencies
{
    public static class Configure
    {
        public static void ConfigureProjectDependencies(IServiceCollection services)
        {
            services.AddTransient<IL.IRequestProcessor, WebRequestProcessor>();
            services.AddTransient<IL.ISeoOrchestration, SeoOrchestration>();
            services.AddTransient<IL.IExecuteSearch, ExecuteHttpSearchRequest>();
            services.AddTransient<IL.IHtmlParserUtility, HtmlParserUtility>();
            services.AddTransient<IL.IPositions, UrlPositions>();
            services.AddTransient<IL.ISeoEngine, GoogleSeoEngine.GoogleSeoEngine>();
            services.AddTransient<IL.ISEOFactory, SeoFactory.SeoFactory>();
            services.AddTransient<IL.IUrlConstructorUtility, UrlConstructorUtilityForGoogle>();
        }
    }
}
