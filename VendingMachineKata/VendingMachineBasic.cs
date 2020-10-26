using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachineBasic
    {
        private bool m_IsEmpty;
        private bool m_HasEnoughCash;

        private double m_Cash;

        public VendingMachineBasic()
        {
            m_IsEmpty = true;
        }

        public void AddCash(double cash)
        {
            m_IsEmpty = false;
            m_Cash += cash;
            if (m_Cash >= 40) m_HasEnoughCash = true;
        }

        public double Cancel()
        {
            var cashToReturn =  m_Cash;
            m_Cash = 0;
            m_IsEmpty = true;
            return cashToReturn;
        }

        public Vend Dispense()
        {
            if (m_HasEnoughCash)
            {
                var changeToReturn = m_Cash - 40;
                m_Cash = 0;
                m_IsEmpty = true;
                m_HasEnoughCash = false;
                return Vend.SuccessfulVend(changeToReturn);
            }
            else
            {
                return Vend.UnableToVend;
            }
        }

    }
}
