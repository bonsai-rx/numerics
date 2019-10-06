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
    [Description("Generates a random combination, without repetition, by randomly selecting k elements from the input sequence.")]
    public class Combination
    {
        [Description("The number of elements to choose from the input sequence. Each element is chosen at most once.")]
        public int Count { get; set; }

        private List<TElement> SelectCombination<TElement>(TElement[] elements)
        {
            return SelectCombination(elements, null);
        }

        private List<TElement> SelectCombination<TElement>(TElement[] elements, Random randomSource)
        {
            var k = Count;
            var mask = Combinatorics.GenerateCombination(elements.Length, k, randomSource);
            var combination = new List<TElement>(k);
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i]) combination.Add(elements[i]);
            }

            return combination;
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source)
        {
            return source.ToArray().SelectMany(SelectCombination);
        }

        public IObservable<TElement> Process<TElement>(IObservable<TElement> source, IObservable<Random> random)
        {
            return source.ToArray().Zip(random.FirstAsync(), SelectCombination).SelectMany(elements => elements);
        }
    }
}
