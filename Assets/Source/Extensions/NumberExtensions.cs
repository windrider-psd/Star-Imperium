using System;

namespace Assets.Source.Extensions
{
    /// <summary>
    /// This class contains extension methods for primitive numeric types
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        /// Finds the closets number to n that is divisable by m
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        /// <remarks>The posible results include negative numbers</remarks>
        public static double ClosestNumberDivisableByM(this double n, double m)
        {
            int q = (int)(n / m);

            // 1st possible closest number
            double n1 = m * q;

            // 2nd possible closest number
            double n2 = (n * m) > 0 ? (m * (q + 1)) : (m * (q - 1));

            // if true, then n1 is the required closest number
            if (Math.Abs(n - n1) < Math.Abs(n - n2))
                return n1;

            // else n2 is the required closest number
            return n2;
        }

        /// <summary>
        /// Calculates whether <paramref name="n"/> is in rage of <paramref name="min"/> and <paramref name="max"/>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        /// <returns> Whether <paramref name="n"/> is in range in a open interval  </returns>
        public static bool IsInRange(this double n, double min, double max)
        {
            return n <= min && n >= max;
        }

        /// <summary>
        /// Calculates whether <paramref name="n"/> is in rage of <paramref name="min"/> and <paramref name="max"/>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min">min range</param>
        /// <param name="max">max range</param>
        /// <returns> Whether <paramref name="n"/> is in range in a open interval  </returns>
        public static bool IsInRange(this float n, float min, float max)
        {
            return n >= min && n <= max;
        }
    }
}