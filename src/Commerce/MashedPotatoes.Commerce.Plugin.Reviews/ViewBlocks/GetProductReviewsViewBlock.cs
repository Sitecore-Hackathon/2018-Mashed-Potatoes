using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
using MashedPotatoes.Commerce.Plugin.Reviews.Policies;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{
    [PipelineDisplayName("Reviews.block.GetProductReviewsView")]
    public class GetProductReviewsViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        private readonly IFindEntityPipeline findEntityPipeline;

        public GetProductReviewsViewBlock(IFindEntityPipeline findEntityPipeline)
          : base(null)
        {
            this.findEntityPipeline = findEntityPipeline;
        }

        public override async Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            GetProductReviewsViewBlock detailsViewBlock = this;

            Condition.Requires(entityView).IsNotNull($"{detailsViewBlock.Name}: The argument cannot be null");
            KnownRelationshipViewsPolicy policy1 = context.GetPolicy<KnownRelationshipViewsPolicy>();
            EntityViewArgument entityViewArgument = context.CommerceContext.GetObject<EntityViewArgument>();
            if (string.IsNullOrEmpty(entityViewArgument != null ? entityViewArgument.ViewName : null)
                || !entityViewArgument.ViewName.Equals(policy1.Master, StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            if (!(entityViewArgument.Entity is SellableItem))
            {
                return entityView;
            }

            EntityView reviewsEntityView = new EntityView
                                               {
                                                   EntityId = string.Empty
                                               };
            string reviewsList = context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsList;
            reviewsEntityView.Name = reviewsList;

            EntityView reviews = reviewsEntityView;
            reviews.DisplayName = "All";
            reviews.UiHint = "Table";

            entityView.ChildViews.Add(reviews);


            (await this.GetEntities()).OfType<Review>().ForEach(review =>
                {
                    EntityView entityView1 = new EntityView
                                                 {
                                                     EntityId = review.Id,
                                                     ItemId = review.Id
                                                 };
                    string summary = context.GetPolicy<KnownReviewsViewsPolicy>().Summary;
                    entityView1.Name = summary;

                    EntityView entityView2 = entityView1;

                    List<ViewProperty> properties1 = entityView2.Properties;
                    ViewProperty viewProperty1 = new ViewProperty
                                                     {
                                                         Name = "ItemId",
                                                         DisplayName = "Item Id",
                                                         Value = review.Id
                                                     };

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
                    ViewProperty viewProperty3 = new ViewProperty
                                                     {
                                                         Name = "Description",
                                                         DisplayName = "Description",
                                                         Value = review.ReviewText
                                                     };

                    properties3.Add(viewProperty3);

                    List<ViewProperty> properties4 = entityView2.Properties;
                    ViewProperty viewProperty4 = new ViewProperty
                                                     {
                                                         Name = "Author",
                                                         DisplayName = "Author",
                                                         Value = review.DisplayName
                                                     };

                    properties4.Add(viewProperty4);

                    List<ViewProperty> properties5 = entityView2.Properties;
                    ViewProperty viewProperty5 = new ViewProperty
                                                     {
                                                         Name = "Date",
                                                         DisplayName = "Date",
                                                         Value = review.DisplayName
                                                     };

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