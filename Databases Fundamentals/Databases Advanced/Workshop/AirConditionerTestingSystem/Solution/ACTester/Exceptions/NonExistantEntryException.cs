namespace ACTester.Exceptions
{
    using System;

    public class NonExistantEntryException : Exception
    {
        public NonExistantEntryException(string message) : base(message)
        {
        }
    }
}
