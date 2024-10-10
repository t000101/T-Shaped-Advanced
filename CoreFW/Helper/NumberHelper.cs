using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreFW.Helper
{
    public class NumberHelper
    {
        public static List<int> GenerateRandomNumbers(int min, int max, int take)
        {
            Random rnd = new Random();
            var sequence = Enumerable.Range(min, max).OrderBy(n => rnd.Next());

            var result = sequence.Distinct().Take(take).ToList();
            return result;
        }
    }
}
