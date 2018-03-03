using MashedPotatoes.Commerce.Plugin.Reviews.Entities;

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
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Controllers.CommandsController" /> class.
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
        [Route("SampleCommand()")]
        public async Task<IActionResult> SampleCommand([FromBody] ODataActionParameters value)
        {
            string id = value["Id"].ToString();
            var command = this.Command<SampleCommand>();
            SampleEntity result = await command.Process(this.CurrentContext, id);

            return new ObjectResult(command);
        }
    }
}

