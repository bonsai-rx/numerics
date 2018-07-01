using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    public class CreateExponential : Source<Exponential>
    {
        public double Rate { get; set; }

        public override IObservable<Exponential> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Exponential(Rate)));
        }

        public IObservable<Exponential> Generate(IObservable<Random> source)
        {
            return source.Select(random => new Exponential(Rate, random));
        }
    }
}
