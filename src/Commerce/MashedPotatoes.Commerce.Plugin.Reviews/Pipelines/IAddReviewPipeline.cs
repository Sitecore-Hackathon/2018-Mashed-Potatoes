namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines
{
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the IAddReviewPipeline interface
    /// </summary>
    [PipelineDisplayName("AddReviewPipeline")]
    public interface IAddReviewPipeline : IPipeline<AddReviewArgument, Review, CommercePipelineExecutionContext>
    {
    }
}
