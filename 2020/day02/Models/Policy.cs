using System;
using System.Linq;

namespace day02.Models
{
    public class Policy
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Letter { get; set; }
        public string Password { get; set; }

        public static implicit operator Policy(string s)
        {
            var split = s.Split(" ");

            var first = split[0].Split('-');

            var min = int.Parse(first[0]);
            var max = int.Parse(first[1]);

            var letter = split[1][0];
            var password = split[2];

            return new Policy
            {
                Min = min,
                Max = max,
                Letter = letter,
                Password = password
            };
        }

        public bool CheckPart1Policy()
        {
            var count = Password.Count(c => c == Letter);

            return count >= Min && count <= Max;
        }

        public bool CheckPart2Policy()
        {
            return Password[Min - 1] == Letter ^ Password[Max - 1] == Letter;
        }
    }
}
