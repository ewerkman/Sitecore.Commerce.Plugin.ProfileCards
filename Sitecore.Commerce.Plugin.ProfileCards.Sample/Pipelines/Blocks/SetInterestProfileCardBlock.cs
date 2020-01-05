namespace Sitecore.Commerce.Plugin.ProfileCards.Sample.Pipelines.Blocks
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ProfileCards.Models;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using System.Linq;
    using System.Threading.Tasks;

    [PipelineDisplayName("Sitecore.Commerce.Plugin.ProfileCards.Sample.Pipelines.Blocks.SetInterestProfileCardBlock")]
    public class SetInterestProfileCardBlock : PipelineBlock<TrackingFieldArgument, TrackingFieldArgument, CommercePipelineExecutionContext>
    {
        private const string InterestProfileId = "2904a850-5b80-487a-a517-fc1f27fb2957";

        protected CommerceCommander Commander { get; set; }

        public SetInterestProfileCardBlock(CommerceCommander commander)
            : base(null)
        {
            this.Commander = commander;
        }

        public override Task<TrackingFieldArgument> Run(TrackingFieldArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            // If the profile already exists, we are not going to set it/update it
            if( arg.TrackingField.Profiles.Any(p => p.Id == InterestProfileId))
            {
                return Task.FromResult(arg);
            }

            ProfileKey[] profileKeys = { new ProfileKey("Audio", 0), new ProfileKey("Camera", 0), new ProfileKey("Television", 10) };
            Profile profile = new Profile(InterestProfileId, "Interest");

            profile.Keys = profileKeys.ToList();

            arg.TrackingField.AddProfile(profile);

            return Task.FromResult(arg);
        }
    }
}