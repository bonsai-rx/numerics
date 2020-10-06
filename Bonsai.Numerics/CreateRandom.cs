using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Creates a random number generator using either a fixed, or time-dependent, seed.")]
    public class CreateRandom : Source<Random>
    {
        [Description("An optional number used to calculate the starting value for the pseudo-random sequence. If no seed is specifed, a time-dependent value is used.")]
        public int? Seed { get; set; }

        public override IObservable<Random> Generate()
        {
            return Observable.Defer(() => Observable.Return(new Random(Seed.GetValueOrDefault(Environment.TickCount))));
        }

        public IObservable<Random> Generate<TSource>(IObservable<TSource> source)
        {
            return source.Select(input => new Random(Seed.GetValueOrDefault(Environment.TickCount)));
        }
    }
}
