using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public static class EmailValidation
    {
        public static bool IsValid(string email)
        {
            if (email.Contains("@") && email.Contains("."))
                return true;
            else
                return false;
        }
    }
}
