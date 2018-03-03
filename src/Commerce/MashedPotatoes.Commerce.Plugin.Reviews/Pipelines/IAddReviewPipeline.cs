namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines
{
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the ISamplePipeline interface
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.IPipeline{MashedPotatoes.Commerce.Plugin.Reviews.SampleArgument,
    ///         MashedPotatoes.Commerce.Plugin.Reviews.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("AddReviewPipeline")]
    public interface IAddReviewPipeline : IPipeline<AddReviewArgument, Review, CommercePipelineExecutionContext>
    {
    }
}
