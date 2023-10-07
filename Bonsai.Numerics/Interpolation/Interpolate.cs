using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Computes the sequence of interpolated values at each sample point.")]
    public class Interpolate : InterpolationOperator
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Interpolation.Interpolate);
        }
    }
}
