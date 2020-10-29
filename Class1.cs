using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LPLab4
{
    sealed partial class Driving
    {
        public override int GetHashCode()
        {
            Random r = new Random();
            return r.Next();
        }
        public override bool Equals(object obj) => iCanDrive == (bool)obj;
        public override string ToString() => iCanDrive ? "I can drive" : "I can't drive";
    }
    class Print
    {
        public void IAmPrinting(object print)
        {
            if(print is Cars)
                Console.WriteLine("Is Cars");
            if(print is Transformer)
                Console.WriteLine("Is Transformer");
            if (print is Beast)
                Console.WriteLine("Is Beast");
            if(print is Print)
                Console.WriteLine("Is Print");
        }
    }
}
