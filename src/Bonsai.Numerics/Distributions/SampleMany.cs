using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
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

        IEnumerable<int> SampleDiscrete(IDiscreteDistribution distribution) => distribution.Samples().Take(Count);

        IEnumerable<double> SampleContinuous(IContinuousDistribution distribution) => distribution.Samples().Take(Count);

        public IObservable<int> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.SelectMany(SampleDiscrete);
        }

        public IObservable<double> Process(IObservable<IContinuousDistribution> source)
        {
            return source.SelectMany(SampleContinuous);
        }

        public IObservable<int> Process<TSource>(IObservable<TSource> source, IObservable<IDiscreteDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.SelectMany(input => SampleDiscrete(d)));
        }

        public IObservable<double> Process<TSource>(IObservable<TSource> source, IObservable<IContinuousDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.SelectMany(input => SampleContinuous(d)));
        }
    }
}
