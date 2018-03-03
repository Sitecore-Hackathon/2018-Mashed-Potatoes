namespace MashedPotatoes.Commerce.Plugin.Reviews.Commands
{
    using System;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;

    /// <inheritdoc />
    /// <summary>
    /// Defines the SampleCommand command.
    /// </summary>
    public class SampleCommand : CommerceCommand
    {
        private readonly ISamplePipeline pipeline;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MashedPotatoes.Commerce.Plugin.Reviews.Commands.SampleCommand" /> class.
        /// </summary>
        /// <param name="pipeline">
        /// The pipeline.
        /// </param>
        /// <param name="serviceProvider">The service provider</param>
        public SampleCommand(ISamplePipeline pipeline, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.pipeline = pipeline;
        }

        /// <summary>
        /// The process of the command
        /// </summary>
        /// <param name="commerceContext">
        /// The commerce context
        /// </param>
        /// <param name="parameter">
        /// The parameter for the command
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<SampleEntity> Process(CommerceContext commerceContext, object parameter)
        {
            using (Activity activity = CommandActivity.Start(commerceContext, this))
            {
                var arg = new SampleArgument(parameter);
                SampleEntity result = await this.pipeline.Run(arg, new CommercePipelineExecutionContextOptions(commerceContext));

                return result;
            }
        }
    }
}