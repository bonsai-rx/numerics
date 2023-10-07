using System.Collections.Generic;
using System.ComponentModel;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    [Description("Creates a sequence of barycentric polynomial interpolation objects where the given sample points are equidistant.")]
    public class CreatePolynomialEquidistant : InterpolationBase
    {
        protected override IInterpolation CreateInterpolation(IEnumerable<double> points, IEnumerable<double> values)
        {
            return MathNet.Numerics.Interpolate.PolynomialEquidistant(points, values);
        }
    }
}
