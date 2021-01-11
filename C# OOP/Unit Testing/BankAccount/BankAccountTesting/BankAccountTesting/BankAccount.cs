using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountTesting
{
    public class BankAccount
    {
        public BankAccount(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal Amount { get; private set; }

        public void Deposit(decimal depositAmount)
        {
            if(depositAmount <= 0)
            {
                throw new InvalidOperationException("The deposit sum must be a positive number");
            }

            this.Amount += depositAmount;
        }
    }
}
