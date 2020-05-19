namespace PaymentService
{
    public interface ITransactionNotifications
    {
        void NotifySuccess(string transactionId);
        void NotifyFailure(string transactionId, string reason);
    }
}