using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Draws a random sample from the input distribution.")]
    public class Sample
    {
        public IObservable<int> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.Select(distribution => distribution.Sample());
        }

        public IObservable<double> Process(IObservable<IContinuousDistribution> source)
        {
            return source.Select(distribution => distribution.Sample());
        }
    }
}
