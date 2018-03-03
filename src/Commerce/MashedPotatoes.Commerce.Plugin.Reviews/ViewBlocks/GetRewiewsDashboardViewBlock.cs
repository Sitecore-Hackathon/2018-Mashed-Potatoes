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
            : base((string)null)
        {
        }

        public override async Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            GetRewiewsDashboardViewBlock dashboardViewBlock = this;
            // ISSUE: explicit non-virtual call
            Condition.Requires<EntityView>(entityView).IsNotNull<EntityView>(string.Format("{0}: The argument cannot be null.", (object)/*__nonvirtual*/(dashboardViewBlock.Name)));
            EntityViewArgument entityViewArgument = context.CommerceContext.GetObjects<EntityViewArgument>().FirstOrDefault<EntityViewArgument>();
            if (string.IsNullOrEmpty(entityViewArgument?.ViewName) || !entityViewArgument.ViewName.Equals(context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard, StringComparison.OrdinalIgnoreCase))
                return entityView;
            return await Task.FromResult<EntityView>(entityView);
        }
    }
}