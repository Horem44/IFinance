namespace FinanceManager.Domain.Exceptions
{
    public class FinanceManagerDomainException : Exception
    {
        public FinanceManagerDomainException() { }

        public FinanceManagerDomainException(string message)
            : base(message) { }

        public FinanceManagerDomainException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
