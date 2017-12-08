using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathRepoCommon.Models
{
    public class Pellet
    {
        //private double v1;
        //private double v2;
        //private double v3;
        //private int v4;

        public Pellet(double mass, double diameter, double thickness, int resistance)
        {
            Mass = mass;
            Diameter = diameter;
            Thickness = thickness;
            Resistance = resistance;
        }

        public Pellet()
        {
            
        }

        public double Mass { get; set; }
        public double Diameter { get; set; }
        public double Thickness { get; set; }
        public double Resistance { get; set; }
        public double VolumetricCapacity { get; set; }
        public double Density { get; set; }

    }
}
