using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonsai.Numerics
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Combinator)]
    [Description("Generates a random variation, without repetition, by randomly selecting k elements from the input sequence.")]
    public class Variation
    {
        [Description("The number of elements to choose from the input sequence. Each element is chosen at most once.")]
        public int Count { get; set; }

        private TElement[] SelectVariation<TElement>(TElement[] elements)
        {
            return SelectVariation(elements, null);
        }

        private TElement[] SelectVariation<TElement>(TElement[] elements, Random randomSource)
        {
            var indices = Combinatorics.GenerateVariation(elements.Length, Count, randomSource);
            var variation = new TElement[indices.Length];
            for (int i = 0; i < variation.Length; i++)
            {
                variation[i] = elements[indices[i]];
            }

            return variation;
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(SelectVariation);
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return source.ToArray().Zip(random.FirstAsync(), SelectVariation).SelectMany(elements => elements);
        }
    }
}
