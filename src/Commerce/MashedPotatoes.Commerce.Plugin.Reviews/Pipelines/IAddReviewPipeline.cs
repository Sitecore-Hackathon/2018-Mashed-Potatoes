// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISamplePipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines
{
    using Sitecore.Commerce.Core;
    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;
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
