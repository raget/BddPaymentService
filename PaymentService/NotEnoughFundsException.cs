using System;

namespace PaymentService
{
    internal class NotEnoughFundsException : Exception
    {
        public string AccountId { get; }
        public decimal AccountBalance { get; }
        public decimal TransactionAmount { get; }

        public NotEnoughFundsException(string accountId, decimal accountBalance, decimal transactionAmount) 
            : base($"Not enough funds on account [{accountId}]. Account balance [{accountBalance}], transaction amount [{transactionAmount}]")
        {
            AccountId = accountId;
            AccountBalance = accountBalance;
            TransactionAmount = transactionAmount;
        }
    }
}
