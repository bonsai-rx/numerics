using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    public class CreateDiscreteUniform : Source<DiscreteUniform>
    {
        public CreateDiscreteUniform()
        {
            Upper = 1;
        }

        public int Lower { get; set; }

        public int Upper { get; set; }

        public override IObservable<DiscreteUniform> Generate()
        {
            return Observable.Defer(() => Observable.Return(new DiscreteUniform(Lower, Upper)));
        }

        public IObservable<DiscreteUniform> Generate(IObservable<Random> source)
        {
            return source.Select(random => new DiscreteUniform(Lower, Upper, random));
        }
    }
}
