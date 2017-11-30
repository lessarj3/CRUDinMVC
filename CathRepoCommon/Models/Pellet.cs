using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathRepoCommon.Models
{
    public class Pellet
    {
        private double v1;
        private double v2;
        private double v3;
        private int v4;

        public Pellet(double v1, double v2, double v3, int v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public Pellet()
        {
            
        }

        public int Mass { get; set; }
        public int Diameter { get; set; }
        public int Thickness { get; set; }
        public int Resistance { get; set; }
    }
}
