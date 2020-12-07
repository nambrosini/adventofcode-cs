using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day08.Data
{
    class Image
    {

        public const int IMAGE_WIDTH = 25;
        public const int IMAGE_HEIGHT = 6;

        public static int IMAGE_SIZE
        {
            get
            {
                return IMAGE_WIDTH * IMAGE_HEIGHT;
            }
        }

        public Layer[] Layers { get; set; }

        public Image(string s)
        {
            Layer[] layers = new Layer[s.Length / IMAGE_SIZE];

            for (var i = 0; i < s.Length / IMAGE_SIZE; i += 1)
            {
                layers[i] = new Layer(s.Substring(i * IMAGE_SIZE, IMAGE_SIZE));
            }

            Layers = layers;
        }

        public Layer FewestZeroes()
        {
            return Layers.Aggregate((l1, l2) => l1.CountZeroes() < l2.CountZeroes() ? l1 : l2);
        }

        public string Render()
        {
            Layer finalImage = new Layer();

            foreach (Layer l in Layers)
            {
                for (var i = 0; i < l.Pixels.Length; i++)
                {
                    if (finalImage.Pixels[i] == 2)
                    {
                        finalImage.Pixels[i] = l.Pixels[i];
                    }
                }
            }

            return finalImage.Render();
        }
    }
}
