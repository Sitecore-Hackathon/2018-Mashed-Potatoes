using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Policies;
using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{
    [PipelineDisplayName("Reviews.block.getreviewdetailsview")]
    public class GetReviewDetailsViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        public GetReviewDetailsViewBlock()
            : base((string)null)
        {
        }
        public override Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            Condition.Requires<EntityView>(entityView).IsNotNull<EntityView>(string.Format("{0}: The argument cannot be null", (object)this.Name));
            EntityViewArgument entityViewArgument = context.CommerceContext.GetObject<EntityViewArgument>();
            if (string.IsNullOrEmpty(entityViewArgument != null ? entityViewArgument.ViewName : (string)null) || !entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().Details, StringComparison.OrdinalIgnoreCase) && !entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().Master, StringComparison.OrdinalIgnoreCase))
                return Task.FromResult<EntityView>(entityView);
            if (entityViewArgument.ForAction.Equals(context.GetPolicy<KnownReviewsActionsPolicy>().AddReview, StringComparison.OrdinalIgnoreCase) && entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().Details, StringComparison.OrdinalIgnoreCase))
            {
                this.PopulateDetails(entityView, null, true, false, context);
                return Task.FromResult<EntityView>(entityView);
            }
            bool isEditAction = entityViewArgument.ForAction.Equals(context.GetPolicy<KnownReviewsActionsPolicy>().EditReview, StringComparison.OrdinalIgnoreCase);
            if (!(entityViewArgument.Entity is Review) || !isEditAction && !string.IsNullOrEmpty(entityViewArgument.ForAction))
                return Task.FromResult<EntityView>(entityView);
            Review entity = (Review)entityViewArgument.Entity;
            EntityView view;
            if (entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().Master, StringComparison.OrdinalIgnoreCase))
            {
                EntityView entityView1 = new EntityView();
                entityView1.EntityId = (entity != null ? entity.Id : (string)null) ?? string.Empty;
                string details = context.GetPolicy<KnownReviewsViewsPolicy>().Details;
                entityView1.Name = details;
                view = entityView1;
                entityView.ChildViews.Add((Model)view);
            }
            else
                view = entityView;
            this.PopulateDetails(view, entity, false, isEditAction, context);
            return Task.FromResult<EntityView>(entityView);
        }

        private void PopulateDetails(EntityView view, Review review, bool isAddAction, bool isEditAction, CommercePipelineExecutionContext context)
        {
            if (view == null)
                return;
            if (!isAddAction && !isEditAction)
            {
                List<ViewProperty> properties = view.Properties;
                ViewProperty viewProperty = new ViewProperty();
                string str1 = "Description";
                viewProperty.Name = str1;
                string str2 = (review != null ? review.ReviewText : (string)null) ?? string.Empty;
                viewProperty.RawValue = (object)str2;
                int num1 = 1;
                viewProperty.IsReadOnly = num1 != 0;
                int num2 = 0;
                viewProperty.IsRequired = num2 != 0;
                string str3 = "MultiLine";
                viewProperty.UiType = str3;
                properties.Add(viewProperty);
            }
            else
            {
                List<ViewProperty> properties1 = view.Properties;
                ViewProperty viewProperty1 = new ViewProperty();
                string str1 = "Name";
                viewProperty1.Name = str1;
                string str2 = (review != null ? review.Name : (string)null) ?? string.Empty;
                viewProperty1.RawValue = (object)str2;
                int num1 = isEditAction ? 1 : 0;
                viewProperty1.IsHidden = num1 != 0;
                int num2 = !isAddAction ? 1 : 0;
                viewProperty1.IsReadOnly = num2 != 0;
                List<Policy> policyList;
                if (!isAddAction)
                {
                    policyList = new List<Policy>();
                }
                else
                {
                    policyList = new List<Policy>();
                    policyList.Add((Policy)new MaxLengthPolicy()
                    {
                        MaxLengthAllow = 50
                    });
                }
                viewProperty1.Policies = (IList<Policy>)policyList;
                properties1.Add(viewProperty1);
                List<ViewProperty> properties2 = view.Properties;
                ViewProperty viewProperty2 = new ViewProperty();
                string str3 = "DisplayName";
                viewProperty2.Name = str3;
                int num3 = 0;
                viewProperty2.IsRequired = num3 != 0;
                string str4 = (review != null ? review.DisplayName : (string)null) ?? string.Empty;
                viewProperty2.RawValue = (object)str4;
                int num4 = 0;
                viewProperty2.IsReadOnly = num4 != 0;
                properties2.Add(viewProperty2);
                List<ViewProperty> properties3 = view.Properties;
                ViewProperty viewProperty3 = new ViewProperty();
                string str5 = "Description";
                viewProperty3.Name = str5;
                int num5 = 0;
                viewProperty3.IsRequired = num5 != 0;
                string str6 = (review != null ? review.ReviewText : (string)null) ?? string.Empty;
                viewProperty3.RawValue = (object)str6;
                int num6 = 0;
                viewProperty3.IsReadOnly = num6 != 0;
                string str7 = "MultiLine";
                viewProperty3.UiType = str7;
                properties3.Add(viewProperty3);
            }
        }
    }
}