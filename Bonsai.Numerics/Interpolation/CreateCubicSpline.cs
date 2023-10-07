using System.Collections.Generic;
using System.ComponentModel;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Creates a sequence of piecewise natural cubic spline interpolation objects based on arbitrary points, with zero secondary derivatives at the boundaries.")]
    public class CreateCubicSpline : InterpolationBase
    {
        protected override IInterpolation CreateInterpolation(IEnumerable<double> points, IEnumerable<double> values)
        {
            return MathNet.Numerics.Interpolate.CubicSpline(points, values);
        }
    }
}
