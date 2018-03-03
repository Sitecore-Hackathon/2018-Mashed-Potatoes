using MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks;

using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.BusinessUsers;

namespace MashedPotatoes.Commerce.Plugin.Reviews
{
    using System.Reflection;

    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks;

    using Microsoft.Extensions.DependencyInjection;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;

    /// <summary>
    /// The configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(
                config => config
                    .AddPipeline<ISamplePipeline, SamplePipeline>(configure => { configure.Add<SampleBlock>(); })
                    .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>())
                    .ConfigurePipeline<IBizFxNavigationPipeline>(configure => configure.Add<GetReviewsNavigationViewBlock>().After<GetNavigationViewBlock>())
                    .ConfigurePipeline<IGetEntityViewPipeline>(configure => configure.Add<GetRewiewsDashboardViewBlock>()
                        .Add<GetReviewsListViewBlock>().After<GetRewiewsDashboardViewBlock>()
                        .Add<GetReviewDetailsViewBlock>().After<GetReviewsListViewBlock>()));
            services.RegisterAllCommands(assembly);
        }
    }
}