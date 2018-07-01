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
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Generates a random permutation, without repetition, of all the elements in the input sequence.")]
    public class Permutation
    {
        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source
                .ToArray()
                .Do(elements => Combinatorics.SelectPermutationInplace(elements))
                .SelectMany(elements => elements);
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return source
                .ToArray()
                .Zip(random.FirstAsync(), (elements, randomSource) =>
                {
                    Combinatorics.SelectPermutationInplace(elements, randomSource);
                    return elements;
                })
                .SelectMany(elements => elements);
        }
    }
}
