using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day08.Data
{
    class Layer
    {
        public int[] Pixels { get; set; }

        public Layer()
        {
            Pixels = new int[Image.IMAGE_SIZE];

            for (int i = 0; i < Pixels.Length; i++)
            {
                Pixels[i] = 2;
            }
        }

        public Layer(string s)
        {
            Pixels = s.ToCharArray().Select(p => (int)Char.GetNumericValue(p)).ToArray();
        }

        public int CountZeroes()
        {
            return Pixels.Count(p => p == 0);
        }

        public string Render()
        {
            string s = "";

            for (int i = 0; i < Pixels.Length; i++)
            {
                if (Pixels[i] == 1)
                {
                    s += "▓";
                } else
                {
                    s += " ";
                }

                if (i % Image.IMAGE_WIDTH == 0)
                {
                    s += "\n";
                }
            }

            return s;
        }
    }
}
