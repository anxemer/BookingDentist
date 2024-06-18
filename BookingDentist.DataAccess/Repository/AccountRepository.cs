using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingDentist.DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookingDentistDataContext _dbContext;
        private readonly DbSet<Account> _dbSet;

        public AccountRepository(BookingDentistDataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<Account>();
        }

        public IQueryable<Account> GetAll() => _dbSet;

        public IQueryable<Account> FindByCondition(Expression<Func<Account, bool>> predicate) => _dbSet.Where(predicate);

        public async Task<Account?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<Account> AddAsync(Account entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Account Update(Account entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<Account> RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) throw new ArgumentException("Entity not found");
            _dbSet.Remove(entity);
            return entity;
        }

        public Task<int> CommitAsync() => _dbContext.SaveChangesAsync();
    }
}
