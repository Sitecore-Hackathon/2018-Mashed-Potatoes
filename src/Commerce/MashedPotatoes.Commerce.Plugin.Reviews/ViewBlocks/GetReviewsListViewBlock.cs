using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Policies;
using MashedPotatoes.Commerce.Plugin.Reviews.Entities;

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
            Condition.Requires<EntityView>(entityView).IsNotNull<EntityView>(string.Format("{0}: The argument cannot be null", (object)/*__nonvirtual*/(reviewsListViewBlock.Name)));
            EntityViewArgument entityViewArgument = context.CommerceContext.GetObject<EntityViewArgument>();
            if (string.IsNullOrEmpty(entityViewArgument != null ? entityViewArgument.ViewName : (string)null) || !entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsList, StringComparison.OrdinalIgnoreCase) && !entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard, StringComparison.OrdinalIgnoreCase))
                return entityView;
            EntityView books;
            if (entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard, StringComparison.OrdinalIgnoreCase))
            {
                EntityView entityView1 = new EntityView();
                entityView1.EntityId = string.Empty;
                string reviewsList = context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsList;
                entityView1.Name = reviewsList;
                books = entityView1;
                entityView.ChildViews.Add((Model)books);
            }
            else
                books = entityView;
            string listName = string.Format("{0}", (object)CommerceEntity.ListName<Review>());
            await reviewsListViewBlock.SetListMetadata(books, listName, context.GetPolicy<KnownReviewsActionsPolicy>().PaginateReviews, context);
            (await reviewsListViewBlock.GetEntities(books, listName, context)).OfType<Review>().ForEach<Review>((Action<Review>)(review =>
            {
                EntityView entityView1 = new EntityView();
                entityView1.EntityId = review.Id;
                entityView1.ItemId = review.Id;
                string summary = context.GetPolicy<KnownReviewsViewsPolicy>().Summary;
                entityView1.Name = summary;
                EntityView entityView2 = entityView1;
                List<ViewProperty> properties1 = entityView2.Properties;
                ViewProperty viewProperty1 = new ViewProperty();
                viewProperty1.Name = "ItemId";
                viewProperty1.RawValue = (object)review.Id;
                int num1 = 1;
                viewProperty1.IsReadOnly = num1 != 0;
                int num2 = 1;
                viewProperty1.IsHidden = num2 != 0;
                properties1.Add(viewProperty1);
                List<ViewProperty> properties2 = entityView2.Properties;
                ViewProperty viewProperty2 = new ViewProperty();
                viewProperty2.Name = "Name";
                viewProperty2.RawValue = (object)review.Name;
                int num3 = 1;
                viewProperty2.IsReadOnly = num3 != 0;
                string str = "EntityLink";
                viewProperty2.UiType = str;
                properties2.Add(viewProperty2);
                List<ViewProperty> properties3 = entityView2.Properties;
                ViewProperty viewProperty3 = new ViewProperty();
                viewProperty3.Name = "Description";
                viewProperty3.RawValue = (object)review.ReviewText;
                int num4 = 1;
                viewProperty3.IsReadOnly = num4 != 0;
                properties3.Add(viewProperty3);
                List<ViewProperty> properties4 = entityView2.Properties;
                ViewProperty viewProperty4 = new ViewProperty();
                viewProperty4.Name = "DisplayName";
                viewProperty4.RawValue = (object)review.DisplayName;
                int num5 = 1;
                viewProperty4.IsReadOnly = num5 != 0;
                properties4.Add(viewProperty4);
                books.ChildViews.Add((Model)entityView2);
            }));
            return entityView;
        }
    }
}