using MashedPotatoes.Feature.Reviews.Entities;

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
            string reviewText,
            string author,
            int score)
        {
            return new DataServiceActionQuerySingle<CommerceCommand>(
                container,
                container.BaseUri.OriginalString.Trim('/') + "/AddReview",
                new BodyOperationParameter(nameof(productId), productId),
                new BodyOperationParameter(nameof(reviewText), reviewText),
                new BodyOperationParameter(nameof(author), author),
                new BodyOperationParameter(nameof(score), score));
        }

        public static DataServiceQuery<Review> GetReviews(
            this Container container)
        {
            return container.CreateQuery<Review>("Reviews");
        }
    }
}