using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
using MashedPotatoes.Commerce.Plugin.Reviews.Policies;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{
    [PipelineDisplayName("Reviews.block.GetReviewsListView")]
    public class GetReviewsListViewBlock : GetListViewBlock
    {
        private readonly IFindEntitiesInListPipeline findEntitiesInListPipeline;

        public GetReviewsListViewBlock(CommerceCommander commander, IFindEntitiesInListPipeline findEntitiesInListPipeline)
            : base(commander)
        {
            this.findEntitiesInListPipeline = findEntitiesInListPipeline;
        }

        public override async Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            GetReviewsListViewBlock reviewsListViewBlock = this;

            Condition.Requires(entityView).IsNotNull($"{reviewsListViewBlock.Name}: The argument cannot be null");

            EntityViewArgument entityViewArgument = context.CommerceContext.GetObject<EntityViewArgument>();

            if (string.IsNullOrEmpty(entityViewArgument?.ViewName)
                || !entityViewArgument.ViewName.Equals(
                    context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsList,
                    StringComparison.OrdinalIgnoreCase) && !entityViewArgument.ViewName.Equals(
                    context.GetPolicy<KnownReviewsViewsPolicy>().Reviews,
                    StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            EntityView reviews;
            if (entityViewArgument.ViewName.Equals(
                context.GetPolicy<KnownReviewsViewsPolicy>().Reviews,
                StringComparison.OrdinalIgnoreCase))
            {
                EntityView reviewsEntityView = new EntityView { EntityId = string.Empty };
                string reviewsList = context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsList;
                reviewsEntityView.Name = reviewsList;
                reviews = reviewsEntityView;
                reviews.DisplayName = "All";
                reviews.UiHint = "Table";

                entityView.ChildViews.Add(reviews);
            }
            else
            {
                reviews = entityView;
            }

            var reviewsEntities = await this.findEntitiesInListPipeline.Run(
                                  new FindEntitiesInListArgument(
                                      typeof(Review),
                                      CommerceEntity.ListName<Review>(),
                                      0,
                                      int.MaxValue),
                                      context);

            reviewsEntities.List.Items.ForEach(
                reviewEntity =>
                {
                    var review = reviewEntity as Review;

                    EntityView entityView1 = new EntityView { EntityId = review.ProductReference.EntityTarget, ItemId = review.ProductReference.EntityTarget };
                    string summary = context.GetPolicy<KnownReviewsViewsPolicy>().Summary;
                    entityView1.Name = summary;

                    EntityView entityView2 = entityView1;

                    List<ViewProperty> properties1 = entityView2.Properties;
                    ViewProperty viewProperty1 = new ViewProperty
                                                        {
                                                            Name = "Product",
                                                            DisplayName = "Product",
                                                            Value = review.ProductReference.Name,
                                                            UiType = "EntityLink"
                                                        };

                    properties1.Add(viewProperty1);

                    List<ViewProperty> properties2 = entityView2.Properties;
                    ViewProperty viewProperty2 =
                        new ViewProperty
                            {
                                Name = "Score",
                                DisplayName = "Score",
                                Value = review.Score.ToString()
                            };

                    properties2.Add(viewProperty2);

                    List<ViewProperty> properties3 = entityView2.Properties;
                    ViewProperty viewProperty3 =
                        new ViewProperty
                            {
                                Name = "Text",
                                DisplayName = "Text",
                                Value = review.Text
                            };

                    properties3.Add(viewProperty3);

                    List<ViewProperty> properties4 = entityView2.Properties;
                    ViewProperty viewProperty4 =
                        new ViewProperty
                            {
                                Name = "Author",
                                DisplayName = "Author",
                                Value = review.Author
                            };

                    properties4.Add(viewProperty4);

                    List<ViewProperty> properties5 = entityView2.Properties;
                    ViewProperty viewProperty5 =
                        new ViewProperty
                            {
                                Name = "Date",
                                DisplayName = "Date",
                                Value = review.DateCreated?.Date.ToLongDateString()
                            };

                    properties5.Add(viewProperty5);

                    reviews.ChildViews.Add(entityView2);
                });

            return entityView;
        }
    }
}