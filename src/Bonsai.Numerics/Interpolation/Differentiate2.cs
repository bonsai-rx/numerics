using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Computes the sequence of interpolated second derivative values at each sample point.")]
    public class Differentiate2 : InterpolationOperator
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Interpolation.Differentiate2);
        }
    }
}
