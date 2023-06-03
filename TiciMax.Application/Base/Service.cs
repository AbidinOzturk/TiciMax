using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TiciMax.Application.Contracts.Base;
using TiciMax.Domain.Base;

namespace TiciMax.Application.Base
{
	public class Service<TEntity> : IService<TEntity> where TEntity : class, new()
	{
		private readonly IRepository<TEntity> _repository;
		protected readonly IMapper _mapper;

		public Service(IRepository<TEntity> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async virtual Task<TEntity> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}


		public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return  await _repository.GetAllAsync();
		}

		public async virtual Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _repository.WhereAsync(predicate);
		}


		public async virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await _repository.SingleOrDefaultAsync(predicate);
		}


		public async virtual Task AddAsync(TEntity entity)
		{
			await _repository.AddAsync(entity);
		}

		public async virtual Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await _repository.AddRangeAsync(entities);
			return entities;
				
		}
		public virtual TEntity Update(TEntity entity)
		{
			return _repository.Update(entity);
		}

		public virtual void Remove(TEntity entity)
		{
			_repository.Remove(entity);	
		}

		public virtual  void RemoveRange(IEnumerable<TEntity> entities)
		{
			_repository.RemoveRange(entities);
		}
	}
}
