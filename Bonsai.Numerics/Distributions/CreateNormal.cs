using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Description("Creates a continuous univariate normal (gaussian) distribution.")]
    public class CreateNormal : Source<Normal>
    {
        public CreateNormal()
        {
            StdDev = 1;
        }

        [Description("The mean of the normal distribution.")]
        public double Mean { get; set; }

        [Description("The standard deviation of the normal distribution.")]
        public double StdDev { get; set; }

        public override IObservable<Normal> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Normal(Mean, StdDev)));
        }

        public IObservable<Normal> Generate(IObservable<Random> source)
        {
            return source.Select(random => new Normal(Mean, StdDev, random));
        }
    }
}
