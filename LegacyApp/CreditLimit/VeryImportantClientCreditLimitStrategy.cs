namespace LegacyApp.CreditLimit
{
    public class VeryImportantClientCreditLimitStrategy : ICreditLimitStrategy
    {
        int ICreditLimitStrategy.CreditLimit(User user)
        {
            return 0;
        }

        bool ICreditLimitStrategy.HasCreditLimit()
        {
            return false;
        }
    }
}
