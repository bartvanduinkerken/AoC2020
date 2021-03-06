﻿using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Providers
{
    using Abstractions;

    public class Day3Solver : ISolver<int>
    {
        public int StepA()
        {
            var totalTrees = GetTreeCount(3, 1);

            return totalTrees;
        }


        public int StepB()
        {
            var treesSlopeOne = GetTreeCount(1, 1);
            var treesSlopeTwo = GetTreeCount(3, 1);
            var treesSlopeThree = GetTreeCount(5, 1);
            var treesSlopeFour = GetTreeCount(7, 1);
            var treesSlopeFive = GetTreeCount(1, 2);

            return treesSlopeOne * treesSlopeTwo * treesSlopeThree * treesSlopeFour * treesSlopeFive;
        }

        private static int GetTreeCount(int moveRight, int moveDown)
        {
            var grid = GetGrid();
            var totalTrees = 0;
            int startPoint = 1;
            for (int i = 0; i < grid.Count(); i += moveDown, startPoint += moveRight)
            {
                if (i == 0)//first rown should go down
                    continue;
                var zeroBasedStart = startPoint - 1;
                var row = grid[i].ToList();
                while (startPoint >= row.Count)
                    row.AddRange(row);//when starting point i greater then length of row add same row again

                if (row[zeroBasedStart])// if true it is a tree
                {
                    totalTrees++;
                }
            }

            return totalTrees;
        }
        private static bool[][] GetGrid()
        {
            return InputList
                    .Select(x => x.ToCharArray()
                    .Select(x => x == '#')
                    .ToArray())
                    .ToArray();
        }

        public static IList<string> InputList = new[]
        {
            "...#.....#.......##......#.....",
            "...#..................#........",
            "....##....#.......#............",
            ".........#.......#.......#.....",
            "..#..............#.........#..#",
            ".....#.........#....#....#....#",
            "....##..........#.#.##.........",
            "...#....##...#...#...#.#..#....",
            "...#.......###..........#......",
            ".........#.....#....#...#.#....",
            ".#...###..#..##..#.........###.",
            "#.#...#..........###...#....#..",
            "#....#.#..#..........#.......#.",
            ".#..#........##.#..............",
            "............#..#.#............#",
            ".............#..........#......",
            "...#.......#...............#...",
            ".#...#..#..#............#..#...",
            "....##.##..................#.##",
            "#......#...#..##....#.....#...#",
            "#..#..........##....#...###....",
            "##......#.##.#......#..#......#",
            "....#...#.......##.##...#.#..#.",
            "##.#...#....#...#...#........#.",
            "........#..#.....#....#.......#",
            ".#......#......#..............#",
            ".#.....#..#..#..#..#..#....#..#",
            ".......#.....#.................",
            ".#......#...#..#..#...#...#....",
            ".........#..#..#.........#.....",
            ".....#.........#.#..........#..",
            "#......#....#....##....#.#.#...",
            "................##.#...........",
            ".....##.....#............#.#...",
            "...........#...#.#..##...#.....",
            ".......#....##.......#..#....#.",
            ".##......##....#....####.##..#.",
            ".....#.##.....#...#....##......",
            ".............#....#......#....#",
            "#.#.#.###........#.#....#.#....",
            ".##...........#................",
            "#..#..#...##..##.##...#..#.#...",
            "..#......##..#.#......#..#.#.#.",
            ".....#..............#......#...",
            "#.#..##.##...#............##...",
            ".#......#.............#........",
            "........##....#......#..#......",
            "##.........##....#..........#..",
            "..#..#....#.........##....#..#.",
            "........#..#..#........#...#...",
            "#.........#......##.#...#.##...",
            ".##.............#..###....#.##.",
            ".##.#....#.......#.............",
            "#..##.#.........#..##.#......##",
            "....#..#.......................",
            ".#.#.........#...............#.",
            "....#......#.#..##..#...#.#..#.",
            "#....##...##..#.......##.....##",
            "....##...##...#....#.....#..#..",
            ".#......#.#.#.#......##..#..#..",
            ".....##..#..#.....#.....#...##.",
            "....###................#..#.#..",
            ".....#..#..#.#..........#..#...",
            "...#.....#............#........",
            "#.............#...#..#.....#..#",
            "#........#.....#.#..#......#...",
            "...#.##.....#.#..#.........#..#",
            ".......##...#..#.#....##.......",
            "..................#..##..#.#.#.",
            "..#......#..#..#.....#...#.#...",
            ".#.......#.....#.#....#.#......",
            "##..#.#....#.###..#...#.......#",
            ".......................#.......",
            "..###..........#..##.##.#...##.",
            ".....#...#....###.........#..#.",
            "..#.....#....###...............",
            "....#.......#........#....#..#.",
            "......#................#.#...##",
            "#.....#.......#..#..........##.",
            "#.#....##.........#.....#.#....",
            "#.#.#...#............####.##..#",
            ".....#....####........#...#..#.",
            "....##........#.#..............",
            ".#......#..#..##......#....#.##",
            "..#....#.#........#..#....#....",
            ".#...#.##...#.#.....#.....#...#",
            "..........#................###.",
            ".....#..........##..#..........",
            ".....#..................#...#..",
            "#......##....#.#...#..#.......#",
            "..#......##....#......#.#...#..",
            "###.#..###.#.#..#...#....#.....",
            "#.....#.#...#.##...#........#..",
            "#..........................#...",
            ".#.#.....#.#.#.......##.#.#....",
            ".#....#..##......#....#........",
            ".#.......#.##......#.#..#......",
            "............#.....#....##.##...",
            "....##........##......#........",
            "....#......##....##.....#......",
            "..#.#.....#......#...#.#.......",
            ".###.........#...#........#....",
            "......#.#...##.....##..##..#...",
            "...#...#.#......#..##..#.......",
            ".##....#.#........#.#..........",
            "#....#.#......#......#.#.#.....",
            "#.....#.....#................##",
            "...........#....#...#...#......",
            "..........##..##..#...##.......",
            ".##......#.......#..#.#..##....",
            "..........##....#....#..#.#....",
            "...............#......#.....##.",
            ".#...#....................#..#.",
            ".............###...............",
            ".####..............#...#.......",
            "....#...#.#...#...#....#.......",
            ".......#.#.....................",
            "...............................",
            "#..#.........##.......#.#.#....",
            "....##...#...........#......#..",
            "........##...#......#..........",
            "....#.#.....#..#......#........",
            "#..#................#..#.##....",
            ".#........#.......#.........##.",
            "#...........#...#...#......#.#.",
            "..#.#.#..........##.##...#...#.",
            "..#...#.##...#.#...........#...",
            "##...........##...##...##......",
            "....#....##...#......#..#.....#",
            "#..#.#.#..#...#...#....#.......",
            "............#.....#....#....#.#",
            "....##.....#.........#......#..",
            ".....##.......#...#...#.###....",
            "...##......##..###.#.#....#....",
            "#.#.#.#..#.#.........#...#...##",
            "..#..........#.................",
            "....##....#....................",
            "###.#...............##...##.#..",
            "....#.......##.#..#.#..........",
            "............##..#.......##.....",
            "#...#.........#..#..#..#...#...",
            "..#......##..#.#...##.#.......#",
            "......#................#...#...",
            "......#..###............#.#....",
            "..#.#...###...#..#...#......##.",
            "...#.##...##............#......",
            "#...##........#.#..#.......#...",
            "#..#.....#..#.##...............",
            "..#.....#.#....#.........#.....",
            ".............#....#..#...#.##..",
            "..#.#.....................##.#.",
            "........#.......#..#.#.........",
            "##..............#.....#.......#",
            ".#.##...###....#.....#..##.#...",
            "#..#...#..#......#..........###",
            "#...........#..#...#....#....#.",
            "....#..#.......##......#......#",
            "#...#.#...............##...#...",
            "...##.#..##.......##..#........",
            "...........##..........#.......",
            "..#....#..##...#......#.#......",
            ".#.#....#.#.#...#.#............",
            ".#.#..#...##.......#.#.........",
            "...#...#.............#.######..",
            "##.#........###.......#....#.#.",
            ".#....#.....#.#........#......#",
            "..#.#.........#..........##.#..",
            ".#....#.#..............#......#",
            ".....#..##.........#..##..#....",
            "........#..#....#.......#.....#",
            "#.#.......#.....#.##.#...#....#",
            "...#...##...#....#.....#....#.#",
            "#..##....#..........#..#.......",
            ".......#.#.....#...#.#.#.....##",
            "#...#...#..#......##.#..#......",
            "...#.......#....#...........#.#",
            "##.......#####.#.........#..#..",
            "....#.#...................##...",
            "......#..##............#.......",
            "#.........#....#####.#.#..#.#..",
            "..#......#.#.##............#...",
            "..#...#.....#.#....#......#....",
            ".#...#....#....#.#.#......#.#..",
            "..#.##.....#..........#...#.#..",
            ".......#...#.............#...#.",
            ".#.........#.....#.#........##.",
            "#....#..#..........##.......##.",
            "...#....#.#.........#.......###",
            "......#....#.#......#.......#..",
            ".....#...#...#.#...##..#.#.....",
            "#.........##..#...##..#.#....#.",
            "...#......#.#......##.....#....",
            ".#####.....#.#.#.#...###.##....",
            "..#................#.#...#.#...",
            "#.......##...#.........##..#...",
            "..#.....#....##............#...",
            "#............##...............#",
            "..#..#.................#.......",
            "...............#..#.......##...",
            "..##..#....#...##..........#..#",
            "#...###....##.#.......#.....#..",
            "..........#.........#..#......#",
            "##....#.....#...##.......#.....",
            "..#..#.......#.................",
            "..#..##......#.........#......#",
            "...........##.#..#......#.#..#.",
            "..#...##...##......#...#...#.#.",
            ".#..#.....#.........#..........",
            "#..##...#............#..#.#....",
            "..#...#...##.#........#....#.#.",
            "......##..###.#....#........#..",
            ".....#..#....##...##..........#",
            "................#.#.#.....#..#.",
            "#.##...#......#.#..#.......###.",
            ".......#.#..#..#......#..##..#.",
            ".##...#...#....#....#.......#..",
            "......#..#....#.#.###.....#.#.#",
            "#....#.#...#......#.#.....#..#.",
            ".......#.#...#.#.#............#",
            "#.....#..#...#.................",
            ".....#..........#..#.#..#.#....",
            ".........#......#.#.........###",
            "..#.###........#....##.#.......",
            ".#.......#.#......#........#..#",
            "............#........#.....#...",
            "......#......#....#.#....#.....",
            ".#.......#.....#.##.#..#...#..#",
            "##.....#...#..........##..#...#",
            ".#........#....#...#....##.#...",
            "...#.#.......#.#....#.#...#...#",
            "........#.#.....#.##...#.#.#...",
            "...........#....#..#.........#.",
            "......#.#..#..##...#.......#...",
            "...#....#..#..#.##...........##",
            ".#..#.#.#......#....##...#.....",
            "......#..#........#...##.......",
            ".............#...##.#.....#...#",
            "....#...............##......#.#",
            ".#...........#.........###.##.#",
            "....##........##...#.##.....#..",
            "#......##........#...........#.",
            "###.#.................#.....#..",
            ".....##..#.........#......##.#.",
            "#.#.......##.#..#...#...#......",
            "...#.#..##.....#....##.....#.#.",
            "...##..#...#........#.#..#..#..",
            "...........#....#...#...##.....",
            "##.......#...#.#.##...##..#.#..",
            "#....#.#..##...................",
            ".#...................#.#..#....",
            "#.....#..........#..#...#...#..",
            "...#..#............#.#.........",
            "............#..##.....##......#",
            "#....#.........#.#..#..........",
            "...#.#................#....#.#.",
            "..#..#...#...#.#.#...#.#.#.....",
            "..#.......#.............##..#.#",
            "#........#.#.###.#...#..#.###..",
            ".......#......#..#.....####...#",
            "..##....#..#...................",
            "....##.#....#......#.#..#..#..#",
            "#...........##...#.#.##..###...",
            "##.##......#...........#....#..",
            ".#....#....#..#..#...##...#....",
            "...##.#.#......#...............",
            ".....##.##...#...........#.....",
            "....#...#.#.........##.#....#.#",
            "#..#...........#......#........",
            "..#..#.....#....#.##.......#..#",
            "..#.......##.....##.......#...#",
            ".#.##.#..#...............#....#",
            ".........#...........#.........",
            "..........##......#.#..........",
            "..#........###....#..#...#...#.",
            "....#.#...#.....#..#....#......",
            "..##...##...#..#..##......##..#",
            "..#..#......#....#....#...#..##",
            "...#...............#..#........",
            "....##..#...#......#........#..",
            "###.....##.......#.............",
            ".#.#.##........##..#...#.......",
            ".....###............#..#..#....",
            ".#....##.#...####........#.....",
            "............#.#.....##....#.#..",
            "....#..........#...#...........",
            "........#.#...#..##...........#",
            "#.......#..#.......###...#....#",
            "#....#..#......#.....#...##.#..",
            "..#.............#.#.###...##..#",
            ".#.#....#...#.....#...#.......#",
            ".##.#..#.........#..#......#...",
            "#....#...#......#.....#.....#..",
            "...........#....#.......##...#.",
            "#.#..##....#....#.#.......#.#..",
            "..............#.#..##.##.......",
            "....#........#......#....#.#...",
            "......#.....................#..",
            "#..##...##.....#.........#.....",
            "#.....#.....#....#...#.....#...",
            "........###...........#...#....",
            "............#.....#...##....#..",
            ".......#.......#...#.#...##....",
            "..#.#..#....#...#...#....#.....",
            "..........#.#....#....###....#.",
            ".##...#......###..#............",
            "...#...#........#....#....##...",
            "##.....#.##...#.#...........#.#",
            "..........#.#....#...##.#...#..",
            "..#....#.#...#...#....#.###....",
            "......#.##..#..#.........#.###.",
            "#.#.#.....#.....##.......#.....",
            "...#..#..#....#.#....#....#....",
            "##..#.#................#......#",
            ".....#...#..#......#..####.....",
            ".....##.....#....####......#...",
            "..........##..###.#....#.....##",
            "###...#.......#......##...#....",
            ".......##...#...#..#.##.#....##",
            ".....##.....##...##.....#..#..#",
            "......#.#.....#...#....#...#...",
            "..##........#...#..............",
            "..#........#.##.........#...#..",
            "#....#....#................#...",
        };
    }
}
