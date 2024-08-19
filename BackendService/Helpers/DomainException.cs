namespace BackendService.Helpers
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {

        }
    }

    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message) : base(message)
        {

        }
    }

    public class DomainInternalServerError : DomainException
    {
        public DomainInternalServerError(string message) : base(message)
        {

        }
    }

    public class DomainBadRequest : DomainException
    {
        public DomainBadRequest(string message) : base(message)
        {

        }
    }
}
