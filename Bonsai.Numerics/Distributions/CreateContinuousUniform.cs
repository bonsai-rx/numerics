using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    public class CreateContinuousUniform : Source<ContinuousUniform>
    {
        public CreateContinuousUniform()
        {
            Upper = 1;
        }

        public double Lower { get; set; }

        public double Upper { get; set; }

        public override IObservable<ContinuousUniform> Generate()
        {
            return Observable.Defer(() => Observable.Return(new ContinuousUniform(Lower, Upper)));
        }

        public IObservable<ContinuousUniform> Generate(IObservable<Random> source)
        {
            return source.Select(random => new ContinuousUniform(Lower, Upper, random));
        }
    }
}
