using Microsoft.OData.Client;

using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Engine;

namespace MashedPotatoes.Feature.Reviews
{
    public static class ContainerExtensions
    {
        public static DataServiceActionQuerySingle<CommerceCommand> AddReview(
            this Container container,
            string productId,
            string reviewText)
        {
            return new DataServiceActionQuerySingle<CommerceCommand>(
                container,
                container.BaseUri.OriginalString.Trim('/') + "/AddReview",
                new BodyOperationParameter(nameof(productId), productId),
                new BodyOperationParameter(nameof(reviewText), reviewText));
        }
    }
}