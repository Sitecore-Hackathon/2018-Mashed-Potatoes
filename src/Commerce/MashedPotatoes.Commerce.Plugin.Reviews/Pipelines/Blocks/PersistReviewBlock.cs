using MashedPotatoes.Commerce.Plugin.Reviews.Entities;

namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System.Threading.Tasks;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines a block
    /// </summary> 
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{Sitecore.Commerce.Plugin.Sample.SampleArgument,
    ///         Sitecore.Commerce.Plugin.Sample.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("Reviews.PersistReviewBlock")]
    public class PersistReviewBlock : PipelineBlock<Review, Review, CommercePipelineExecutionContext>
    {
        private readonly IPersistEntityPipeline persistEntityPipeline;

        public PersistReviewBlock(IPersistEntityPipeline persistEntityPipeline) : base()
        {
            this.persistEntityPipeline = persistEntityPipeline;
        }

        public override async Task<Review> Run(Review review, CommercePipelineExecutionContext context)
        {
            PersistReviewBlock persistReviewBlock = this;
            Condition.Requires(review).IsNotNull("The Review can not be null");
            await persistReviewBlock.persistEntityPipeline.Run(new PersistEntityArgument(review), context);

            return review;
        }
    }
}
