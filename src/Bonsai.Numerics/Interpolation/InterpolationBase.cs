using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using MathNet.Numerics.Interpolation;

namespace Bonsai.Numerics.Interpolation
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Transform)]
    public abstract class InterpolationBase
    {
        protected abstract IInterpolation CreateInterpolation(IEnumerable<double> points, IEnumerable<double> values);

        public IObservable<IInterpolation> Process(IObservable<Tuple<IEnumerable<double>, IEnumerable<double>>> source)
        {
            return source.Select(_ => CreateInterpolation(_.Item1, _.Item2));
        }

        public IObservable<IInterpolation> Process(IObservable<IEnumerable<Tuple<double, double>>> source)
        {
            return source.Select(points => CreateInterpolation(
                points.Select(p => p.Item1),
                points.Select(p => p.Item2)));
        }
    }
}
