using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    public class CreatePoisson : Source<Poisson>
    {
        public double Lambda { get; set; }

        public override IObservable<Poisson> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Poisson(Lambda)));
        }

        public IObservable<Poisson> Generate(IObservable<Random> source)
        {
            return source.Select(random => new Poisson(Lambda, random));
        }
    }
}
