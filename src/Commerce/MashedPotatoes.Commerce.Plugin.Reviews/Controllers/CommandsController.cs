// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandsController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace MashedPotatoes.Commerce.Plugin.Reviews.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.OData;

    using MashedPotatoes.Commerce.Plugin.Reviews.Commands;

    using Microsoft.AspNetCore.Mvc;

    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a controller
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.CommerceController" />
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
            var productId = value[Constants.ProductId].ToString();
            var reviewText = value[Constants.ReviewText].ToString();

            var command = this.Command<AddReviewCommand>();
            var result = await command.Process(this.CurrentContext, productId, reviewText);

            return new ObjectResult(command);
        }
    }
}

