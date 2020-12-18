using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class DataValidation
    {
        public static bool IsValidData(int number)
        {
            return number < 0 || number > 100;   
        }

        public static string PrintStatsMessage()
        {
            return "{0} should be between 0 and 100.";
        }
    }
}
