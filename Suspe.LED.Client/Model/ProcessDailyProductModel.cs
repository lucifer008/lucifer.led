using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Client.Model
{
    public class ProcessDailyProductModel
    {
        public virtual string ProcessOrderNo { set; get; }
        public virtual string Aim { set; get; }
        public virtual string Yield { set; get; }
        public virtual string Rate { set; get; }
    }
}
