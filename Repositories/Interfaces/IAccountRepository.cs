using BusinessObjects;

namespace Repositories.Interfaces
{
	public interface IAccountRepository
	{
		AccountMember GetAccountById(string accountID);
	}
}
