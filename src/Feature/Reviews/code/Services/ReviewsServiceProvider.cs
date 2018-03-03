using MashedPotatoes.Feature.Reviews.Pipelines.Arguments;

using Sitecore.Commerce.Services.Carts;

namespace MashedPotatoes.Feature.Reviews.Services
{
    public class ReviewsServiceProvider : CartServiceProvider
    {
        public virtual AddReviewResult AddReview(AddReviewRequest request)
        {
            return this.RunPipeline<AddReviewRequest, AddReviewResult>(Constants.PipelineNames.AddProductReview, request);
        }

        public virtual GetReviewsResult GetReviews(GetReviewsRequest request)
        {
            return this.RunPipeline<GetReviewsRequest, GetReviewsResult>(Constants.PipelineNames.GetProductReviews, request);
        }
    }
}