namespace Restaurant.Service.Exceptions
{
    public class WrongIntervalException : Exception
    {
        public WrongIntervalException() { }
        public WrongIntervalException(string message) : base(message) { }
        public WrongIntervalException(string message, Exception inner) : base(message, inner) { }
    }
}
