namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines
{
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Microsoft.Extensions.Logging;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;

    /// <inheritdoc />
    /// <summary>
    ///  Defines the SamplePipeline pipeline.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Commerce.Core.CommercePipeline{Sitecore.Commerce.Plugin.Sample.SampleArgument,
    ///         Sitecore.Commerce.Plugin.Sample.SampleEntity}
    ///     </cref>
    /// </seealso>
    /// <seealso cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.ISamplePipeline" />
    public class SamplePipeline : CommercePipeline<SampleArgument, SampleEntity>, ISamplePipeline
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.SamplePipeline" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public SamplePipeline(IPipelineConfiguration<ISamplePipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

