using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDinMVC.Models
{
    public class MixModel
    {
        public int Id { get; set; }
        public string MixName { get; set; }
        public int CFx { get; set; }
        public int SVO { get; set; }
        public int ConductiveCarbon { get; set; }
        public int Binder { get; set; }
        public int Ratio { get; set; }

    }
}