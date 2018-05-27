﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace RayTracing.Misc
{
    public static class Extension
    {
        public static double Square (this double d) => d * d;

        public static List <T> ToList <T> (this Tuple <T> tuple) => new List <T> {tuple.Item1};

        public static List <T> ToList <T> (this Tuple <T, T> tuple) => new List <T> {tuple.Item1, tuple.Item2};

        public static List <T> ToList <T> (this Tuple <T, T, T> tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3};

        public static List <T> ToList <T> (this Tuple <T, T, T, T> tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4};

        public static List <T> ToList <T> (this Tuple <T, T, T, T, T> tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5};

        public static List <T> ToList <T> (this Tuple <T, T, T, T, T, T> tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6};

        public static List <T> ToList <T> (this (T, T) tuple) => new List <T> {tuple.Item1, tuple.Item2};

        public static List <T> ToList <T> (this (T, T, T) tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3};

        public static List <T> ToList <T> (this (T, T, T, T) tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4};

        public static List <T> ToList <T> (this (T, T, T, T, T) tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5};

        public static List <T> ToList <T> (this (T, T, T, T, T, T) tuple) =>
            new List <T> {tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6};

        public static (T2, T2, T2, T2) Select <T, T2> (this (T, T, T, T) tuple, Func <T, T2> function)
            => (function (tuple.Item1), function (tuple.Item2), function (tuple.Item3), function (tuple.Item4));

        public static (T2, T2, T2, T2, T2, T2) Select <T, T2> (this (T, T, T, T, T, T) tuple, Func <T, T2> function)
            => (function (tuple.Item1), function (tuple.Item2), function (tuple.Item3), function (tuple.Item4),
                function (tuple.Item5), function (tuple.Item6));

        public static bool AllEqual <T> (this (T, T, T, T, T, T) tuple) => tuple.ToList ().AllEqual ();

        public static bool AllEqual <T> (this List <T> items) => items.TrueForAll (arg => Equals (arg, items.First ()));

        public static bool AllEqual (this (double, double, double, double, double, double) tuple) =>
            RoundedEqual (tuple.Item1, tuple.Item2) &&
            RoundedEqual (tuple.Item2, tuple.Item3) &&
            RoundedEqual (tuple.Item3, tuple.Item4) &&
            RoundedEqual (tuple.Item4, tuple.Item5) &&
            RoundedEqual (tuple.Item5, tuple.Item6);

        public static bool RoundedEqual (this double a, double b) => Math.Abs (a - b) < 0.00000001;

        public static List <T> ForAll <T> (this List <T> items, Action <T> action)
        {
            foreach (var item in items)
                action (item);
            return items;
        }
    }
}