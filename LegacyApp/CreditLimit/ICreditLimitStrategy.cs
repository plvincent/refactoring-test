using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.CreditLimit
{
    public interface ICreditLimitStrategy
    {
        public bool HasCreditLimit();
        public int CreditLimit(User user);
    }
}
