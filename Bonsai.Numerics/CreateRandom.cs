using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    [Description("Creates a pseudo-random number generator with the specified seed.")]
    public class CreateRandom : Source<Random>
    {
        [Description("An optional number used to calculate the starting value of the pseudo-random number sequence.")]
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
