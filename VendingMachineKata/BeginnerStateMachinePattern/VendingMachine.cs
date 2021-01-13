using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata.StateMachinePattern
{
    //public class VendingMachine
    //{
    //    private VendingMachineState m_State;

    //    public VendingMachine()
    //    {
    //        //Note: the method of sharing the context between the states has not been implemented. 
    //        //This is something you will need to considder.
    //        //As a minimum the states need to know the Total Cash in the vending machine.
    //        //They could track this themselves or by means of accessing a property on the VendingMachine itself and 
    //        //passing the VendingMachine as the context to the different states.
    //        m_State = new EmptyVendingMachineState();
    //    }

    //    public void AddCash(double cash)
    //    {
    //        //call to interact with the state and get the result
    //        //set the new state from the result provided
    //        var result =  m_State.AddCash(cash);
    //        m_State = result;
    //    }

    //    public double Cancel()
    //    {
    //        //call to interact with the state and get the result
    //        //set the new state based on the result and return the cash from the result
    //        throw new NotImplementedException();
    //    }

    //    public Vend Dispense()
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
}
