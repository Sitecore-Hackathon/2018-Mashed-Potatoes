using MashedPotatoes.Commerce.Plugin.Reviews.Entities;

namespace MashedPotatoes.Commerce.Plugin.Reviews.Controllers
{
    using System;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Commands;

    using Microsoft.AspNetCore.Mvc;

    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Defines a controller
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.CommerceController" />
    [Microsoft.AspNetCore.OData.EnableQuery]
    [Route("api/Sample")]
    public class SampleController : CommerceController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Controllers.SampleController" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public SampleController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment) : base(serviceProvider, globalEnvironment)
        {
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="IActionResult"/></returns>
        [HttpGet]
        [Route("(Id={id})")]
        [Microsoft.AspNetCore.OData.EnableQuery]
        public async Task<IActionResult> Get(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            Task<SampleEntity> process = this.Command<SampleCommand>()?.Process(this.CurrentContext, id);
            if (process == null)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            SampleEntity result = await process;
            if (result == null)
            {
                return this.NotFound();
            }

            return new ObjectResult(result);
        }
    }
}
