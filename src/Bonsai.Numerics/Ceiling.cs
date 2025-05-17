using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Calculates the smallest integer that is greater than or equal to the specified number.")]
    public class Ceiling : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Math.Ceiling);
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(Math.Ceiling);
        }
    }
}
