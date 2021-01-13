namespace VendingMachineKata.StateMachinePattern
{
    public class VendResultAndState
    {
        public VendResultAndState(Vend vendResult, VendingMachineState state)
        {
            VendResult = vendResult;
            State = state;
        }

        public Vend VendResult { get; }

        public VendingMachineState State { get; }


    }
}