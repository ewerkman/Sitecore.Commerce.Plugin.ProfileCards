namespace Sitecore.Commerce.Plugin.ProfileCards
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Blocks;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    public class ConfigureSitecore : IConfigureSitecore
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(config => config
                .ConfigurePipeline<IGetSellableItemConnectPipeline>(p => p.Add<SetTrackingFieldBlock>().After<GetCustomRelationshipsBlock>())
                .AddPipeline<ISetTrackingFieldPipeline, SetTrackingFieldPipeline>()
                );

            services.RegisterAllCommands(assembly);
        }
    }
}