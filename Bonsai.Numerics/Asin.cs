﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Calculates the angle whose sine is the specified number.")]
    public class Asin : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Math.Asin);
        }
    }
}
