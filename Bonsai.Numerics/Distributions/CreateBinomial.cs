using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    public class CreateBinomial : Source<Binomial>
    {
        public double P { get; set; }

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
