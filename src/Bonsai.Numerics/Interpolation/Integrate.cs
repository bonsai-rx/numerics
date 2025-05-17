using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Computes the sequence of interpolated indefinite integral values at each sample point.")]
    public class Integrate : InterpolationOperator
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select((Func<double, double>)Interpolation.Integrate);
        }
    }
}
