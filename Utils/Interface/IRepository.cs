using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASAP.Utils.Interface
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);
		void AddAsync(TEntity entity);

		void SaveChanges();
		void Dispose();

		void Update(TEntity entity);

		void UpdateField(TEntity entity, string Field);

		void UpdateFields(TEntity entity, string[] Fields);

		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
		int Count();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		IEnumerable<TEntity> FindNoTracking(Expression<Func<TEntity, bool>> predicate);

		ValueTask<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
		TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
		TEntity Get(int id);


		ValueTask<TEntity> GetAsync(int id);
		IEnumerable<TEntity> GetAll();
		Task<List<TEntity>> GetAllAsync();
	}
}