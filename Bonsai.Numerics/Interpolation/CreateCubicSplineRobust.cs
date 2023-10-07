using System.Collections.Generic;
using System.ComponentModel;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Creates a sequence of piecewise cubic Akima spline interpolation objects based on arbitrary points. Akima splines are robust to outliers.")]
    public class CreateCubicSplineRobust : InterpolationBase
    {
        protected override IInterpolation CreateInterpolation(IEnumerable<double> points, IEnumerable<double> values)
        {
            return MathNet.Numerics.Interpolate.CubicSplineRobust(points, values);
        }
    }
}
