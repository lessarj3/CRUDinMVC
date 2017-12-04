using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CathRepoCommon.Models
{
    public class Mix
    {
        public Mix()
        {
            Pellets = new List<Pellet>();
        }

        public int Id { get; set; }
        [Required, StringLength(25, ErrorMessage = "Mix Name too long")]
        public string MixName { get; set; }
        [Range(0, 100)]
        public int CFx { get; set; }
        [Range(0, 100)]
        public int SVO { get; set; }
        [Range(0, 100)]
        public int Carbon { get; set; }
        [Range(0, 100)]
        public int Binder { get; set; }
        public int Ratio { get; set; }
        public List<Pellet> Pellets { get; set; }
        //public int mAh { get; set; }
        //public string Tag { get; set; }
        //public string Experiment { get; set; }
        //public string CFxLot { get; set; }
        //public string CFxProcessing { get; set; }
        //public int MillTime { get; set; }
        //public int H20 { get; set; }
        //public int IPA { get; set; }
        //public string PTFElot { get; set; }



    }
}