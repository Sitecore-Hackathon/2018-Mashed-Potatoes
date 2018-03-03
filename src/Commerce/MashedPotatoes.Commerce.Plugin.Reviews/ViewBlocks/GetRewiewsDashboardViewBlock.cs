using System;
using System.Linq;
using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Policies;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{
    [PipelineDisplayName("Rewiews.block.GetRewiewsDashboardView")]
    public class GetRewiewsDashboardViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        public GetRewiewsDashboardViewBlock()
            : base(null)
        {
        }

        public override async Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            GetRewiewsDashboardViewBlock dashboardViewBlock = this;

            Condition.Requires(entityView)
                .IsNotNull($"{dashboardViewBlock.Name}: The argument cannot be null.");
            EntityViewArgument entityViewArgument =
                context.CommerceContext.GetObjects<EntityViewArgument>().FirstOrDefault();
            if (string.IsNullOrEmpty(entityViewArgument?.ViewName) || !entityViewArgument.ViewName.Equals(
                    context.GetPolicy<KnownReviewsViewsPolicy>().Reviews,
                    StringComparison.OrdinalIgnoreCase))
            {
                return entityView;
            }

            return await Task.FromResult(entityView);
        }
    }
}