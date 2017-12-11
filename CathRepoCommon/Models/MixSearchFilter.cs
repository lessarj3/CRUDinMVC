using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CathRepoCommon.Models
{
    public class MixSearchFilter
    {
        public string MixName { get; set; }
        public double? CFxLow { get; set; }
        public double? CFxHigh { get; set; }
        public double? SVOLow { get; set; }
        public double? SVOHigh { get; set; }
        public double? CarbonLow { get; set; }
        public double? CarbonHigh { get; set; }
        public double? BinderLow { get; set; }
        public double? BinderHigh { get; set; }
        public double? RatioLow { get; set; }
        public double? RatioHigh { get; set; }




    }
}
