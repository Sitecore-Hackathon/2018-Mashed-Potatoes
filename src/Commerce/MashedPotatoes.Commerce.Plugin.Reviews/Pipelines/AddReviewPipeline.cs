namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines
{
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Microsoft.Extensions.Logging;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    ///  Defines the AddReviewPipeline pipeline.
    /// </summary>
    public class AddReviewPipeline : CommercePipeline<AddReviewArgument, Review>, IAddReviewPipeline
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.AddReviewPipeline" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public AddReviewPipeline(IPipelineConfiguration<IAddReviewPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

