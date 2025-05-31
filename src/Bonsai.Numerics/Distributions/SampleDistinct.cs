using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Combinator]
    [Description("Draws multiple distinct random samples from the input distribution.")]
    public class SampleDistinct
    {
        public SampleDistinct()
        {
            Count = 1;
        }

        [Description("The number of distinct random samples to draw.")]
        public int Count { get; set; }

        IEnumerable<int> SampleDiscrete(IDiscreteDistribution distribution) => distribution.Samples().Distinct().Take(Count);

        public IObservable<int> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.SelectMany(SampleDiscrete);
        }

        public IObservable<int> Process<TSource>(IObservable<TSource> source, IObservable<IDiscreteDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.SelectMany(input => SampleDiscrete(d)));
        }
    }
}
