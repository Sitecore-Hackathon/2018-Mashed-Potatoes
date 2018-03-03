using MashedPotatoes.Commerce.Plugin.Reviews.Entities;

namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System;
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
        private readonly IPersistEntityPipeline _persistEntityPipeline;

        public PersistReviewBlock(IPersistEntityPipeline persistEntityPipeline) : base()
        {
            this._persistEntityPipeline = persistEntityPipeline;
        }

        public override async Task<Review> Run(Review review, CommercePipelineExecutionContext context)
        {
            PersistReviewBlock persistCouponBlock = this;
            Condition.Requires(review).IsNotNull("The Coupon can not be null");
            PersistEntityArgument persistEntityArgument = await persistCouponBlock._persistEntityPipeline.Run(new PersistEntityArgument(review), context);
            return review;
        }
    }
}
