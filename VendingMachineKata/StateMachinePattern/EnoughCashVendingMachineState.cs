using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata.StateMachinePattern
{
    public class EnoughCashVendingMachineState : VendingMachineState
    {
        public override VendingMachineState AddCash(double cash)
        {
            throw new NotImplementedException();
        }

        public override CashAndState Cancel()
        {
            throw new NotImplementedException();
        }

        public override VendResultAndState Dispense()
        {
            throw new NotImplementedException();
        }
    }
}
