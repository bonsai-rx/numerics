﻿using MathNet.Numerics.Distributions;
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

        public IObservable<int> Process<TSource>(IObservable<TSource> source, IObservable<IDiscreteDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.Select(input => d.Sample()));
        }

        public IObservable<double> Process<TSource>(IObservable<TSource> source, IObservable<IContinuousDistribution> distribution)
        {
            return distribution.FirstAsync().SelectMany(d => source.Select(input => d.Sample()));
        }
    }
}
