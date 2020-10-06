using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Combinator)]
    [Description("Generates a random variation, without repetition, by randomly selecting k elements from the input sequence.")]
    public class Variation
    {
        [Description("The number of elements to choose from the input sequence. Each element is chosen at most once.")]
        public int Count { get; set; }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(elements => CombinatoricsHelper.SelectVariation(elements, Count));
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return source.ToArray().Zip(
                random.FirstAsync(),
                (elements, randomSource) => CombinatoricsHelper.SelectVariation(elements, Count, randomSource))
                .SelectMany(elements => elements);
        }
    }
}
