using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

using Sitecore.Commerce.Plugin.Catalog;

namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System.Threading.Tasks;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    [PipelineDisplayName("Reviews.InsureSellableItemBlock")]
    public class InsureSellableItemBlock : PipelineBlock<AddReviewArgument, AddReviewArgument, CommercePipelineExecutionContext>
    {
        private readonly IFindEntityPipeline findEntityPipeline;

        public InsureSellableItemBlock(IFindEntityPipeline findEntityPipeline) : base()
        {
            this.findEntityPipeline = findEntityPipeline;
        }

        public override async Task<AddReviewArgument> Run(AddReviewArgument args, CommercePipelineExecutionContext context)
        {
            InsureSellableItemBlock insureSellableItemBlock = this;

            Condition.Requires(args).IsNotNull<AddReviewArgument>(string.Format("{0}: The block argument cannot be null.", insureSellableItemBlock.Name));

            FindEntityArgument findEntityArgument = new FindEntityArgument(typeof(SellableItem), args.ProductId.EnsurePrefix(CommerceEntity.IdPrefix<SellableItem>()), false);

            SellableItem productItem = await insureSellableItemBlock.findEntityPipeline.Run(findEntityArgument, context) as SellableItem;

            args.Product = productItem;

            return args;
        } 
    }
}
