using BusinessObjects;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository iAccountRepository;

		public AccountService()
		{
			iAccountRepository = new AccountRepository();
		}

		public AccountMember GetAccountById(string accountID)
		{
			return iAccountRepository.GetAccountById(accountID);
		}
	}
}
