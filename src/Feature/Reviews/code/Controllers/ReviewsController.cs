using System.Web.Mvc;

namespace MashedPotatoes.Feature.Reviews.Controllers
{
    public class ReviewsController : Controller
    {
        public ActionResult Reviews()
        {
            return this.View();
        }
    }
}