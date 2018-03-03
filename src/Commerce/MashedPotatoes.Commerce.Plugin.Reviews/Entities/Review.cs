namespace Sitecore.Commerce.Plugin.Reviews.Entities
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.OData.Builder;
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// SampleEntity model.
    /// </summary>
    public class Review : CommerceEntity
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Reviews.SampleEntity" /> class.
        /// </summary>
        public Review()
        {
            this.Components = new List<Component>();
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = this.DateCreated;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Reviews.SampleEntity" /> class. 
        /// Public Constructor
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public Review(string id) : this()
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the review text.
        /// </summary>
        public string ReviewText { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the ProductReference.
        /// </summary>
        public EntityReference ProductReference { get; set; }

        ///// <summary>
        ///// Gets or sets the list of child components in the SampleEntity
        ///// </summary>
        //[Contained]
        //public IEnumerable<SampleComponent> ChildComponents { get; set; }
    }
}