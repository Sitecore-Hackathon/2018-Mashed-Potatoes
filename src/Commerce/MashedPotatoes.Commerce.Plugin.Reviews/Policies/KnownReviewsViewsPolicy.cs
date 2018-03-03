namespace MashedPotatoes.Commerce.Plugin.Reviews.Policies
{
    using Sitecore.Commerce.Core;

    public class KnownReviewsViewsPolicy : Policy
    {
        public KnownReviewsViewsPolicy()
        {
            this.Reviews = nameof(this.Reviews);
            this.ReviewsList = nameof(this.ReviewsList);
            this.Summary = nameof(this.Summary);
        }

        public string Reviews { get; set; }

        public string ReviewsList { get; set; }

        public string Summary { get; set; } 
    }
}
