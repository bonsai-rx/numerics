using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Generates random combinations, without repetition, by randomly selecting k elements from each array in the input sequence.")]
    public class SelectCombination
    {
        [Description("The number of elements to choose from each array. Each element is chosen at most once.")]
        public int Count { get; set; }

        public IObservable<TElement[]> Process<TElement>(IObservable<TElement[]> source)
        {
            return source.Select(elements => CombinatoricsHelper.SelectCombination(elements, Count));
        }

        public IObservable<TElement[]> Process<TElement>(IObservable<TElement[]> source, IObservable<Random> random)
        {
            return random.FirstAsync().SelectMany(randomSource =>
                source.Select(elements => CombinatoricsHelper.SelectCombination(elements, Count, randomSource)));
        }

        public IObservable<IEnumerable<TElement>> Process<TElement>(IObservable<IEnumerable<TElement>> source)
        {
            return source.Select(elements => Combinatorics.SelectCombination(elements, Count));
        }

        public IObservable<IEnumerable<TElement>> Process<TElement>(IObservable<IEnumerable<TElement>> source, IObservable<Random> random)
        {
            return random.FirstAsync().SelectMany(randomSource =>
                source.Select(elements => Combinatorics.SelectCombination(elements, Count, randomSource)));
        }
    }
}
