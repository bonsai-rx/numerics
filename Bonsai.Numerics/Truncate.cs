using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    [Description("Calculates the integral part of the specified number.")]
    public class Truncate : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(x => Math.Truncate(x));
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(x => Math.Truncate(x));
        }
    }
}
