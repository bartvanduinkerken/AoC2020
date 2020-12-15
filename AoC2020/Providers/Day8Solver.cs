using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC2020.Providers
{
    using Abstractions;

    public class Day8Solver : ISolver<int>
    {
        private List<int> ExecutedRows = new List<int>();
        int pos = 0;
        int acc = 0;
        int linesCount = 0;
        bool stop = false;
        public int StepA()
        {
            var lines = InputFile;
            linesCount = lines.Count();

            Process(lines, lines[pos]);
            return acc;
        }

        private void Process(IList<string> lines, string line)
        {
            while (!stop)
            {
                if (ExecutedRows.Contains(pos))
                {
                    stop = true;
                    return;
                }
                else
                {
                    ExecutedRows.Add(pos);
                    var split = line.Split(" ");
                    var number = Convert.ToInt32(split[1]);
                    switch (split[0])
                    {
                        case "nop":
                            pos += 1;
                            break;
                        case "acc":
                            pos += 1;
                            acc += number;
                            break;
                        case "jmp":
                            pos += number;
                            break;
                    }
                    if (pos == linesCount)
                    {
                        ended = true;
                        stop = true;
                        return;
                    }
                    else
                    {
                        //Recurse
                        Process(lines, lines[pos]);
                    }
                }
            }
        }

        bool ended = false;
        public int StepB()
        {
            var lines = InputFile;
            linesCount = lines.Count();
            for (int i = 0; i < linesCount - 1; i++)
            {
                acc = 0;
                pos = 0;
                stop = false;
                ExecutedRows = new List<int>();
                var original = lines[i];
                (string op, string operand) = GetOpAndOperand(original);
                if (op == "nop")
                    op = "jmp";
                else if (op == "jmp")
                    op = "nop";

                lines[i] = $"{op} {operand}";
                Process(lines, lines[pos]);
                if (ended)
                    return acc;

                lines[i] = original;
            }

            return acc;
        }
        private (string op, string operand) GetOpAndOperand(string line)
        {
            var split = line.Split(" ");
            return (split[0], split[1]);
        }

        private static string[] InputFile => File.ReadAllLines("input/Day8Input.txt");
    }
}