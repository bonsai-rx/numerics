using MathNet.Numerics;
using System;

namespace Bonsai.Numerics
{
    static class CombinatoricsHelper
    {
        private static TElement[] SelectVariation<TElement>(TElement[] elements, int[] indices)
        {
            var variation = new TElement[indices.Length];
            for (int i = 0; i < variation.Length; i++)
            {
                variation[i] = elements[indices[i]];
            }

            return variation;
        }

        internal static TElement[] SelectVariation<TElement>(TElement[] elements, int count)
        {
            return SelectVariation(elements, count, null);
        }

        internal static TElement[] SelectVariation<TElement>(TElement[] elements, int count, Random randomSource)
        {
            return SelectVariation(elements, Combinatorics.GenerateVariation(elements.Length, count, randomSource));
        }

        internal static TElement[] SelectVariationWithRepetition<TElement>(TElement[] elements, int count)
        {
            return SelectVariationWithRepetition(elements, count, null);
        }

        internal static TElement[] SelectVariationWithRepetition<TElement>(TElement[] elements, int count, Random randomSource)
        {
            return SelectVariation(elements, Combinatorics.GenerateVariationWithRepetition(elements.Length, count, randomSource));
        }

        internal static TElement[] SelectCombination<TElement>(TElement[] elements, int count)
        {
            return SelectCombination(elements, count, null);
        }

        internal static TElement[] SelectCombination<TElement>(TElement[] elements, int count, Random randomSource)
        {
            var mask = Combinatorics.GenerateCombination(elements.Length, count, randomSource);
            var combination = new TElement[count];
            for (int i = 0, k = 0; i < mask.Length; i++)
            {
                if (mask[i]) combination[k++] = elements[i];
            }

            return combination;
        }

        internal static TElement[] SelectCombinationWithRepetition<TElement>(TElement[] elements, int count)
        {
            return SelectCombinationWithRepetition(elements, count, null);
        }

        internal static TElement[] SelectCombinationWithRepetition<TElement>(TElement[] elements, int count, Random randomSource)
        {
            var selected = Combinatorics.GenerateCombinationWithRepetition(elements.Length, count, randomSource);
            var combination = new TElement[count];
            for (int i = 0, k = 0; i < selected.Length; i++)
            {
                for (int j = 0; j < selected[i]; j++)
                {
                    combination[k++] = elements[i];
                }
            }

            return combination;
        }
    }
}
