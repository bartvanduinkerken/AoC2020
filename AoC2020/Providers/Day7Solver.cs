using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AoC2020.Providers
{
    using Abstractions;

    /// <summary>
    /// light red bags contain 1 bright white bag, 2 muted yellow bags.
    /// dark orange bags contain 3 bright white bags, 4 muted yellow bags.
    /// bright white bags contain 1 shiny gold bag.
    /// muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
    /// shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
    /// dark olive bags contain 3 faded blue bags, 4 dotted black bags.
    /// vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
    /// faded blue bags contain no other bags.
    /// dotted black bags contain no other bags.
    /// </summary>
    public class Day7Solver : ISolver<int>
    {
        List<Bag> bags = new List<Bag>();
        Bag bagToCheck;

        public int StepA()
        {
            Initialize();
            HashSet<Bag> totalBagColors = new HashSet<Bag>();
            bagToCheck = bags.Where(t => t.name == "shiny gold").Single();

            List<Bag> parentsToCheck = new List<Bag>();
            parentsToCheck.Add(bagToCheck);

            while (parentsToCheck.Count > 0)
            {
                foreach (Bag b in parentsToCheck.ToList())
                {
                    foreach (Bag parent in b.parents)
                    {
                        totalBagColors.Add(parent);
                        if (!parentsToCheck.Contains(parent))
                            parentsToCheck.Add(parent);
                    }
                    parentsToCheck.Remove(b);
                }
            }
            return totalBagColors.Count();
        }


        public int StepB()
        {
            Initialize();
            HashSet<Bag> totalBagColors = new HashSet<Bag>();
            bagToCheck = bags.Where(t => t.name == "shiny gold").Single();

            int totalIndividualBags = 0;
            List<Child_With_Multiplier> childrenToCheck = new List<Child_With_Multiplier>
            {
                new Child_With_Multiplier(new KeyValuePair<Bag, int>(bagToCheck, 1), 1)
            };

            while (childrenToCheck.Count > 0)
            {
                foreach (var child in childrenToCheck.ToList())
                {
                    totalIndividualBags += child.child.Key.children.Sum(t => t.Value) * child.multiplier;
                    foreach (var c in child.child.Key.children)
                    {
                        childrenToCheck.Add(new Child_With_Multiplier(c, c.Value * child.multiplier));
                    }

                    childrenToCheck.Remove(child);
                }
            }
            return totalIndividualBags;
        }


        private static string[] InputFile => File.ReadAllLines("input/Day7Input.txt");
        public void Initialize()
        {
            foreach (string line in InputFile)
            {
                string bagName = line.Substring(0, line.IndexOf("bags") - 1);
                Bag b = bags.Where(t => t.name == bagName).SingleOrDefault();

                if (b == null)
                {
                    b = new Bag(bagName);
                    bags.Add(b);
                }

                string[] children = line.Substring(line.IndexOf("contain") + 8, (line.Length - (line.IndexOf("contain") + 8))).Split(',');

                foreach (string child in children)
                {
                    string name = child.Substring(2, child.IndexOf("bag") - 3).Trim();
                    int quantity;

                    if (int.TryParse(child.Trim()[0].ToString(), out quantity))
                    {
                        Bag childB = bags.Where(t => t.name == name).SingleOrDefault();

                        if (childB == null)
                        {
                            childB = new Bag(name);
                            bags.Add(childB);
                        }

                        b.children.Add(childB, quantity);
                        childB.parents.Add(b);
                    }
                }
            }
        }

        public class Bag
        {
            public string name;
            public List<Bag> parents = new List<Bag>();
            public Dictionary<Bag, int> children = new Dictionary<Bag, int>();

            public Bag(string name)
            {
                this.name = name;
            }
        }

        public class Child_With_Multiplier
        {
            public KeyValuePair<Bag, int> child;
            public int multiplier;

            public Child_With_Multiplier(KeyValuePair<Bag, int> child, int multiplier)
            {
                this.child = child;
                this.multiplier = multiplier;
            }
        }
    }
}