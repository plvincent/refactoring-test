using LegacyApp.CreditLimit;
using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firname) || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            // Moved the email validation logic inside its own class (Single Responsability)
            if(!EmailValidation.IsValid(email))            
            {
                return false;
            }

            // Moved the age calculation logic inside its own class (Single Responsability)
            int age = Age.GetAge(dateOfBirth);

            if (age < 21)
            {
                return false;
            }

            var clientRepository = new ClientRepository();

            Client client;

            try
            {
                client = clientRepository.GetById(clientId);

                if (client == null)
                {
                    Console.WriteLine(String.Format("UserService.AddUser: clientRepository.GetById({0}) returned NULL", clientId));
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Format("UserService.AddUser: clientRepository.GetById({0}) thrown exception. Message: {1}", clientId, e.Message));
                return false;
            }
           
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                Firstname = firname,
                Surname = surname
            };

            // Implemented a Strategy Pattern.
            ICreditLimitStrategy creditLimitStrategy = CreditLimitStrategy.Get(client.ClientStatus);           

            user.HasCreditLimit = creditLimitStrategy.HasCreditLimit();

            if (user.HasCreditLimit)
                user.CreditLimit = creditLimitStrategy.CreditLimit(user);

            if(IsUserCreditTooLow(user.HasCreditLimit, user.CreditLimit))
            {
                return false;
            }
            
            UserDataAccess.AddUser(user);

            return true;
        }

        // Easier to unit test
        private bool IsUserCreditTooLow(bool hasCreditLimit, int creditLimit)
        {
            if (hasCreditLimit && creditLimit < 500)
                return true;
            else
                return false;
        }
    }
}