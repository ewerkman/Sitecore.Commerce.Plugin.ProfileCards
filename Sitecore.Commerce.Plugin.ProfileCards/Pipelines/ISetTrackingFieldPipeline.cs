namespace Sitecore.Commerce.Plugin.ProfileCards.Pipelines
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName("Sitecore.Commerce.Plugin.ProfileCards.Pipelines.ISetTrackingFieldPipeline")]
    public interface ISetTrackingFieldPipeline : IPipeline<TrackingFieldArgument, TrackingFieldArgument, CommercePipelineExecutionContext>
    {
    }
}
