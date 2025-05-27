using BusinessObjects;

namespace Services.Interfaces
{
	public interface IAccountService
	{
		AccountMember GetAccountById(string accountID);
	}
}
