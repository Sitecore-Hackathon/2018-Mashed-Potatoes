using Sitecore.Commerce.Core;

namespace MashedPotatoes.Commerce.Plugin.Reviews.Policies
{
    public class KnownReviewsActionsPolicy : Policy
    {
        public KnownReviewsActionsPolicy()
        {
            this.AddReview = nameof(this.AddReview);
            this.EditReview = nameof(this.EditReview);
            this.PaginateReviews = nameof(this.PaginateReviews);
        }

        public string AddReview { get; set; }

        public string EditReview { get; set; }

        public string PaginateReviews { get; set; }
    }
}