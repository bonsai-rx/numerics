using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Description("Creates a discrete univariate categorical distribution.")]
    public class CreateCategorical : Source<Categorical>
    {
        static readonly double[] DefaultProbability = new[] { 1.0 };

        [TypeConverter(typeof(UnidimensionalArrayConverter))]
        [Description("An array of non-negative ratios representing the probability mass for each category. Normalization is not required.")]
        public double[] ProbabilityMass { get; set; }

        public override IObservable<Categorical> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Categorical(ProbabilityMass ?? DefaultProbability)));
        }

        public IObservable<Categorical> Generate(IObservable<Random> source)
        {
            return source.Select(random => new Categorical(ProbabilityMass ?? DefaultProbability, random));
        }
    }
}
