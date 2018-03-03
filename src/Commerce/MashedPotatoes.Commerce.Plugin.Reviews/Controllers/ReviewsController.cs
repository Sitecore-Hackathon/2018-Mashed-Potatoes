namespace MashedPotatoes.Commerce.Plugin.Reviews.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.OData;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;

    [EnableQuery]
    [Route("api/Reviews")]
    public class ReviewsController : CommerceController
    {
        public ReviewsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
          : base(serviceProvider, globalEnvironment)
        {
        }

        [EnableQuery]
        [Route("Reviews")]
        public async Task<IEnumerable<Review>> Get()
        {
            ReviewsController reviewsController = this;
            CommerceList<Review> commerceList = await reviewsController.Command<FindEntitiesInListCommand>().Process<Review>(reviewsController.CurrentContext, CommerceEntity.ListName<Review>(), 0, int.MaxValue);
            return (IEnumerable<Review>)((commerceList != null ? commerceList.Items.ToList<Review>() : (List<Review>)null) ?? new List<Review>());
        }

        [HttpGet]
        [Route("(Id={id})")]
        [EnableQuery]
        public async Task<IActionResult> Get(string id)
        {
            ReviewsController reviewsController = this;

            if (!reviewsController.ModelState.IsValid || string.IsNullOrEmpty(id))
            {
                return reviewsController.NotFound();
            }

            string entityId = $"{(object)CommerceEntity.IdPrefix<Review>()}{(object)id}";

            CommerceEntity commerceEntity = await reviewsController.Command<FindEntityCommand>().Process(reviewsController.CurrentContext, typeof(Review), entityId, false);
            return commerceEntity != null ? (IActionResult)new ObjectResult((object)(commerceEntity as Review)) : (IActionResult)reviewsController.NotFound();
        }
    }
}
