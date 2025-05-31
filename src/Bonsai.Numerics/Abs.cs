using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Calculates the absolute value of a number.")]
    public class Abs : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Math.Abs);
        }

        public IObservable<float> Process(IObservable<float> source)
        {
            return source.Select(Math.Abs);
        }

        public IObservable<decimal> Process(IObservable<decimal> source)
        {
            return source.Select(Math.Abs);
        }

        public IObservable<long> Process(IObservable<long> source)
        {
            return source.Select(Math.Abs);
        }

        public IObservable<int> Process(IObservable<int> source)
        {
            return source.Select(Math.Abs);
        }

        public IObservable<short> Process(IObservable<short> source)
        {
            return source.Select(Math.Abs);
        }

        public IObservable<sbyte> Process(IObservable<sbyte> source)
        {
            return source.Select(Math.Abs);
        }
    }
}
