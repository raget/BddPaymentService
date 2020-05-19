using FakeItEasy;
using FluentAssertions;
using TechTalk.SpecFlow;
namespace PaymentService.Tests
{
    [Binding]
    public class PaymentSteps
    {
        private const string transactionId = "123";
        private Account _sender;
        private Account _recipient;
        private PaymentService _paymentService;
        private ITransactionNotifications _transactionNotifications;

        [BeforeScenario]
        public void SetupScenario()
        {
            _transactionNotifications = A.Fake<ITransactionNotifications>();
            _paymentService = new PaymentService(_transactionNotifications);
        }

        [Given(@"Sender account has (.*) dollars")]
        public void GivenSenderAccountHasDollars(int amount) => 
            _sender = new Account("1", "Common account", amount);

        [Given(@"Recipient account has (.*) dollars")]
        public void GivenRecipientAccountHasDollars(int amount) => 
            _recipient = new Account("2", "Saving account", amount);

        [When(@"Payment service transfers (.*) dollars from Sender account to Recipient account")]
        public void WhenPaymentServiceTransfersDollarsFromSenderAccountToRecipientAccount(int transactionValue) => 
            _paymentService.Transfer(_sender, _recipient, transactionValue, transactionId);

        [Then(@"Sender account has (.*) dollars")]
        public void ThenSenderAccountHasDollars(int balance) => 
            _sender.Balance.Should().Be(balance);

        [Then(@"Recipient account has (.*) dollars")]
        public void ThenRecipientAccountHasDollars(int balance) => 
            _recipient.Balance.Should().Be(balance);

        #region audit
        [Then("Audit system was notified about success")]
        public void AuditSystemWasNotifiedAboutSuccess() =>
            A.CallTo(() => _transactionNotifications.NotifySuccess(
                A<string>.That.Matches(x=> x == transactionId)))
                .MustHaveHappened();

        [Then("Audit system was notified about failure")]
        public void AuditSystemWasNotifiedAboutFailure() =>
            A.CallTo(() => _transactionNotifications.NotifyFailure(
                A<string>.That.Matches(x=>x == transactionId), A<string>._)).MustHaveHappened();
        #endregion
    }
}
