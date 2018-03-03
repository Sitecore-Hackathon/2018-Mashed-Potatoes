namespace MashedPotatoes.Commerce.Plugin.Reviews.Entities
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// SampleEntity model.
    /// </summary>
    public class Review : CommerceEntity
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.SampleEntity" /> class.
        /// </summary>
        public Review()
        {
            this.Components = new List<Component>();
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = this.DateCreated;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.SampleEntity" /> class. 
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
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the author text.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        public int Score  { get; set; }

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