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
    [Description("Creates a continuous univariate uniform distribution.")]
    public class CreateContinuousUniform : Source<ContinuousUniform>
    {
        public CreateContinuousUniform()
        {
            Upper = 1;
        }

        [Description("The lower bound of the uniform distribution.")]
        public double Lower { get; set; }

        [Description("The upper bound of the uniform distribution.")]
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
