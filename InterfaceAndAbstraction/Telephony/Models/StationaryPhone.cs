using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interface;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(n => char.IsDigit(n)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
