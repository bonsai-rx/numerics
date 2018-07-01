using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    [Description("Creates a discrete univariate binomial distribution.")]
    public class CreateBinomial : Source<Binomial>
    {
        [Range(0, 1)]
        [Description("The success probability in each trial.")]
        public double P { get; set; }

        [Description("The number of trials.")]
        public int N { get; set; }

        public override IObservable<Binomial> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Binomial(P, N)));
        }

        public IObservable<Binomial> Generate(IObservable<Random> source)
        {
            return source.Select(random => new Binomial(P, N, random));
        }
    }
}
