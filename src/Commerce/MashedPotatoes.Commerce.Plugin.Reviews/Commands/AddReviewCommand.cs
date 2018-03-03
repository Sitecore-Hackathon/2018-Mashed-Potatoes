namespace MashedPotatoes.Commerce.Plugin.Reviews.Commands
{
    using System;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;

    /// <inheritdoc />
    /// <summary>
    /// Defines the AddReviewCommand command.
    /// </summary>
    public class AddReviewCommand : CommerceCommand
    {
        /// <summary>
        /// The _pipeline.
        /// </summary>
        private readonly IAddReviewPipeline pipeline;
       

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.SampleCommand" /> class.
        /// </summary>
        /// <param name="pipeline">
        /// The pipeline.
        /// </param>
        /// <param name="serviceProvider">The service provider</param>
        public AddReviewCommand(IAddReviewPipeline pipeline, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.pipeline = pipeline;
        }

        /// <summary>
        /// The process.
        /// </summary>
        /// <param name="commerceContext">
        /// The commerce context.
        /// </param>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <param name="reviewText">
        /// The review text.
        /// </param>
        /// <param name="author"></param>
        /// <param name="score"></param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Review> Process(CommerceContext commerceContext, string productId, string reviewText, string author, int score)
        {
            using (var activity = CommandActivity.Start(commerceContext, this))
            {
                var arg = new AddReviewArgument(productId, reviewText, author, score);

                var result = await this.pipeline.Run(arg, new CommercePipelineExecutionContextOptions(commerceContext));

                return result;
            }
        }
    }
}