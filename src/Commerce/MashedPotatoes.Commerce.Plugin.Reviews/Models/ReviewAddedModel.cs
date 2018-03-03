namespace MashedPotatoes.Commerce.Plugin.Reviews.Models
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a ReviewAddedModel model
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.Model" />
    public class ReviewAddedModel : Model
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.ReviewAddedModel" /> class.
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
