using System.Collections.Generic;
using System.ComponentModel;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Creates a sequence of Floater-Hormann rational pole-free interpolation objects based on arbitrary points.")]
    public class CreateRationalWithoutPoles : InterpolationBase
    {
        protected override IInterpolation CreateInterpolation(IEnumerable<double> points, IEnumerable<double> values)
        {
            return MathNet.Numerics.Interpolate.RationalWithoutPoles(points, values);
        }
    }
}
