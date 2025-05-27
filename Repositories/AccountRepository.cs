using BusinessObjects;
using DataAccessObjects;
using Repositories.Interfaces;

namespace Repositories
{
	public class AccountRepository : IAccountRepository
	{
		public AccountMember GetAccountById(string accountID) => AccountDAO.GetAccountById(accountID);
	}
}
