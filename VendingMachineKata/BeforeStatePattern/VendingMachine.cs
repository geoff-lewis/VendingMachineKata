using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata.BeforeStatePattern
{
    public class VendingMachine
    {
        private VendingMachineState m_State;

        private double m_Cash;

        public VendingMachine()
        {
            m_State = VendingMachineState.Empty;
        }

        public void AddCash(double cash)
        {
            m_Cash += cash;
            if (m_Cash >= 40)
            {
                m_State = VendingMachineState.EnoughCash;
            }
            else
            {
                m_State = VendingMachineState.AddingCash;
            }
        }

        public double Cancel()
        {
            if (m_State == VendingMachineState.Empty) return 0;

            var cashToReturn = m_Cash;
            m_Cash = 0;
            m_State = VendingMachineState.Empty;
            return cashToReturn;
         }

        public Vend Dispense()
        {
            if (m_State == VendingMachineState.Empty || m_State == VendingMachineState.AddingCash) return Vend.UnableToVend;

            var changeToReturn = m_Cash - 40;
            m_Cash = 0;
            m_State = VendingMachineState.Empty;
            return Vend.SuccessfulVend(changeToReturn);
        }

    }
}
