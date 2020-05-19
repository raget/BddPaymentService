using System;

namespace PaymentService
{
    public class OverdraftAccount : Account
    {
        private readonly decimal _maximumDebt;
        public OverdraftAccount(string id, string name, decimal balance, decimal maximumDebt) : base(id, name, balance)
        {
            _maximumDebt = maximumDebt;
        }

        public override void Withdraw(decimal amount)
        {
            //ToDo
            throw new NotImplementedException();
        }
    }
}