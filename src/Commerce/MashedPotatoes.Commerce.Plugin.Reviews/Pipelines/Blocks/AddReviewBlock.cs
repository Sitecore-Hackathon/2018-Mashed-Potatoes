namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Models;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.ManagedLists;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName("Reviews.AddReviewBlock")]
    public class AddReviewBlock : PipelineBlock<AddReviewArgument, Review, CommercePipelineExecutionContext>
    {
        public AddReviewBlock() : base()
        {
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
        {
            AddReviewBlock addReviewBlock = this;

            Condition.Requires(arg).IsNotNull($"{addReviewBlock.Name}: The block argument cannot be null.");

            string reviewId = Guid.NewGuid().ToString();

            Review review = new Review
                                {
                                    Id = $"{CommerceEntity.IdPrefix<Review>()}{reviewId}",
                                    Text = arg.ReviewsText,
                                    Author = arg.Author,
                                    Score = arg.Score
                                };

            DateTimeOffset? dateCreated = DateTimeOffset.UtcNow;
            review.DateCreated = dateCreated;
            DateTimeOffset? dateUpdated = DateTimeOffset.UtcNow;
            review.DateUpdated = dateUpdated;

            CommerceContext commerceContextRef = context.CommerceContext;

            string name = review.Name;

            review.ProductReference = new EntityReference()
            {
                EntityTarget = arg.Product.Id,
                Name = arg.Product.Name
            };

            Review reviewRef = review;

            reviewRef.SetComponent(new ListMembershipsComponent()
            {
                Memberships = new List<string>()
                  {
                    CommerceEntity.ListName<Review>()
                  }
            });

            ReviewAddedModel reviewAdded = new ReviewAddedModel(review.FriendlyId) { Name = name };
            commerceContextRef.AddModel(reviewAdded);

            context.CommerceContext.AddUniqueObjectByType(arg);

            await context.CommerceContext.AddMessage(context.GetPolicy<KnownResultCodes>().Information, null, null, "Generated unallocated review");

            return review;
        }
    }
}
