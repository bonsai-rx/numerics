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
    [Description("Generates a random variation, with repetition, by randomly selecting k elements from the input sequence.")]
    public class VariationWithRepetition
    {
        [Description("The number of elements to choose from the input sequence. Elements can be chosen more than once.")]
        public int Count { get; set; }

        private TElement[] SelectVariationWithRepetition<TElement>(TElement[] elements)
        {
            return SelectVariationWithRepetition(elements, null);
        }

        private TElement[] SelectVariationWithRepetition<TElement>(TElement[] elements, Random randomSource)
        {
            var indices = Combinatorics.GenerateVariationWithRepetition(elements.Length, Count, randomSource);
            var variation = new TElement[indices.Length];
            for (int i = 0; i < variation.Length; i++)
            {
                variation[i] = elements[indices[i]];
            }

            return variation;
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(SelectVariationWithRepetition);
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return source.ToArray().Zip(random.FirstAsync(), SelectVariationWithRepetition).SelectMany(elements => elements);
        }
    }
}
