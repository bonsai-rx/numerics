using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Combinator]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Computes basic statistics for each data buffer in the input sequence.")]
    public class DescriptiveStatistics
    {
        public IObservable<RunningStatistics> Process(IObservable<double> source)
        {
            return source.Select(data =>
            {
                var statistics = new RunningStatistics();
                statistics.Push(data);
                return statistics;
            });
        }

        public IObservable<RunningStatistics> Process(IObservable<IList<double>> source)
        {
            return source.Select(data => new RunningStatistics(data));
        }
    }
}
