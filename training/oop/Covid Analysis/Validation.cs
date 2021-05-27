using System;
using System.Collections.Generic;
using System.Text;

namespace Covid_Analysis
{
    public static class Validation
    {
        public static bool IsPresent(string num)
        {
            if (int.TryParse(num, out int validInt))            
                return true;            
            else
                return false;
        }
    }
}
