using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    public class Atan : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(x => Math.Atan(x));
        }

        public IObservable<double> Process(IObservable<Tuple<double, double>> source)
        {
            return source.Select(input => Math.Atan2(input.Item1, input.Item2));
        }
    }
}
