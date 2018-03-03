using System;
using System.Web.Mvc;

using MashedPotatoes.Feature.Reviews.Pipelines.Arguments;
using MashedPotatoes.Feature.Reviews.Services;

namespace MashedPotatoes.Feature.Reviews.Controllers
{
    public class ReviewsController : Controller
    {
        public ActionResult Reviews()
        {
            var reviewsServiceProvider = new ReviewsServiceProvider();

            // todo: work in progress here
            // but IT WORKS!!! 
            ////var addReviewRequest = new AddReviewRequest("test text", DateTime.Now, "author", 1, "6042060");

            ////AddReviewResult addReviewResult = reviewsServiceProvider.AddReview(addReviewRequest);
            ////if (!addReviewResult.Success)
            ////{
            ////    // todo: log here
            ////}

            return this.View();
        }
    }
}