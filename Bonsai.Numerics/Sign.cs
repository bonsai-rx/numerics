using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    public class Sign : Transform<double, int>
    {
        public override IObservable<int> Process(IObservable<double> source)
        {
            return source.Select(x => Math.Sign(x));
        }

        public IObservable<int> Process(IObservable<float> source)
        {
            return source.Select(x => Math.Sign(x));
        }

        public IObservable<int> Process(IObservable<decimal> source)
        {
            return source.Select(x => Math.Sign(x));
        }

        public IObservable<int> Process(IObservable<long> source)
        {
            return source.Select(x => Math.Sign(x));
        }

        public IObservable<int> Process(IObservable<int> source)
        {
            return source.Select(x => Math.Sign(x));
        }

        public IObservable<int> Process(IObservable<short> source)
        {
            return source.Select(x => Math.Sign(x));
        }

        public IObservable<int> Process(IObservable<sbyte> source)
        {
            return source.Select(x => Math.Sign(x));
        }
    }
}
