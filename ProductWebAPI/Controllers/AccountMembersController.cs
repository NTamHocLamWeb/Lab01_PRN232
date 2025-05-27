using Microsoft.AspNetCore.Mvc;
using BusinessObjects;
using Services.Interfaces;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountMembersController : ControllerBase
    {
        private readonly IAccountService _context;

        public AccountMembersController(IAccountService context)
        {
            _context = context;
        }

        // GET: api/AccountMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountMember>> GetAccountMember(string id)
        {
            var accountMember = _context.GetAccountById(id);

            if (accountMember == null)
            {
                return NotFound();
            }

            return accountMember;
        }
    }
}
