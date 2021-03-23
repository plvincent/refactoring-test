namespace LegacyApp.CreditLimit
{
    public class StandardClientCreditLimitStrategy : ICreditLimitStrategy
    {
        int ICreditLimitStrategy.CreditLimit(User user)
        {           
            using (var userCreditService = new UserCreditServiceClient())
            {
                var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                return creditLimit;
            }
        }

        bool ICreditLimitStrategy.HasCreditLimit()
        {
            return true;
        }
    }
}
