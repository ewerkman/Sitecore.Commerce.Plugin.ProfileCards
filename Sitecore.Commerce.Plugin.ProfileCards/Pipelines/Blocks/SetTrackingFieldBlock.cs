namespace Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Blocks
{
    using Newtonsoft.Json;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Commerce.Plugin.ProfileCards.Helpers;
    using Sitecore.Commerce.Plugin.ProfileCards.Models;
    using Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Arguments;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [PipelineDisplayName("Sitecore.Commerce.Plugin.ProfileCards.Pipelines.Blocks.SetTrackingFieldBlock")]
    public class SetTrackingFieldBlock : PipelineBlock<CommerceEntity, CommerceEntity, CommercePipelineExecutionContext>
    {

        protected CommerceCommander Commander { get; set; }

        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:Sitecore.Framework.Pipelines.PipelineBlock" /> class.</summary>
        /// <param name="commander">The commerce commander.</param>
        public SetTrackingFieldBlock(CommerceCommander commander)
            : base(null)
        {

            this.Commander = commander;

        }

        public async override Task<CommerceEntity> Run(CommerceEntity arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            var sellableItem = arg as SellableItem;

            if (sellableItem == null)
            {
                return arg;
            }

            var externalSettingsComponent = sellableItem.GetComponent<ExternalSettingsComponent>();
            var allParents = GetAllParents(sellableItem);

            var settingsCollection = GetExternalSettings(externalSettingsComponent);

            var sellableItemSitecoreId = sellableItem.SitecoreId;

            foreach (var parent in allParents)
            {
                Guid settingsGuid = GuidUtility.GetDeterministicGuid($"{sellableItemSitecoreId}|{parent}");

                Tracking tracking = new Tracking();

                Dictionary<string, Dictionary<string, string>> settings;

                if (settingsCollection.ContainsKey(settingsGuid))
                {
                    settings = settingsCollection[settingsGuid];
                    if (settings.ContainsKey("shared"))
                    {
                        if (settings["shared"].ContainsKey("__Tracking"))
                        {
                            tracking = settings["shared"]["__Tracking"].XmlDeserializeFromString<Tracking>();
                        }
                    }
                }
                else
                {
                    settings = new Dictionary<string, Dictionary<string, string>>();
                    settingsCollection.Add(settingsGuid, settings);
                }

                var result = await Commander.Pipeline<ISetTrackingFieldPipeline>().Run(new TrackingFieldArgument(sellableItem, parent, tracking), context);
                var serializedTrackingField = result.TrackingField.XmlSerializeToString();

                if (!settings.ContainsKey("shared"))
                {
                    settings.Add("shared", new Dictionary<string, string>());
                }

                var sharedSettings = settings["shared"];
                if (!sharedSettings.ContainsKey("__Tracking"))
                {
                    sharedSettings.Add("__Tracking", serializedTrackingField);
                }
                else
                {
                    settings["shared"]["__Tracking"] = serializedTrackingField;
                }
            }

            externalSettingsComponent.Settings = JsonConvert.SerializeObject(settingsCollection);

            return arg;
        }

        private Dictionary<Guid, Dictionary<string, Dictionary<string, string>>> GetExternalSettings(ExternalSettingsComponent externalSettings)
        {
            var settingsCollection = new Dictionary<Guid, Dictionary<string, Dictionary<string, string>>>();

            if (!string.IsNullOrEmpty(externalSettings.Settings))
            {
                try
                {
                    settingsCollection = JsonConvert.DeserializeObject<Dictionary<Guid, Dictionary<string, Dictionary<string, string>>>>(externalSettings.Settings);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return settingsCollection;
        }

        /// <summary>
        ///     Returns an array of all the parent ids (category + catalog) of a SellableItem
        /// </summary>
        /// <param name="sellableItem"></param>
        /// <returns></returns>
        private static string[] GetAllParents(SellableItem sellableItem)
        {
            var parentCategories = sellableItem.ParentCategoryList?.Split('|');

            return parentCategories;
        }
    }
}