using System;
using System.Collections.Generic;

using MashedPotatoes.Feature.Reviews.Entities;
using MashedPotatoes.Feature.Reviews.Pipelines.Arguments;

using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Engine.Connect.Pipelines;
using Sitecore.Commerce.Pipelines;
using Sitecore.Commerce.ServiceProxy;
using Sitecore.Diagnostics;

namespace MashedPotatoes.Feature.Reviews.Pipelines.Reviews
{
    public class GetProductReviews : PipelineProcessor
    {
        public override void Process(ServicePipelineArgs args)
        {
            var request = args.Request as GetReviewsRequest;
            var result = args.Result as GetReviewsResult;

            Assert.IsNotNull(request, nameof(request));
            Assert.IsNotNull(result, nameof(result));

            try
            {
                IEnumerable<Review> reviews = Proxy.Execute<Review>(this.GetContainer(request.ShopName, string.Empty).GetReviews());
                result.Reviews = reviews;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex, this);
                result.Success = false;
            }

            base.Process(args);
        }
    }
}