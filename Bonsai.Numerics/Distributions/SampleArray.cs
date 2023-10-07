using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Combinator]
    [Description("Draws a specified number of random samples from the input distribution into an array.")]
    public class SampleArray
    {
        public SampleArray()
        {
            Count = 1;
        }

        [Description("The number of random samples in each output array.")]
        public int Count { get; set; }

        int[] SampleDiscrete(IDiscreteDistribution distribution)
        {
            var result = new int[Count];
            distribution.Samples(result);
            return result;
        }

        double[] SampleContinuous(IContinuousDistribution distribution)
        {
            var result = new double[Count];
            distribution.Samples(result);
            return result;
        }

        public IObservable<int[]> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.Select(SampleDiscrete);
        }

        public IObservable<double[]> Process(IObservable<IContinuousDistribution> source)
        {
            return source.Select(SampleContinuous);
        }

        public IObservable<int[]> Process<TSource>(IObservable<TSource> source, IObservable<IDiscreteDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.Select(input => SampleDiscrete(d)));
        }

        public IObservable<double[]> Process<TSource>(IObservable<TSource> source, IObservable<IContinuousDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.Select(input => SampleContinuous(d)));
        }
    }
}
