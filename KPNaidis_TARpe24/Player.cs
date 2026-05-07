using System;
using System.Collections.Generic;
using System.Text;

namespace KPNaidis_TARpe24
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Player(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}
