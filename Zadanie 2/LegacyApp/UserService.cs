using System;

namespace LegacyApp
{
    
    public class UserService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserCreditService _userCreditService;

        public UserService(IClientRepository clientRepository = null, IUserCreditService userCreditService = null)
        {
            this._clientRepository = clientRepository ?? new ClientRepository();
            this._userCreditService = userCreditService ?? new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!IsValidCredentials(firstName, lastName, email, dateOfBirth)) 
            {
                return false;
            }

            var client = RetrieveClientFromDatabase(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            SetUserCreditLimit(client, user);

            if (IsUserCreditLimitTooLow(user))
            {
                return false;
            }

            AddUserToDataBase(user);
            return true;
        }
        
        private bool IsValidCredentials(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            return IsValidName(firstName) && IsValidName(lastName) && IsValidEmail(email) && IsValidAge(dateOfBirth );
        }
        private static bool IsValidName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        private static bool IsValidEmail(string email)
        {
            return email.Contains('@') && email.Contains('.');
        }
        private static bool IsValidAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age >= 21;
        }
        private static bool IsUserCreditLimitTooLow(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }

        private void SetUserCreditLimit(Client client, User user)
        {
            switch (client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                {
                    int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit *= 2;
                    user.CreditLimit = creditLimit;
                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                    break;
                }
            }
        }

        private Client RetrieveClientFromDatabase(int clientId)
        {
            return _clientRepository.GetById(clientId);
        }

        private void AddUserToDataBase(User user)
        {
            UserDataAccess.AddUser(user);
        }

    }
}
