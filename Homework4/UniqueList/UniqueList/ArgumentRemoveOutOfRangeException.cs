using System;
namespace Lists
{
    public class ArgumentRemoveOutOfRangeException : ArgumentOutOfRangeException
    {
        public ArgumentRemoveOutOfRangeException()
        {
        }

        public ArgumentRemoveOutOfRangeException(string message) : base(message)
        {
        }
    }
}

