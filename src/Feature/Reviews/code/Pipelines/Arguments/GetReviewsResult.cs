using System.Collections.Generic;

using MashedPotatoes.Feature.Reviews.Entities;

using Sitecore.Commerce.Services;

namespace MashedPotatoes.Feature.Reviews.Pipelines.Arguments
{
    public class GetReviewsResult : ServiceProviderResult
    {
        public IEnumerable<Review> Reviews { get; set; }
    }
}