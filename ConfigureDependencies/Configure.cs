using Microsoft.Extensions.DependencyInjection;
using IL = SympliSEOSolution.InterfaceLibrary;
using SympliSEOSolution.Orchestration;
using System;
using GoogleSeoEngine;
using SympliSEOSolution.SeoFactory;
using SympliSEOSolution.SeoEntitiesImplementations;
using SympliSEOSolution.Workers;
using SympliSEOSolution.PositionsFactory;

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
            services.AddTransient<IL.IPositions, BingUrlPositions>();
            services.AddTransient<IL.IPositionsFactory, PositionsFactory.PositionsFactory>();
            services.AddTransient<IL.ISeoEngine, GoogleSeoEngine.GoogleSeoEngine>();
            services.AddTransient<IL.ISEOFactory, SeoFactory.SeoFactory>();
            services.AddTransient<IL.IUrlConstructorUtility, UrlConstructorUtilityForGoogle>();
        }
    }
}
