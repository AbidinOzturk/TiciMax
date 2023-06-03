using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Domain.Base;

namespace TiciMax.EntityFrameworkCore.EntityFrameworkCore
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
		protected readonly DbSet<TEntity> _dbSet;
		DbContext _context;
		public Repository(DbContext context)
		{
			_dbSet = context.Set<TEntity>();
			_context = context;

		}
		public virtual async Task AddAsync(TEntity entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await _dbSet.AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _dbSet.Where(predicate).ToListAsync();
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public void Remove(TEntity entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChangesAsync();
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_dbSet.RemoveRange(entities);
			_context.SaveChangesAsync();
		}

		public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _dbSet.SingleOrDefaultAsync(predicate);
		}

		public TEntity Update(TEntity entity)
		{
			_dbSet.Entry(entity).State = EntityState.Modified;
			_context.SaveChanges();
			return entity;
		}
	} 	
}
