namespace Sitecore.Commerce.Plugin.ProfileCards.Pipelines
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Pipelines;


    public class SetTrackingFieldPipeline : CommercePipeline<TrackingFieldArgument, TrackingFieldArgument>, ISetTrackingFieldPipeline
    {
        public SetTrackingFieldPipeline(IPipelineConfiguration<ISetTrackingFieldPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

