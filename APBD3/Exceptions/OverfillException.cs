using System;

namespace APBD3.Exceptions
{
    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message)
        {

        }
    }
}