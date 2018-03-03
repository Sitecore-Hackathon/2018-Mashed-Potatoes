// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SamplePipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Reviews.Pipelines
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Reviews.Entities;
    using Sitecore.Commerce.Plugin.Reviews.Pipelines.Arguments;
    using Sitecore.Framework.Pipelines;

    /// <inheritdoc />
    /// <summary>
    ///  Defines the SamplePipeline pipeline.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Commerce.Core.CommercePipeline{Sitecore.Commerce.Plugin.Reviews.SampleArgument,
    ///         Sitecore.Commerce.Plugin.Reviews.SampleEntity}
    ///     </cref>
    /// </seealso>
    /// <seealso cref="T:Sitecore.Commerce.Plugin.Reviews.ISamplePipeline" />
    public class AddReviewPipeline : CommercePipeline<AddReviewArgument, Review>, IAddReviewPipeline
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Reviews.SamplePipeline" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public AddReviewPipeline(IPipelineConfiguration<IAddReviewPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

