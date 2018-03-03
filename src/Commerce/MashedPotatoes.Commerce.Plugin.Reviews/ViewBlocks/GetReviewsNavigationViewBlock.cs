using System.Threading.Tasks;

using MashedPotatoes.Commerce.Plugin.Reviews.Policies;

using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Framework.Conditions;
using Sitecore.Framework.Pipelines;

namespace MashedPotatoes.Commerce.Plugin.Reviews.ViewBlocks
{

    [PipelineDisplayName("Promotions.block.GetPromotionsNavigationView")]
    public class GetReviewsNavigationViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        public GetReviewsNavigationViewBlock()
            : base((string)null)
        {
        }

        public override Task<EntityView> Run(EntityView entityView, CommercePipelineExecutionContext context)
        {
            Condition.Requires<EntityView>(entityView).IsNotNull<EntityView>(string.Format("{0}: The argument cannot be null.", (object)this.Name));
            EntityView entityView1 = new EntityView();
            string promotionsDashboard1 = context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard;
            entityView1.Name = promotionsDashboard1;
            string promotionsDashboard2 = context.GetPolicy<KnownReviewsViewsPolicy>().ReviewsDashboard;
            entityView1.ItemId = promotionsDashboard2;
            string str = "pencil";
            entityView1.Icon = str;
            int num = 4;
            entityView1.DisplayRank = num;
            EntityView entityView2 = entityView1;
            entityView.ChildViews.Add((Model)entityView2);
            return Task.FromResult<EntityView>(entityView);
        }
    }
}