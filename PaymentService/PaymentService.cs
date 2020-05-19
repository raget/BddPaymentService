using System;

namespace PaymentService
{
    public class PaymentService
    {
        private readonly ITransactionNotifications _notifier;

        public PaymentService(ITransactionNotifications notifier)
        {
            _notifier = notifier;
        }

        public void Transfer(Account sender, Account recipient, decimal amount, string transactionId)
        {
            try
            {
                sender.Withdraw(amount);
            }
            catch (NotEnoughFundsException notEnoughFundsException)
            {
                _notifier.NotifyFailure(transactionId, notEnoughFundsException.Message);
                return;
            }
            recipient.Deposit(amount);
            _notifier.NotifySuccess(transactionId);
        }
    }
}
