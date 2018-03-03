// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Models;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines a block
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{MashedPotatoes.Commerce.Plugin.Reviews.SampleArgument,
    ///         MashedPotatoes.Commerce.Plugin.Reviews.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("Reviews.AddReviewBlock")]
    public class AddReviewBlock : PipelineBlock<AddReviewArgument, Review, CommercePipelineExecutionContext>
    {
        private readonly IFindEntityPipeline findEntityPipeline;

        public AddReviewBlock(IFindEntityPipeline findEntityPipeline) : base()
        {
            this.findEntityPipeline = findEntityPipeline;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="arg">
        /// The AddReviewArgument argument.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="Review"/>.
        /// </returns>
        public override async Task<Review> Run(AddReviewArgument arg, CommercePipelineExecutionContext context)

            // {
            // Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");
            // var result = await Task.Run(() => new Review() { Id =  });
        {
            // return result;
            // }
            AddReviewBlock addReviewBlock = this;

            Condition.Requires(arg).IsNotNull($"{addReviewBlock.Name}: The block argument cannot be null.");

            string
                reviewId = Guid.NewGuid()
                    .ToString(); // string.Format("{0}{1}", (object)CommerceEntity.IdPrefix<Review>(), (object)arg.Code);

            Review review = new Review();
            review.Id = reviewId;
            review.ReviewText = arg.ReviewsText;

            DateTimeOffset? nullable1 = new DateTimeOffset?(DateTimeOffset.UtcNow);
            review.DateCreated = nullable1;
            DateTimeOffset? nullable2 = new DateTimeOffset?(DateTimeOffset.UtcNow);
            review.DateUpdated = nullable2;

            // coupon1.Promotion = new EntityReference()
            // {
            // EntityTarget = promotion.Id,
            // Name = promotion.Name
            // };
            CommerceContext commerceContext1 = context.CommerceContext;
            ReviewAddedModel reviewAdded = new ReviewAddedModel(review.FriendlyId);

            string name = review.Name;
            reviewAdded.Name = name;

            commerceContext1.AddModel(reviewAdded);

            context.CommerceContext.AddUniqueObjectByType(arg);

            string str = await context.CommerceContext.AddMessage(
                             context.GetPolicy<KnownResultCodes>().Information,
                             null,
                             null,
                             string.Format("Generated unallocated review"));

            return review;
        }
    }
}
