﻿using MathNet.Numerics;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace Bonsai.Numerics
{
    [Description("Converts a radian (2*Pi-periodic) angle to a degree (360-periodic) angle.")]
    public class RadianToDegree : Transform<double, double>
    {
        public override IObservable<double> Process(IObservable<double> source)
        {
            return source.Select(Trig.RadianToDegree);
        }
    }
}
