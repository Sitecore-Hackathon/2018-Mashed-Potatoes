// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleArgument.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Reviews.Pipelines.Arguments
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;

    /// <inheritdoc />
    /// <summary>
    /// Defines an argument
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.PipelineArgument" />
    public class AddReviewArgument : PipelineArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddReviewArgument"/> class.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <param name="reviewText">
        /// The review text.
        /// </param>
        public AddReviewArgument(string productId, string reviewText)
        {
            Condition.Requires(productId).IsNotNull("The parameter can not be null");
            Condition.Requires(reviewText).IsNotNull("The parameter can not be null");

            this.ProductId = productId;
            this.ReviewsText = reviewText;
        }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the reviews text.
        /// </summary>
        public string ReviewsText { get; set; }
    }
}
