using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace AoC2020.Providers
{
    using Abstractions;

    public class Day6Solver : ISolver<int>
    {
        public int StepA()
        {
            var grouped = InputFile.Split(new string[] { "\r\n\r\n" },
                                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => string.Join(string.Empty, x.Split(new string[] { "\r\n" },
                                StringSplitOptions.RemoveEmptyEntries)));

            var sum = grouped.Sum(a => a.Distinct().Count());
            return sum;
        }

        public int StepB()
        {
            var grouped = InputFile.Split(new string[] { "\r\n\r\n" },
                                StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new string[] { "\r\n" },
                                StringSplitOptions.RemoveEmptyEntries).Select(a => a.ToCharArray()));
            var d = grouped.Select(GetAnsweredByAll).Sum();
            return d;
        }

        private int GetAnsweredByAll(IEnumerable<char[]> arg1, int arg2)
        {
            var listCount = arg1.Count();
            return arg1.SelectMany(a => a).ToArray()
                 .GroupBy(a => a)
                 .Where(x => x.Count() >= listCount)
                 .Count();
        }

        private string InputFile => File.ReadAllText("input/Day6Input.txt");
    }
}