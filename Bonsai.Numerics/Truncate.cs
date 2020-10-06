using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Calculates the integral part of the specified number.")]
    public class Truncate : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Math.Truncate);
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(Math.Truncate);
        }
    }
}
