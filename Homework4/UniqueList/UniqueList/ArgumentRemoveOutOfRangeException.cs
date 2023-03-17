using System;
namespace UniqueList
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

