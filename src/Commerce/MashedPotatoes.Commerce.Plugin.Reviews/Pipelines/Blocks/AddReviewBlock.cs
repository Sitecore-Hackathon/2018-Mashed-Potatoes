namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Sitecore.Commerce.Core;
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Models;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using Sitecore.Commerce.Plugin.ManagedLists;

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
        {
            AddReviewBlock addReviewBlock = this;

            Condition.Requires(arg).IsNotNull<AddReviewArgument>(string.Format("{0}: The block argument cannot be null.", addReviewBlock.Name));

            string reviewId = Guid.NewGuid().ToString();

            Review review = new Review();
            review.Id = $"{(object)CommerceEntity.IdPrefix<Review>()}{(object)reviewId}";
            review.Text = arg.ReviewsText;
            review.Author = arg.Author;
            review.Score = arg.Score;

            DateTimeOffset? dateCreated = new DateTimeOffset?(DateTimeOffset.UtcNow);
            review.DateCreated = dateCreated;
            DateTimeOffset? dateUpdated = new DateTimeOffset?(DateTimeOffset.UtcNow);
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

            ReviewAddedModel reviewAdded = new ReviewAddedModel(review.FriendlyId);
            reviewAdded.Name = name;
            commerceContextRef.AddModel((Model)reviewAdded);

            context.CommerceContext.AddUniqueObjectByType((object)arg);

            string str = await context.CommerceContext.AddMessage(context.GetPolicy<KnownResultCodes>().Information, (string)null, (object[])null, string.Format("Generated unallocated review"));

            return review;
        }
    }
}
