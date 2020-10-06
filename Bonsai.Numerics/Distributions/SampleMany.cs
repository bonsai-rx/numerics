using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Combinator]
    [Description("Draws multiple random samples from the input distribution.")]
    public class SampleMany
    {
        public SampleMany()
        {
            Count = 1;
        }

        [Description("The number of random samples to draw.")]
        public int Count { get; set; }

        public IObservable<int> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.SelectMany(distribution => distribution.Samples().Take(Count));
        }

        public IObservable<double> Process(IObservable<IContinuousDistribution> source)
        {
            return source.SelectMany(distribution => distribution.Samples().Take(Count));
        }
    }
}
