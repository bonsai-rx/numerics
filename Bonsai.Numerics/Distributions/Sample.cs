using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Transform)]
    public class Sample
    {
        public IObservable<int> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.Select(distribution => distribution.Sample());
        }

        public IObservable<double> Process(IObservable<IContinuousDistribution> source)
        {
            return source.Select(distribution => distribution.Sample());
        }
    }
}
