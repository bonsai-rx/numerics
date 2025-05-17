using System.Collections.Generic;
using System.ComponentModel;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Creates a sequence of piecewise cubic monotone spline interpolation objects based on arbitrary points. This is a shape-preserving spline with continuous first derivative.")]
    public class CreateCubicSplineMonotone : InterpolationBase
    {
        protected override IInterpolation CreateInterpolation(IEnumerable<double> points, IEnumerable<double> values)
        {
            return MathNet.Numerics.Interpolate.CubicSplineMonotone(points, values);
        }
    }
}
