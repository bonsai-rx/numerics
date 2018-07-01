using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    public class CreateNormal : Source<Normal>
    {
        public CreateNormal()
        {
            StdDev = 1;
        }

        public double Mean { get; set; }

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
