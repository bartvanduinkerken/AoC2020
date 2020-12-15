using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC2020.Providers
{
    using Abstractions;

    public class Day9Solver : ISolver<long>
    {
        public long StepA()
        {
            int number = 0;
            for (int i = 25; i < Rows.Length; i++)
            {
                var hasCombination = Process(i, Rows[i]);
                if (!hasCombination)
                    return Rows[i];
            }

            return number;
        }

        public long StepB()
        {
            long value = 18272118;
            var numberUsed = new List<long>();
            for (int i = 0; i < Rows.Length; i++)
            {
                for (int j = 0; j < Rows.Length; j++)
                {
                    var range = Rows.Skip(i + 1).Take(j + 1);
                    if(range.Sum() == value)
                    {
                        var sortedrange = range.OrderBy(c => c);
                        return sortedrange.First() + sortedrange.Last();
                    }
                }
            }

            return 0;
        }

        private bool Process(int index, long answer)
        {
            long[] predecessingValues = new long[25];
            Array.Copy(Rows, index - 25, predecessingValues, 0, 25);

            for (int i = 0; i < predecessingValues.Length; i++)
            {
                for (int j = 0; j < predecessingValues.Length; j++)
                {
                    if (predecessingValues[i] + predecessingValues[j] == answer)
                        return true;
                }
            }

            return false;
        }

        private static string[] InputFile => File.ReadAllLines("input/Day9Input.txt");
        private static long[] Rows = InputFile.Select(c => long.Parse(c)).ToArray();
    }
}