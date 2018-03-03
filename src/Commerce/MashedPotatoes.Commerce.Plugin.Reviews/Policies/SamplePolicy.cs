namespace MashedPotatoes.Commerce.Plugin.Reviews.Policies
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a policy
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.Policy" />
    public class SamplePolicy : Policy
    {
        /// <summary>
        /// Gets or sets the sample entity display.
        /// </summary>
        /// <value>
        /// The sample entity display.
        /// </value>
        public string SampleEntityDisplay { get; set; }
    }
}
