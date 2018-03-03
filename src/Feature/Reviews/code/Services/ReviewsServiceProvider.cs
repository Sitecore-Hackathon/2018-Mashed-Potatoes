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
    }
}