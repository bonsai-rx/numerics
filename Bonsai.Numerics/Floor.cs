using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    [Description("Calculates the largest integer that is less than or equal to the specified number.")]
    public class Floor : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Math.Floor);
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(Math.Floor);
        }
    }
}
