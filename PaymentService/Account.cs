using System;

namespace PaymentService
{
    public class Account
    {
        public string Id { get; }
        public string Name { get; set; }
        public decimal Balance { get; protected set; }
        public Account(string id, string name, decimal balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new NotEnoughFundsException(Id, Balance, amount);
            }

            Balance -= amount;
        }
    }
}