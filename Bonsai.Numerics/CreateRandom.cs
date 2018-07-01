using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    public class CreateRandom : Source<Random>
    {
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
