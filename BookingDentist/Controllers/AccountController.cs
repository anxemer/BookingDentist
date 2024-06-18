using BookingDentist.Business.BusinessLogic;
using BookingDentist.Business.Common;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.Business.Common.Payload.Response;
using Microsoft.AspNetCore.Mvc;

namespace BookingDentist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountBussiness _accountBussiness;
        public AccountController(AccountBussiness accountBussiness)
        {
            _accountBussiness = accountBussiness;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var account = await _accountBussiness.GetAllAccount();

            return Ok(ApiResult<GetAccountResponse>.Succeed(new GetAccountResponse
            {
                Account = account,
            }));
        }
        [HttpPost("createaccount")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            var newAccount = createAccountRequest.ToAccountModel();
            var result = await _accountBussiness.CreateAccount(newAccount);
            if (result is not null)
            {
                return Ok(ApiResult<CreateAccountResponse>.Succeed(new CreateAccountResponse
                {
                    account = newAccount,
                    message = "Create Account Success"
                }));
            }
            else return BadRequest();

        }
        [HttpGet("getaccountbyid/{accountId}")]
        public async Task<IActionResult> GetById([FromRoute] int accountId)
        {
            var result = await _accountBussiness.GetAccountById(accountId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(ApiResult<GetAccountByIdResponse>.Succeed(new GetAccountByIdResponse
            {
                Account = result,
            }));
        }
        [HttpGet("getaccountbyemail/{email}")]
        public async Task<IActionResult> GetByEmail([FromRoute] string email)
        {
            var result = await _accountBussiness.GetAccountByEmail(email);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(ApiResult<GetAccountByIdResponse>.Succeed(new GetAccountByIdResponse { Account = result, }));
        }
    }
}
