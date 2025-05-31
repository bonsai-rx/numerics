using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Calculates a value indicating the sign of the specified number.")]
    public class Sign : Transform<double, int>
    {
        public override IObservable<int> Process(IObservable<double> source)
        {
            return source.Select(Math.Sign);
        }

        public IObservable<int> Process(IObservable<float> source)
        {
            return source.Select(Math.Sign);
        }

        public IObservable<int> Process(IObservable<decimal> source)
        {
            return source.Select(Math.Sign);
        }

        public IObservable<int> Process(IObservable<long> source)
        {
            return source.Select(Math.Sign);
        }

        public IObservable<int> Process(IObservable<int> source)
        {
            return source.Select(Math.Sign);
        }

        public IObservable<int> Process(IObservable<short> source)
        {
            return source.Select(Math.Sign);
        }

        public IObservable<int> Process(IObservable<sbyte> source)
        {
            return source.Select(Math.Sign);
        }
    }
}
