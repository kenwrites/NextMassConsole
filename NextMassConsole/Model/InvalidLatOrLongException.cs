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
}
