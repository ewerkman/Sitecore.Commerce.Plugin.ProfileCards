namespace Sitecore.Commerce.Plugin.ProfileCards.Pipelines
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Pipelines;


    public class SetTrackingFieldPipeline : CommercePipeline<TrackingFieldArgument, TrackingFieldArgument>, ISetTrackingFieldPipeline
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.ProfileCards.Pipelines.SetProfileCardPipeline" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public SetTrackingFieldPipeline(IPipelineConfiguration<ISetTrackingFieldPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

