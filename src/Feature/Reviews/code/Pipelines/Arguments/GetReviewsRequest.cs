using Sitecore.Commerce.Services;

namespace MashedPotatoes.Feature.Reviews.Pipelines.Arguments
{
    public class GetReviewsRequest : ServiceProviderRequest
    {
        public string ShopName { get; set; }
    }
}