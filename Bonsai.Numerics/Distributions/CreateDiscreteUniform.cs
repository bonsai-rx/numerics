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
    [Description("Creates a discrete univariate uniform distribution.")]
    public class CreateDiscreteUniform : Source<DiscreteUniform>
    {
        public CreateDiscreteUniform()
        {
            Upper = 1;
        }

        [Description("The lower bound of the uniform distribution.")]
        public int Lower { get; set; }

        [Description("The upper bound of the uniform distribution.")]
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
