using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
using MashedPotatoes.Commerce.Plugin.Reviews.Policies;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{
    [PipelineDisplayName("Reviews.block.getreviewslistview")]
    public class GetReviewsListViewBlock : GetListViewBlock
    {
        public GetReviewsListViewBlock(CommerceCommander commander)
            : base(commander)
        {
        }

        public override async Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            GetReviewsListViewBlock reviewsListViewBlock = this;

            // ISSUE: explicit non-virtual call
            Condition.Requires(entityView).IsNotNull($"{reviewsListViewBlock.Name}: The argument cannot be null");

            EntityViewArgument entityViewArgument = context.CommerceContext.GetObject<EntityViewArgument>();

            if (string.IsNullOrEmpty(entityViewArgument?.ViewName)
                || !entityViewArgument.ViewName.Equals(
                    context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsList,
                    StringComparison.OrdinalIgnoreCase) && !entityViewArgument.ViewName.Equals(
                    context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard,
                    StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            EntityView reviews;
            if (entityViewArgument.ViewName.Equals(
                context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard,
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

            (await this.GetEntities()).OfType<Review>().ForEach(
                review =>
                    {
                        EntityView entityView1 = new EntityView { EntityId = review.Id, ItemId = review.Id };
                        string summary = context.GetPolicy<KnownReviewsViewsPolicy>().Summary;
                        entityView1.Name = summary;

                        EntityView entityView2 = entityView1;

                        List<ViewProperty> properties1 = entityView2.Properties;
                        ViewProperty viewProperty1 =
                            new ViewProperty { Name = "ItemId", DisplayName = "Item Id", Value = review.Id };

                        properties1.Add(viewProperty1);

                        List<ViewProperty> properties2 = entityView2.Properties;
                        ViewProperty viewProperty2 = new ViewProperty
                                                         {
                                                             Name = "Name",
                                                             DisplayName = "Name",
                                                             Value = review.Name,
                                                             UiType = "EntityLink"
                                                         };

                        properties2.Add(viewProperty2);

                        List<ViewProperty> properties3 = entityView2.Properties;
                        ViewProperty viewProperty3 =
                            new ViewProperty
                                {
                                    Name = "Description",
                                    DisplayName = "Description",
                                    Value = review.ReviewText
                                };

                        properties3.Add(viewProperty3);

                        List<ViewProperty> properties4 = entityView2.Properties;
                        ViewProperty viewProperty4 =
                            new ViewProperty { Name = "Author", DisplayName = "Author", Value = review.DisplayName };

                        properties4.Add(viewProperty4);

                        List<ViewProperty> properties5 = entityView2.Properties;
                        ViewProperty viewProperty5 =
                            new ViewProperty { Name = "Date", DisplayName = "Date", Value = review.DisplayName };

                        properties5.Add(viewProperty5);

                        reviews.ChildViews.Add(entityView2);
                    });

            return entityView;
        }

        protected async Task<IEnumerable<CommerceEntity>> GetEntities()
        {
            return await Task.Run(() =>
                {
                    var reviewlist = new List<CommerceEntity>()
                                         {
                                             
                                         };

                    for (int i = 1; i <= 10; i++)
                    {
                        reviewlist.Add(new Review
                                           {
                            Id = "id",
                            Name = "Name",
                            DisplayName = "displayName",
                                               ReviewText = "sdfdsf",
                                               ProductReference = new EntityReference("pro")
                                           });
                    }

                    return (IEnumerable<CommerceEntity>)reviewlist ?? Enumerable.Empty<CommerceEntity>();

                });
        }
    }
}