using Sitecore.Commerce.Core;

namespace MashedPotatoes.Commerce.Plugin.Reviews.Policies
{
    public class KnownReviewsActionsPolicy : Policy
    {
        public KnownReviewsActionsPolicy()
        {
            this.AddReview = nameof(this.AddReview);
            this.DeleteReview = nameof(this.DeleteReview);
        }

        public string AddReview { get; set; }

        public string DeleteReview { get; set; }
    }
}