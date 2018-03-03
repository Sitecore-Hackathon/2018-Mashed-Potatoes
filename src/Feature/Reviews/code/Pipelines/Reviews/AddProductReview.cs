using System;

using MashedPotatoes.Feature.Reviews.Pipelines.Arguments;

using Microsoft.OData.Client;

using Sitecore.Commerce.Core.Commands;
using Sitecore.Commerce.Engine;
using Sitecore.Commerce.Engine.Connect.Pipelines;
using Sitecore.Commerce.Pipelines;
using Sitecore.Commerce.ServiceProxy;
using Sitecore.Diagnostics;

namespace MashedPotatoes.Feature.Reviews.Pipelines.Reviews
{
    public class AddProductReview : PipelineProcessor
    {
        public override void Process(ServicePipelineArgs args)
        {
            var request = args.Request as AddReviewRequest;
            var result = args.Result as AddReviewResult;

            Assert.IsNotNull(request, nameof(request));
            Assert.IsNotNull(result, nameof(result));

            try
            {
                CommerceCommand command = Proxy.DoCommand(
                    this.GetContainer(request.ShopName, string.Empty)
                        .AddReview(request.ProductId, request.Text));

                result.HandleCommandMessages(command);
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