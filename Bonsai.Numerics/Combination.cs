using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Combinator)]
    [Description("Generates a random combination, without repetition, by randomly selecting k elements from the input sequence.")]
    public class Combination
    {
        [Description("The number of elements to choose from the input sequence. Each element is chosen at most once.")]
        public int Count { get; set; }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(elements => CombinatoricsHelper.SelectCombination(elements, Count));
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return random.FirstAsync().Zip(
                source.ToArray(),
                (randomSource, elements) => CombinatoricsHelper.SelectCombination(elements, Count, randomSource))
                .SelectMany(elements => elements);
        }
    }
}
