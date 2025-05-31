using System.ComponentModel;
using System.Xml.Serialization;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    public abstract class InterpolationOperator : Transform<double, double>
    {
        [XmlIgnore]
        [Description("Specifies the interpolation object used to evaluate the sequence of sample points.")]
        public IInterpolation Interpolation { get; set; }
    }
}
