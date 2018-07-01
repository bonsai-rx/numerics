using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    [Description("Calculates the hyperbolic tangent of the specified angle, in radians.")]
    public class Tanh : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(x => Math.Tanh(x));
        }
    }
}
