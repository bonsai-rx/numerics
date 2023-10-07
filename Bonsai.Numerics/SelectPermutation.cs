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
    [Description("Generates a random permutation, without repetition, of each array in the input sequence.")]
    public class SelectPermutation
    {
        public IObservable<TElement[]> Process<TElement>(IObservable<IEnumerable<TElement>> source)
        {
            return source.Select(elements =>
            {
                var output = elements.ToArray();
                Combinatorics.SelectPermutationInplace(output);
                return output;
            });
        }

        public IObservable<TElement[]> Process<TElement>(IObservable<IEnumerable<TElement>> source, IObservable<Random> random)
        {
            return random.FirstAsync().SelectMany(randomSource => source.Select(elements =>
            {
                var output = elements.ToArray();
                Combinatorics.SelectPermutationInplace(output, randomSource);
                return output;
            }));
        }
    }
}
