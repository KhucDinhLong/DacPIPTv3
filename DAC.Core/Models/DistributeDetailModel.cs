using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC.Core
{
    public class DistributeDetailModel
    {
        public long ID { get; set; }
        public string DistributorID { get; set; }
        public string DacCode { get; set; }
        public string ProductCode { get; set; }
        public string PackageCode { get; set; }
    }
}
