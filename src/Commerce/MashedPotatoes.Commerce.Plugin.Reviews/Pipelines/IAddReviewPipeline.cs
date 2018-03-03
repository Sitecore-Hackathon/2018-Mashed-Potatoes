// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISamplePipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Reviews.Pipelines
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Reviews.Entities;
    using Sitecore.Commerce.Plugin.Reviews.Pipelines.Arguments;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines the ISamplePipeline interface
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.IPipeline{Sitecore.Commerce.Plugin.Reviews.SampleArgument,
    ///         Sitecore.Commerce.Plugin.Reviews.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("AddReviewPipeline")]
    public interface IAddReviewPipeline : IPipeline<AddReviewArgument, Review, CommercePipelineExecutionContext>
    {
    }
}
