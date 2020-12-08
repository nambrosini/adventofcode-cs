using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace day04.Models
{
    public class Passport
    {
        public int? Byr { get; set; }
        public int? Iyr { get; set; }
        public int? Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Base { get; set; }

        public Passport()
        {
        }

        public static implicit operator Passport(string s)
        {
            var passport = new Passport();
            passport.Base = s.Trim().Replace("\r", "");
            var fields = passport.Base.Split(" ");

            foreach (var f in fields)
            {
                var fsplit = f.Split(":");
                var key = fsplit[0];
                var val = fsplit[1];

                switch (key) {
                    case "byr":
                        try
                        {
                            passport.Byr = int.Parse(val);
                        } catch { return null; }
                        break;
                    case "iyr":
                        try
                        {
                            passport.Iyr = int.Parse(val);
                        } catch { return null; }
                        break;
                    case "eyr":
                        try
                        {
                            passport.Eyr = int.Parse(val);
                        } catch { return null; }
                        break;
                    case "hgt":
                        passport.Hgt = val;
                        break;
                    case "hcl":
                        passport.Hcl = val;
                        break;
                    case "ecl":
                        passport.Ecl = val;
                        break;
                    case "pid":
                        passport.Pid = val;
                        break;
                    default:
                        break;
                }
            }

            return passport.ValidateNullFields() ? passport : null;
        }

        public bool ValidateNullFields()
        {
            return Byr != null && Iyr != null && Eyr != null && Hgt != null && Hcl != null &&
                Ecl != null && Pid != null;
        }

        public bool ValidatePart2()
        {
            var heightUnit = Hgt.Substring(Hgt.Length - 2, 2);

            if (heightUnit != "cm" && heightUnit != "in" )
            {
                return false;
            }

            if (heightUnit == "cm" && Hgt.Length != 5 || heightUnit == "in" && Hgt.Length != 4)
            {
                return false;
            }

            var height = int.Parse(Hgt.Substring(0, heightUnit == "cm" ? 3 : 2));

            string hclPattern = "#([a-f]|[0-9]){6}";

            List<String> ecl = new List<string>(new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" });

            var pidPattern = "[0-9]{9}";

            return Byr >= 1920 && Byr <= 2002 &&
                Iyr >= 2010 && Iyr <= 2020 &&
                Eyr >= 2020 && Eyr <= 2030 &&
                (heightUnit == "cm" && height >= 150 && height <= 193 || heightUnit == "in" && height >= 59 && height <= 76) &&
                Regex.IsMatch(Hcl, hclPattern) &&
                ecl.Contains(Ecl) &&
                Regex.IsMatch(Pid, pidPattern);
        }
    }
}
