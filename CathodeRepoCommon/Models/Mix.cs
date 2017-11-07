using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CathodeRepoCommon.Models
{
    public class Mix
    {
        public int Id { get; set; }
        public string MixName { get; set; }
        public int CFx { get; set; }
        public int SVO { get; set; }
        public int Carbon { get; set; }
        public int Binder { get; set; }
        public int Ratio { get; set; }

    }
}