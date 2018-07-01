using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    public class Abs : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(x => Math.Abs(x));
        }

        public IObservable<float> Process(IObservable<float> source)
        {
            return source.Select(x => Math.Abs(x));
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(x => Math.Abs(x));
        }

        public IObservable<long> Process(IObservable<long> source)
        {
            return source.Select(x => Math.Abs(x));
        }

        public IObservable<int> Process(IObservable<int> source)
        {
            return source.Select(x => Math.Abs(x));
        }

        public IObservable<short> Process(IObservable<short> source)
        {
            return source.Select(x => Math.Abs(x));
        }

        public IObservable<sbyte> Process(IObservable<sbyte> source)
        {
            return source.Select(x => Math.Abs(x));
        }
    }
}
