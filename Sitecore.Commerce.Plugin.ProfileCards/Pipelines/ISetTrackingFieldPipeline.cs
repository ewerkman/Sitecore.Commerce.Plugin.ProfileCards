// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISetProfileCardPipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.ProfileCards.Pipelines
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the ISetProfileCardPipeline interface
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.IPipeline{PipelineArgumentOrEntity,
    ///         PipelineArgumentOrEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("[Insert Project Name].Pipeline.ISetProfileCardPipeline")]
    public interface ISetTrackingFieldPipeline : IPipeline<TrackingFieldArgument, TrackingFieldArgument, CommercePipelineExecutionContext>
    {
    }
}
