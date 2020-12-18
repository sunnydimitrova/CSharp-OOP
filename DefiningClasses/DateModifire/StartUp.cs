using System;
using System.Linq;

namespace DateModifire1
{
    public class StartUp
    {
        public static void Main()
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();
            var diference = DateModifire.ReturnDiferenceBetweenTwoDate(startDate, endDate);
            Console.WriteLine(diference);
        }
    }
}
