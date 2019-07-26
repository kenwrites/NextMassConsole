using System;
using System.Collections.Generic;
using System.Text;

namespace NextMassConsole.Model
{
    public class InvalidLatOrLongException : Exception
    {
        public InvalidLatOrLongException(string message) : base(message)
        {
        }
    }
    public class InvalidTimeException : Exception
    {
        public InvalidTimeException(string message) : base(message)
        {
        }
    }
}
