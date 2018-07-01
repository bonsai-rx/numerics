using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    public class Ceiling : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(x => Math.Ceiling(x));
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(x => Math.Ceiling(x));
        }
    }
}
