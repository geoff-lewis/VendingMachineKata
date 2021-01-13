namespace VendingMachineKata.StateMachinePattern
{
    public class CashAndState
    {
        public CashAndState(double cash, VendingMachineState state)
        {
            Cash = cash;
            State = state;
        }

        public double Cash { get; }
        public VendingMachineState State { get; }
        
    }
}