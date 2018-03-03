namespace MashedPotatoes.Commerce.Plugin.Reviews.Policies
{
    using Sitecore.Commerce.Core;

    public class KnownReviewsViewsPolicy : Policy
    {
        public KnownReviewsViewsPolicy()
        {
            this.ReviewsDashboard = nameof(this.ReviewsDashboard);
            this.ReviewsList = nameof(this.ReviewsList);
            this.Summary = nameof(this.Summary);
            this.Details = nameof(this.Details);
            this.Master = nameof(this.Master);
        }

        public string ReviewsDashboard { get; set; }

        public string ReviewsList { get; set; }

        public string Details { get; set; }

        public string Summary { get; set; } ////?????

        public string Master { get; set; } ////?????
    }
}
