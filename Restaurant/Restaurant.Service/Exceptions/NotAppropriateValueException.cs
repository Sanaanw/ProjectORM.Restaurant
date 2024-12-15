namespace Restaurant.Service.Exceptions
{
    public class NotAppropriateValueException:Exception
    {
        public NotAppropriateValueException() { }
        public NotAppropriateValueException(string message) : base(message) { }
        public NotAppropriateValueException(string message, Exception inner) : base(message, inner) { }
    }
}
