using System;
using System.Linq;
using System.Web.Mvc;

using MashedPotatoes.Feature.Reviews.Models;
using MashedPotatoes.Feature.Reviews.Pipelines.Arguments;
using MashedPotatoes.Feature.Reviews.Services;

using Sitecore.Commerce.XA.Foundation.Common;

namespace MashedPotatoes.Feature.Reviews.Controllers
{
    // todo: update to SXA way
    // todo: implement proper views and form POST
    // todo: add exception handling
    public class ReviewsController : Controller
    {
        private readonly ISiteContext siteContext;

        public ReviewsController(ISiteContext siteContext)
        {
            this.siteContext = siteContext;
        }

        public ActionResult Reviews()
        {
            var reviewsServiceProvider = new ReviewsServiceProvider();

            var getReviewsRequest = new GetReviewsRequest();

            GetReviewsResult getReviewsResult = reviewsServiceProvider.GetReviews(getReviewsRequest);
            if (!getReviewsResult.Success)
            {
                // todo: log here
            }

            // todo: investigate this
            //var model = getReviewsResult.Reviews
            //    .Select(review => new Review
            //                          {
            //                              Author = review.Author, 
            //                              Score = review.Score, 
            //                              Text = review.Text
            //                          })
            //    .ToList();

            return this.View();
        }

        public ActionResult SubmitReview()
        {
            var review = new Review
                             {
                                 ProductId = this.siteContext.CurrentCatalogItem.Name
                             };

            return this.View(review);
        }

        [HttpPost]
        public ActionResult SubmitReview(Review review)
        {
            var reviewsServiceProvider = new ReviewsServiceProvider();

            var addReviewRequest = new AddReviewRequest(review.Text, DateTime.Now, review.Author, review.Score, review.ProductId);

            AddReviewResult addReviewResult = reviewsServiceProvider.AddReview(addReviewRequest);
            if (!addReviewResult.Success)
            {
                // todo: log here
            }

            this.Response.Redirect(new Uri(this.Request.UrlReferrer.ToString()).ToString());

            return null;
        }
    }
}