using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Combinator)]
    [Description("Generates a random variation, with repetition, by randomly selecting k elements from the input sequence.")]
    public class VariationWithRepetition
    {
        [Description("The number of elements to choose from the input sequence. Elements can be chosen more than once.")]
        public int Count { get; set; }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(elements => CombinatoricsHelper.SelectVariationWithRepetition(elements, Count));
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return random.FirstAsync().Zip(
                source.ToArray(),
                (randomSource, elements) => CombinatoricsHelper.SelectVariationWithRepetition(elements, Count, randomSource))
                .SelectMany(elements => elements);
        }
    }
}
