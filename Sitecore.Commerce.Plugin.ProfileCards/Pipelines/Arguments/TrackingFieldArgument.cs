namespace Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Commerce.Plugin.ProfileCards.Models;

    public class TrackingFieldArgument : PipelineArgument
    {
        public SellableItem SellableItem { get; }
        public string ParentCategoryName { get; }
        public Tracking TrackingField { get; }

        public TrackingFieldArgument(SellableItem sellableItem, string parentCategoryName, Tracking trackingField)
        {
            SellableItem = sellableItem;
            ParentCategoryName = parentCategoryName;
            TrackingField = trackingField;
        }
    }
}