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
    ///         Sitecore.Framework.Pipelines.IPipeline{Sitecore.Commerce.Plugin.Sample.SampleArgument,
    ///         Sitecore.Commerce.Plugin.Sample.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("SamplePipeline")]
    public interface ISamplePipeline : IPipeline<SampleArgument, SampleEntity, CommercePipelineExecutionContext>
    {
    }
}
