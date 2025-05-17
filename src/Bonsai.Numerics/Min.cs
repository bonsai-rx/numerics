using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Calculates the smallest of a set of values.")]
    public class Min : Transform<Tuple<double, double>, double>
    {
        public override IObservable<double> Process(IObservable<Tuple<double, double>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<float> Process(IObservable<Tuple<float, float>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<decimal> Process(IObservable<Tuple<decimal, decimal>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<long> Process(IObservable<Tuple<long, long>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<ulong> Process(IObservable<Tuple<ulong, ulong>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<int> Process(IObservable<Tuple<int, int>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<uint> Process(IObservable<Tuple<uint, uint>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<short> Process(IObservable<Tuple<short, short>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<ushort> Process(IObservable<Tuple<ushort, ushort>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<sbyte> Process(IObservable<Tuple<sbyte, sbyte>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<byte> Process(IObservable<Tuple<byte, byte>> source)
        {
            return source.Select(input => Math.Min(input.Item1, input.Item2));
        }

        public IObservable<TSource> Process<TSource>(IObservable<Tuple<TSource, TSource>> source)
        {
            var comparer = Comparer<TSource>.Default;
            return source.Select(input => comparer.Compare(input.Item1, input.Item2) < 0
                ? input.Item1
                : input.Item2);
        }

        public IObservable<TSource> Process<TSource>(IObservable<Tuple<TSource, TSource, TSource>> source)
        {
            var comparer = Comparer<TSource>.Default;
            return source.Select(input =>
            {
                var value = input.Item1;
                if (comparer.Compare(input.Item2, value) < 0) value = input.Item2;
                if (comparer.Compare(input.Item3, value) < 0) value = input.Item3;
                return value;
            });
        }

        public IObservable<TSource> Process<TSource>(IObservable<Tuple<TSource, TSource, TSource, TSource>> source)
        {
            var comparer = Comparer<TSource>.Default;
            return source.Select(input =>
            {
                var value = input.Item1;
                if (comparer.Compare(input.Item2, value) < 0) value = input.Item2;
                if (comparer.Compare(input.Item3, value) < 0) value = input.Item3;
                if (comparer.Compare(input.Item4, value) < 0) value = input.Item4;
                return value;
            });
        }

        public IObservable<TSource> Process<TSource>(IObservable<Tuple<TSource, TSource, TSource, TSource, TSource>> source)
        {
            var comparer = Comparer<TSource>.Default;
            return source.Select(input =>
            {
                var value = input.Item1;
                if (comparer.Compare(input.Item2, value) < 0) value = input.Item2;
                if (comparer.Compare(input.Item3, value) < 0) value = input.Item3;
                if (comparer.Compare(input.Item4, value) < 0) value = input.Item4;
                if (comparer.Compare(input.Item5, value) < 0) value = input.Item5;
                return value;
            });
        }

        public IObservable<TSource> Process<TSource>(IObservable<Tuple<TSource, TSource, TSource, TSource, TSource, TSource>> source)
        {
            var comparer = Comparer<TSource>.Default;
            return source.Select(input =>
            {
                var value = input.Item1;
                if (comparer.Compare(input.Item2, value) < 0) value = input.Item2;
                if (comparer.Compare(input.Item3, value) < 0) value = input.Item3;
                if (comparer.Compare(input.Item4, value) < 0) value = input.Item4;
                if (comparer.Compare(input.Item5, value) < 0) value = input.Item5;
                if (comparer.Compare(input.Item6, value) < 0) value = input.Item6;
                return value;
            });
        }

        public IObservable<TSource> Process<TSource>(IObservable<Tuple<TSource, TSource, TSource, TSource, TSource, TSource, TSource>> source)
        {
            var comparer = Comparer<TSource>.Default;
            return source.Select(input =>
            {
                var value = input.Item1;
                if (comparer.Compare(input.Item2, value) < 0) value = input.Item2;
                if (comparer.Compare(input.Item3, value) < 0) value = input.Item3;
                if (comparer.Compare(input.Item4, value) < 0) value = input.Item4;
                if (comparer.Compare(input.Item5, value) < 0) value = input.Item5;
                if (comparer.Compare(input.Item6, value) < 0) value = input.Item6;
                if (comparer.Compare(input.Item7, value) < 0) value = input.Item7;
                return value;
            });
        }

        public IObservable<double> Process(IObservable<IEnumerable<double>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<float> Process(IObservable<IEnumerable<float>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<decimal> Process(IObservable<IEnumerable<decimal>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<ulong> Process(IObservable<IEnumerable<ulong>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<long> Process(IObservable<IEnumerable<long>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<uint> Process(IObservable<IEnumerable<uint>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<int> Process(IObservable<IEnumerable<int>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<ushort> Process(IObservable<IEnumerable<ushort>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<short> Process(IObservable<IEnumerable<short>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<sbyte> Process(IObservable<IEnumerable<sbyte>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<byte> Process(IObservable<IEnumerable<byte>> source)
        {
            return source.Select(Enumerable.Min);
        }

        public IObservable<TSource> Process<TSource>(IObservable<IEnumerable<TSource>> source)
        {
            return source.Select(Enumerable.Min);
        }
    }
}
