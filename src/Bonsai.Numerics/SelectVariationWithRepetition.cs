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
    [Description("Generates random variations, with repetition, by randomly selecting k elements from each array in the input sequence.")]
    public class SelectVariationWithRepetition
    {
        [Description("The number of elements to choose from each array. Elements can be chosen more than once.")]
        public int Count { get; set; }

        public IObservable<TElement[]> Process<TElement>(IObservable<TElement[]> source)
        {
            return source.Select(elements => CombinatoricsHelper.SelectVariationWithRepetition(elements, Count));
        }

        public IObservable<TElement[]> Process<TElement>(IObservable<TElement[]> source, IObservable<Random> random)
        {
            return random.FirstAsync().SelectMany(randomSource =>
                source.Select(elements => CombinatoricsHelper.SelectVariationWithRepetition(elements, Count, randomSource)));
        }

        public IObservable<IEnumerable<TElement>> Process<TElement>(IObservable<IEnumerable<TElement>> source)
        {
            return source.Select(elements => Combinatorics.SelectVariationWithRepetition(elements, Count));
        }

        public IObservable<IEnumerable<TElement>> Process<TElement>(IObservable<IEnumerable<TElement>> source, IObservable<Random> random)
        {
            return random.FirstAsync().SelectMany(randomSource =>
                source.Select(elements => Combinatorics.SelectVariationWithRepetition(elements, Count, randomSource)));
        }
    }
}
