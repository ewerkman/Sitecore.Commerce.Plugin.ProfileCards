// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetInterestProfileCardBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.ProfileCards.Sample.Pipelines.Blocks
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ProfileCards.Models;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines a pipeline block
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{Sitecore.Commerce.Core.PipelineArgument,
    ///         Sitecore.Commerce.Core.PipelineArgument, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("Change to <Project>Constants.Pipelines.Blocks.<Block Name>")]
    public class SetInterestProfileCardBlock : PipelineBlock<TrackingFieldArgument, TrackingFieldArgument, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// Gets or sets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        protected CommerceCommander Commander { get; set; }

        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:Sitecore.Framework.Pipelines.PipelineBlock" /> class.</summary>
        /// <param name="commander">The commerce commander.</param>
        public SetInterestProfileCardBlock(CommerceCommander commander)
            : base(null)
        {

            this.Commander = commander;

        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="arg">
        /// The pipeline argument.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="PipelineArgument"/>.
        /// </returns>
        public override Task<TrackingFieldArgument> Run(TrackingFieldArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            // If the profile already exists, we are not going to set it/update it
            if( arg.TrackingField.Profiles.Any(p => p.Id == "2904a850-5b80-487a-a517-fc1f27fb2957"))
            {
                return Task.FromResult(arg);
            }

            ProfileKey[] profileKeys = { new ProfileKey("Audio", 0), new ProfileKey("Camera", 0), new ProfileKey("Television", 10) };
            Profile profile = new Profile("2904a850-5b80-487a-a517-fc1f27fb2957", "Interest");

            profile.Presets = "television|100||";
            profile.Keys = profileKeys.ToList();

            arg.TrackingField.AddProfile(profile);

            return Task.FromResult(arg);
        }
    }
}