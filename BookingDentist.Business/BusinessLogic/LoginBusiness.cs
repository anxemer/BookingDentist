using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessLogic
{
    public class LoginBusiness
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public LoginBusiness(IAccountRepository accountRepository,IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<AccountModel> Login(LoginRequest login)
        {
            var accout = _accountRepository.FindByCondition(a => a.Email == login.email).FirstOrDefault();
            if (accout == null)
            {
                throw new Exception("account not found");
            }
            var accountModel = _mapper.Map<AccountModel>(accout);
            if(accountModel.Password == login.password)
            {
                return accountModel;
            }
            return null;
        }
    }
}
