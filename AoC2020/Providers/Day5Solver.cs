using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace AoC2020.Providers
{
    using Abstractions;

    public class Day5Solver : ISolver<int>
    {
        public int StepA()
        {
            var boardingPasses = InputFile.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int id = 0;

            var listIds = GetSeatIds(boardingPasses).OrderByDescending(c => c).ToArray();

            id = listIds.FirstOrDefault();

            return id;
        }

        public int StepB()
        {
            var boardingPasses = InputFile.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var listIds = GetSeatIds(boardingPasses).OrderByDescending(c => c).ToArray();

            var allSeatIds = GetAllSeatIds().ToArray();

            var missing = allSeatIds.Except(listIds).ToArray();

            var my = missing.FirstOrDefault(c => missing.Contains(c + 1) == false && missing.Contains(c - 1) == false);
            return my;
        }

        private static int Replace2(string s) { s = s.Replace("B", "1").Replace("F", "0").Replace("R", "1").Replace("L", "0"); return Convert.ToInt32(s, 2); }

        private IList<int> GetAllSeatIds()
        {
            var l = new List<int>();
            foreach (var row in GetRows())
            {
                if (row != 0 && row != 127)
                {
                    foreach (var column in GetColumns())
                    {
                        l.Add(row * 8 + column);
                    }
                }
            }
            return l;
        }

        private List<int> GetSeatIds(string[] boardingPasses)
        {
            var list = new List<int>();
            foreach (var bp in boardingPasses)
            {
                var rows = GetRows();
                for (int i = 0; i < 7; i++)
                {
                    rows = CutInHalf(rows, bp[i].ToString() == "B");
                }
                var rowId = rows[0];
                int column = GetColumn(bp);
                list.Add(rowId * 8 + column);
            }

            return list;
        }

        private int GetColumn(string bp)
        {
            var columnLetters = bp[^3..];
            var columns = GetColumns();
            for (int i = 0; i < 3; i++)
            {
                columns = CutInHalf(columns, columnLetters[i].ToString() == "R");
            }
            var columnId = columns[0];
            return columnId;
        }

        private static List<int> CutInHalf(List<int> list, bool upperHalf)
        {
            var l = new List<int>();
            var count = list.Count();
            var half = count / 2;
            int end;
            int start;
            if (upperHalf)
            {
                start = half;
                end = count;
            }
            else
            {
                start = 0;
                end = half;
            }
            //var start = upperHalf ? half - 1 : 0;
            //var end = (upperHalf ? count -1 : half) ;
            for (int i = start; i < end; i++)
            {
                l.Add(list[i]);
            }
            return l;
        }

        private static List<int> GetRows() => Enumerable.Range(0, 128).ToList();
        private static List<int> GetColumns() => Enumerable.Range(0, 8).ToList();

        private string InputFile => File.ReadAllText("input/Day5Input.txt");
    }
}