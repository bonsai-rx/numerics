using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Description("Creates a continuous univariate log-normal distribution.")]
    public class CreateLogNormal : Source<LogNormal>
    {
        public CreateLogNormal()
        {
            StdDev = 1;
        }

        [Description("The log-scale (μ) of the logarithm of the distribution.")]
        public double Mean { get; set; }

        [Description("The shape (σ) of the logarithm of the distribution.")]
        public double StdDev { get; set; }

        public override IObservable<LogNormal> Generate()
        {
            return Observable.Defer(() => Observable.Return(new LogNormal(Mean, StdDev)));
        }

        public IObservable<LogNormal> Generate(IObservable<Random> source)
        {
            return source.Select(random => new LogNormal(Mean, StdDev, random));
        }
    }
}
