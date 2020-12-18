using System;
using Telephony.Interface;
using Telephony.Models;

namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            var urls = Console.ReadLine().Split(' ');
            CallNumbers(numbers);
            BrowsSite(urls);
        }

        private static void BrowsSite(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    IBrowable brows = new Smartphone();
                    Console.WriteLine(brows.Brows(url));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        ICallable call = new StationaryPhone();
                        Console.WriteLine(call.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        ICallable callMobile = new Smartphone();
                        Console.WriteLine(callMobile.Call(number));
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
