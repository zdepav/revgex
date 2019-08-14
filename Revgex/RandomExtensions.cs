using System;
using System.Collections.Generic;

namespace ReverseRegex {

    public static class RandomExtensions {

        /// <summary> Implementation taken from https://stackoverflow.com/questions/218060/random-gaussian-variables </summary>
        public static double NextGaussian(this Random r) {
            var u1 = 1.0 - r.NextDouble(); // uniform(0,1] random doubles
            var u2 = 1.0 - r.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u1)) *
                   Math.Sin(2.0 * Math.PI * u2); // random normal(0,1)
        }
        
        public static double NextGaussianAbsBelow1(this Random r) => Math.Min(Math.Abs(r.NextGaussian()) / 4.0, 1.0);

        /// <summary> Implementation taken from https://stackoverflow.com/questions/218060/random-gaussian-variables </summary>
        public static double NextGaussian(this Random r, double μ, double σ) {
            var u1 = 1.0 - r.NextDouble(); // uniform(0,1] random doubles
            var u2 = 1.0 - r.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2); // random normal(0,1)
            return μ + σ * randStdNormal;
        }

        public static bool NextBoolean(this Random r) => r.Next(2) == 1;

        public static byte NextByte(this Random r) => (byte)r.Next(256);

        public static T Item<T>(this Random r, T[] items) => items.Length > 0 ? items[r.Next(items.Length)] : default(T);

        public static T Item<T>(this Random r, IList<T> items) => items.Count > 0 ? items[r.Next(items.Count)] : default(T);
    }
}
