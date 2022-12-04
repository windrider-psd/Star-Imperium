using System;

namespace Assets.Source.Extensions
{
    internal static class RandomExtensions
    {
        public static bool NextBoolean(this Random random)
        {
            return random.Next(2) == 1;
        }

        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}