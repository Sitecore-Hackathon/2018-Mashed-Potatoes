﻿namespace MashedPotatoes.Commerce.Plugin.Reviews.Entities
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.OData.Builder;

    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// SampleEntity model.
    /// </summary>
    public class SampleEntity : CommerceEntity
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Entities.SampleEntity" /> class.
        /// </summary>
        public SampleEntity()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = this.DateCreated;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Entities.SampleEntity" /> class. 
        /// Public Constructor
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public SampleEntity(string id) : this()
        {
            this.Id = id;
        }
    }
}