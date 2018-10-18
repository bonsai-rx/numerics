using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics.Distributions
{
    [Combinator]
    [Description("Draws multiple distinct random samples from the input distribution.")]
    public class SampleDistinct
    {
        public SampleDistinct()
        {
            Count = 1;
        }

        [Description("The number of distinct random samples to draw.")]
        public int Count { get; set; }

        public IObservable<int> Process(IObservable<IDiscreteDistribution> source)
        {
            return source.SelectMany(distribution => distribution.Samples().Distinct().Take(Count));
        }
    }
}
