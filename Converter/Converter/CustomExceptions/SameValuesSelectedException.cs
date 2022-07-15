namespace Converter.CustomExceptions
{
    public class SameValueSelectedException : Exception
    {
        public SameValueSelectedException()
        {
        }

        public SameValueSelectedException(string message)
            : base(message)
        {
        }

        public SameValueSelectedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
