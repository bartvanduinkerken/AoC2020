using System.Collections.Generic;
using System.Linq;
using System;

namespace AoC2020.Providers
{
    using Abstractions;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Day4Solver : ISolver<int>
    {
        public int StepA()
        {
            var validPassports = 0;
            var passports = InputFile.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);

            foreach (var passport in passports)
            {
                if (RequiredFields.All(x => passport.Contains(x)))
                    validPassports++;
            }

            return validPassports;
        }


        public int StepB()
        {
            var validPassports = 0;
            var passports = InputFile.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries).Select(x => x.Replace("\r\n", " "));
            validPassports = passports.Count(IsValid);

            return validPassports;
        }

        public bool IsValid(string line)
        {
            var valid = true;
            try
            {
                var byr = int.Parse(Regex.Match(line, @"byr:(\d{4})").Groups[1].Value);
                var iyr = int.Parse(Regex.Match(line, @"iyr:(\d{4})").Groups[1].Value);
                var eyr = int.Parse(Regex.Match(line, @"eyr:(\d{4})").Groups[1].Value);
                var hgt = int.Parse(Regex.Match(line, @"hgt:(\d*)(cm|in)").Groups[1].Value);
                var hgtUnit = Regex.Match(line, @"hgt:(\d*)(cm|in)").Groups[2].Value;
                var hcl = Regex.Match(line, @"hcl:(#[0-9a-f]{6})").Groups[1].Value;
                var ecl = Regex.Match(line, @"ecl:(...)").Groups[1].Value;
                var pid = Regex.Match(line, @"pid:(\d{9})(\s|$)").Groups[1].Value;

                if (byr < 1920 || byr > 2002)
                {
                    valid = false;
                }

                if (iyr < 2010 || iyr > 2020)
                {
                    valid = false;
                }

                if (eyr < 2020 || eyr > 2030)
                {
                    valid = false;
                }

                switch (hgtUnit)
                {
                    case "cm":
                        if (hgt < 150 || hgt > 193)
                        {
                            valid = false;
                        }

                        break;
                    case "in":
                        if (hgt < 59 || hgt > 76)
                        {
                            valid = false;
                        }

                        break;
                }

                if (!(
                    ecl == "amb" ||
                    ecl == "blu" ||
                    ecl == "brn" ||
                    ecl == "gry" ||
                    ecl == "grn" ||
                    ecl == "hzl" ||
                    ecl == "oth"))
                {
                    valid = false;
                }

                if (hcl.Length != 7)
                {
                    valid = false;
                }

                if (pid.Length != 9)
                {
                    valid = false;
                }
            }
            catch (Exception)
            {
                valid = false;
            }

            return valid;
        }

        public static IList<string> RequiredFields = new[]
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };

        public static IList<string> OptionalFields = new[]
        {
            "cid",
        };

        public string InputFile => File.ReadAllText("input/Day4Input.txt");
    }
}