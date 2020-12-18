using System;


namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsExeption : Exception
    {
        private const string DEF_EX_MSG = "Inavlid corps!";
        public InvalidCorpsExeption() 
            : base(DEF_EX_MSG)
        {

        }

        public InvalidCorpsExeption(string message) 
            : base(message)
        {

        }
    }
}
