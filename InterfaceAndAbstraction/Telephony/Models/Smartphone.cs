using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interface;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowable
    {
        public string Brows(string url)
        {
            if (url.Any(u => char.IsDigit(u)))
            {
                throw new Exception("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(n => char.IsDigit(n)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Calling... {number}";
        }
    }
}
