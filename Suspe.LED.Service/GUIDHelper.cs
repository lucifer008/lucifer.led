using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suspe.LED.Service
{
   public class GUIDHelper
    {
        public static string GetGuidString()
        {
            var guid = Guid.NewGuid().ToString("N");
            return guid;
        }
    }
}
