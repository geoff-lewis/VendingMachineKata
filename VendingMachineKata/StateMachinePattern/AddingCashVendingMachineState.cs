using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata.StateMachinePattern
{
    public class AddingCashVendingMachineState : VendingMachineState
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
