using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Application2.Models
{
    public class Person
    {
        public string Name { get; set; }
        public bool Reading { get; set; }
        public bool Travel { get; set; }
        public bool Sports { get; set; }
        public bool Dance { get; set; }
        public int Index { get; set; }

        public Color RowColor
        {
            get
            {
                if (Index % 2 == 0)
                    return Color.White;
                else
                    return Color.Azure;
            }
        } 

    }
}
