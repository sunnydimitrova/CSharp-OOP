using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exeptions
{    
    public class ArgumentMissionException : Exception
    {
        private const string EXC_MESS = "Mission is alredy finished!";
        public ArgumentMissionException() : base(EXC_MESS)
        {

        }

        public ArgumentMissionException(string message) : base(message)
        {

        }
    }
}
