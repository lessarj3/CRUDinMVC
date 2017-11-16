using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CathRepoCommon.Models
{
    public class Mix
    {
        public int Id { get; set; }
        [StringLength(10,ErrorMessage= "Mix Name too long")]
        public string MixName { get; set; }
        public int CFx { get; set; }
        public int SVO { get; set; }
        public int Carbon { get; set; }
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