// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleCommand.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MashedPotatoes.Commerce.Plugin.Reviews.Commands
{
    using System;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    /// <inheritdoc />
    /// <summary>
    /// Defines the AddReviewCommand command.
    /// </summary>
    public class AddReviewCommand : CommerceCommand
    {
        /// <summary>
        /// The _pipeline.
        /// </summary>
        private readonly IAddReviewPipeline _pipeline;

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
            this._pipeline = pipeline;
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
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Review> Process(CommerceContext commerceContext, string productId, string reviewText)
        {
            using (var activity = CommandActivity.Start(commerceContext, this))
            {
                var arg = new AddReviewArgument(productId, reviewText);
                var result = await this._pipeline.Run(arg, new CommercePipelineExecutionContextOptions(commerceContext));

                return result;
            }
        }
    }
}