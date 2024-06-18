using AutoMapper;
using BookingDentist.Business.BusinessModel;
using BookingDentist.Business.Common.Payload.Request;
using BookingDentist.DataAccess;
using BookingDentist.DataAccess.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.Business.BusinessLogic
{
    public class AccountBussiness
    {
        private readonly IRepository<Account,int> _accountRepository;
        private readonly IMapper _mapper;
        public AccountBussiness(IRepository<Account,int> repository,IMapper mapper) {
            _accountRepository = repository;    
            _mapper = mapper;
        }

        public async Task<List<AccountModel>> GetAllAccount()
        {
            var result = _accountRepository.GetAll();
            var accountList = _mapper.Map<List<AccountModel>>(result).ToList();
            return accountList;
            
        }
        public async Task<AccountModel> GetAccountById(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            var result = _mapper.Map<AccountModel>(account);
            if (result is not null)
            {
                return result;
            }
            else throw new ArgumentException("Account not found");
        }
        public async Task<AccountModel> CreateAccount(AccountModel newAccount)
        {
            var accountEntity = _mapper.Map<Account>(newAccount);
            var accountExíted = _accountRepository.FindByCondition(a => a.Email == newAccount.Email).FirstOrDefault();
            if(accountExíted is not null)
            {
                throw new ArgumentException("Email has existed");
            }
            accountEntity.Status = "Active";
             await _accountRepository.AddAsync(accountEntity);
            int result = await _accountRepository.Commit();
            if (result > 0)
            {
                newAccount.Id = accountEntity.Id;
                return newAccount;
            }
            else {
                return null;
            } 
        }
        public async Task<AccountModel> GetAccountByEmail(string email)
        {
            var account = _accountRepository.FindByCondition(a => a.Email == email).FirstOrDefault();
            if(account == null)
            {
                return null;
            }
            var accountView = _mapper.Map<AccountModel>(account);
            return accountView;
        }

       
    }
}
