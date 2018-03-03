﻿namespace MashedPotatoes.Commerce.Plugin.Reviews.Pipelines.Arguments
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;

    /// <inheritdoc />
    /// <summary>
    /// Defines an argument
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.PipelineArgument" />
    public class SampleArgument : PipelineArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleArgument"/> class.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public SampleArgument(object parameter)
        {
            Condition.Requires(parameter).IsNotNull("The parameter can not be null");

            this.Parameter = parameter;
        }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public object Parameter { get; set; }
    }
}