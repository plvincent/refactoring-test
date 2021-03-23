namespace LegacyApp.CreditLimit
{
    public class ImportantClientCreditLimitStrategy : ICreditLimitStrategy
    {
        int ICreditLimitStrategy.CreditLimit(User user)
        {           
            using (var userCreditService = new UserCreditServiceClient())
            {
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                return creditLimit;
            }
        }

        bool ICreditLimitStrategy.HasCreditLimit()
        {
            return true;
        }
    }
}
