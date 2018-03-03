using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Policies;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{

    [PipelineDisplayName("Reviews.block.GetReviewsNavigationView")]
    public class GetReviewsNavigationViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        public GetReviewsNavigationViewBlock()
            : base(null)
        {
        }

        public override Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            Condition.Requires(entityView).IsNotNull($"{this.Name}: The argument cannot be null.");
            EntityView entityView1 = new EntityView();
            string promotionsDashboard1 = context.GetPolicy<KnownReviewsViewsPolicy>().Reviews;
            entityView1.Name = promotionsDashboard1;
            string promotionsDashboard2 = context.GetPolicy<KnownReviewsViewsPolicy>().Reviews;
            entityView1.ItemId = promotionsDashboard2;
            string str = "pencil";
            entityView1.Icon = str;
            int num = 8;
            entityView1.DisplayRank = num;
            entityView1.DisplayName = "Reviews";
            EntityView entityView2 = entityView1;
            entityView.ChildViews.Add(entityView2);
            return Task.FromResult(entityView);
        }
    }
}