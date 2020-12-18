using System;

namespace HelpLibrary
{
    public class DateModifire
    {
        public static double ReturnDiferenceBetweenTwoDate(string startDate, string endDate)
        {
            var firstDate = DateTime.Parse(startDate);
            var secondDate = DateTime.Parse(endDate);
            var diference = (firstDate - secondDate).TotalDays;
            var result = Math.Abs(diference);
            return result;
        }
    }
}
