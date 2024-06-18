using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.DataAccess.Repository
{
    public interface IAccountRepository
    {
        IQueryable<Account> GetAll();
        IQueryable<Account> FindByCondition(Expression<Func<Account, bool>> predicate);
        Task<Account?> GetByIdAsync(int id);
        Task<Account> AddAsync(Account entity);
        Account Update(Account entity);
        Task<Account> RemoveAsync(int id);
        Task<int> CommitAsync();
    }
}
