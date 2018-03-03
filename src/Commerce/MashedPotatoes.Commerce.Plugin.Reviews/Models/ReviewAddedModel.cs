// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleModel.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Reviews.Models
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a model
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.Model" />
    public class ReviewAddedModel : Model
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Reviews.SampleModel" /> class.
        /// </summary>
        public ReviewAddedModel(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; private set; }
    }
}
