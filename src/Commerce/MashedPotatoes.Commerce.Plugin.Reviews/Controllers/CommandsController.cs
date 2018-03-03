namespace MashedPotatoes.Commerce.Plugin.Reviews.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.OData;

    using MashedPotatoes.Commerce.Plugin.Reviews.Commands;

    using Microsoft.AspNetCore.Mvc;

    using Sitecore.Commerce.Core;

    public class CommandsController : CommerceController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.CommandsController" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
        }

        /// <summary>
        /// Samples the command.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="IActionResult"/></returns>
        [HttpPut]
        [Route("AddReview()")]
        public async Task<IActionResult> AddReview([FromBody] ODataActionParameters value)
        {
            if (value.ContainsKey(Constants.ProductId) && value.ContainsKey(Constants.ReviewText))
            {
                var productId = value[Constants.ProductId].ToString();
                var reviewText = value[Constants.ReviewText].ToString();
                var author = value[Constants.Author].ToString();

                int score;

                int.TryParse(value[Constants.Score].ToString(), out score);

                var command = this.Command<AddReviewCommand>();
                var result = await command.Process(this.CurrentContext, productId, reviewText, author, score);

                return new ObjectResult(command);
            }

            return new BadRequestObjectResult(value);
        }
    }
}

