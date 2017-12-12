using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CathRepoCommon.Models;

namespace CRUDinMVC.ViewModels
{
    public class MixViewModel
    {
        public MixViewModel()
        {
            Pellets = new List<Pellet>();
        }
        public string Id { get; set; }
        public string MixName { get; set; }
        public double CFx { get; set; }
        public double SVO { get; set; }
        public double Carbon { get; set; }
        public double Binder { get; set; }
        public int Ratio { get; set; }
        public List<Pellet> Pellets { get; set; }
        public double mAh { get; set; }
        public double ActiveMaterial { get; set; }
        public double PelletMassAverage { get; set; }
        public double PelletDiameterAverage { get; set; }
        public double PelletThicknessAverage { get; set; }
        public double PelletResistnaceAverage { get; set; }
        public double PelletVolumeAverage { get; set; }

        public double PelletDensityAverage { get; set; }


    }
}