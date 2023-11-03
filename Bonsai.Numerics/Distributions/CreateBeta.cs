using MathNet.Numerics.Distributions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Distributions
{
    [Description("Creates a continuous univariate Beta distribution.")]
    public class CreateBeta : Source<Beta>
    {
        [Description("The alpha shape parameter of the Beta distribution. Must be greater than 0.")]
        public double Alpha { get; set; }

        [Description("The beta shape parameter of the Beta distribution. Must be greater than 0.")]
        public double Beta { get; set; }

        public override IObservable<Beta> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Beta(Alpha, Beta)));
        }

        public IObservable<Beta> Generate(IObservable<Random> source)
        {
            return source.Select(random => new Beta(Alpha, Beta, random));
        }
    }
}
