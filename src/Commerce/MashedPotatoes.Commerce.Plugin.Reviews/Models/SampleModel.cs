namespace MashedPotatoes.Commerce.Plugin.Reviews.Models
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a model
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.Model" />
    public class SampleModel : Model
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Models.SampleModel" /> class.
        /// </summary>
        public SampleModel()
        {
            this.Id = string.Empty;
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
