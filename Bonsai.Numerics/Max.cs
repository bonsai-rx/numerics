using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    public class Max : Transform<Tuple<double, double>, double>
    {
        public override IObservable<double> Process(IObservable<Tuple<double, double>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<float> Process(IObservable<Tuple<float, float>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<decimal> Process(IObservable<Tuple<decimal, decimal>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<long> Process(IObservable<Tuple<long, long>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<ulong> Process(IObservable<Tuple<ulong, ulong>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<int> Process(IObservable<Tuple<int, int>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<uint> Process(IObservable<Tuple<uint, uint>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<short> Process(IObservable<Tuple<short, short>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<ushort> Process(IObservable<Tuple<ushort, ushort>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<sbyte> Process(IObservable<Tuple<sbyte, sbyte>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }

        public IObservable<byte> Process(IObservable<Tuple<byte, byte>> source)
        {
            return source.Select(input => Math.Max(input.Item1, input.Item2));
        }
    }
}
