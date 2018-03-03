namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Blocks
{
    using System;
    using System.Threading.Tasks;

    using MashedPotatoes.Commerce.Plugin.Reviews.Entities;
    using MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments;

    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;

    /// <summary>
    /// Defines a block
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{Sitecore.Commerce.Plugin.Sample.SampleArgument,
    ///         Sitecore.Commerce.Plugin.Sample.SampleEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("Sample.SampleBlock")]
    public class SampleBlock : PipelineBlock<SampleArgument, SampleEntity, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="arg">
        /// The SampleArgument argument.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="SampleEntity"/>.
        /// </returns>
        public override async Task<SampleEntity> Run(SampleArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");
            SampleEntity result = await Task.Run(() => new SampleEntity() { Id = Guid.NewGuid().ToString() });
            return result;
        }
    }
}
