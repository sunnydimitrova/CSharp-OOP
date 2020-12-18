using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{
    public class InvalidStateExeption : Exception
    {
        private const string DEF_EX_MSG = "Invalid State!";
        public InvalidStateExeption() 
            : base(DEF_EX_MSG)
        {

        }

        public InvalidStateExeption(string message) 
            : base(message)
        {

        }
    }
}
