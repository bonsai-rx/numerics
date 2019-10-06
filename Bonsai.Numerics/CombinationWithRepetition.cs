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
    [Description("Generates a random combination, with repetition, by randomly selecting k elements from the input sequence.")]
    public class CombinationWithRepetition
    {
        [Description("The number of elements to choose from the input sequence. Elements can be chosen more than once.")]
        public int Count { get; set; }

        private List<TElement> SelectCombinationWithRepetition<TElement>(TElement[] elements)
        {
            return SelectCombinationWithRepetition(elements, null);
        }

        private List<TElement> SelectCombinationWithRepetition<TElement>(TElement[] elements, Random randomSource)
        {
            var k = Count;
            var selected = Combinatorics.GenerateCombinationWithRepetition(elements.Length, k, randomSource);
            var combination = new List<TElement>(k);
            for (int i = 0; i < selected.Length; i++)
            {
                for (int j = 0; j < selected[i]; j++)
                {
                    combination.Add(elements[i]);
                }
            }

            return combination;
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(SelectCombinationWithRepetition);
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return source.ToArray().Zip(random.FirstAsync(), SelectCombinationWithRepetition).SelectMany(elements => elements);
        }
    }
}
