using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class Vend
    {
        public VendResult VendResult { get; }
        public double Change { get; }
        
        private Vend(VendResult vendResult, double change)
        {
            VendResult = vendResult;
            Change = change;
        }

        public static Vend UnableToVend => new Vend(VendResult.UnableToVend,0);

        public static Vend SuccessfulVend(double change) => new Vend(VendResult.SuccessfulVend,change);

    }
}
