using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Client.Model
{
    public class HoursPlanRateModel
    {
        public virtual string Time { set; get; }
        public virtual string Plan { set; get; }
        public virtual string Actual { set; get; }
        public virtual string Fulfill { set; get; }
        public virtual string FPY { set; get; }
    }
}
