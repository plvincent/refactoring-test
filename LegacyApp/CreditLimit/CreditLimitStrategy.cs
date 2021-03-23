using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.CreditLimit
{
    public static class CreditLimitStrategy
    {
        public static ICreditLimitStrategy Get(ClientStatus clientStatus)
        {
            // Having client names hardcoded is a bad practice, I assumed that ClientStatus could be used for that purpose
            if (clientStatus == ClientStatus.veryImportant)
            {
                return new VeryImportantClientCreditLimitStrategy();
            }
            else if (clientStatus == ClientStatus.important)
            {
                return new ImportantClientCreditLimitStrategy();
            }
            else
            {
                return new StandardClientCreditLimitStrategy();
            }
        }
    }
}
