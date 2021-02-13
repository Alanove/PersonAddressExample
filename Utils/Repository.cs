using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ASAP.Utils.Interface;

namespace ASAP.Utils
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
		/// <summary>
		/// Represents the current entity framework context
		/// </summary>
        protected DbContext _context;
		/// <summary>
		/// Represents the current entity usually a table or a view
		/// </summary>
        protected DbSet<TEntity> _entities;

		/// <summary>
		/// Construction this would create a repository from the context
		/// Usage: Repository<Entity>, IEntiry (should extent interface IRepository)
		/// </summary>
		/// <param name="context"></param>
		public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

		/// <summary>
		/// Calls save changes, basically update changes in database
		/// Should be called after below operations otherwise changes won't be reflected in database
		/// </summary>
		public void SaveChanges()
		{
			_context.SaveChanges();
		}

		/// <summary>
		/// Dispose of the current context
		/// </summary>
		public void Dispose()
		{
			_context.Dispose();
		}

		/// <summary>
		/// Create a new record to the entity
		/// </summary>
		/// <param name="entity"><typeparamref name="TEntity"/></param>
		public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

		/// <summary>
		/// Create a new record to the entity in ASYNC mode
		/// </summary>
		/// <param name="entity"><typeparamref name="TEntity"/></param>
		public virtual void AddAsync(TEntity entity)
		{
			_entities.AddAsync(entity);
		}

		/// <summary>
		/// Adds a range records to the entity
		/// </summary>
		/// <param name="entities"></param>
		public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }
		/// <summary>
		///  Adds a range records to the entity in ASYNC mode
		/// </summary>
		/// <param name="entities"></param>
		public virtual void AddRangeAsync(IEnumerable<TEntity> entities)
		{
			_entities.AddRangeAsync(entities);
		}

		/// <summary>
		/// Update the entity
		/// </summary>
		/// <param name="entity"><typeparamref name="TEntity"/></param>
		public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
		}

		/// <summary>
		/// Update just passed field 
		/// Very useful when working with API and when you don't won't to send all the data between client and server
		/// For example: UpdateFiled(<typeparamref name="TEntity"/>, "Name")
		/// Let's say you have a Person Entity that have properties "Id,Name, Email, Address, etc..."
		/// You call the update from a web interface and send a json object, using this method you don't have to send all the data
		/// You can only send an object {Id: 123, Name: "Name"}
		/// This would update just the name field and ignore all the rest
		/// </summary>
		/// <param name="entity"><typeparamref name="TEntity"/></param>
		/// <param name="Field">Field name or column name</param>
		public virtual void UpdateField(TEntity entity, string Field)
		{
			UpdateFields(entity, new string[] { Field });
		}

		/// <summary>
		/// Update just passed field 
		/// Very useful when working with API and when you don't won't to send all the data between client and server
		/// For example: UpdateFileds(<typeparamref name="TEntity"/>, new string[] {"Name", "Email"} )
		/// Let's say you have a Person Entity that have properties "Id,Name, Email, Address, etc..."
		/// You call the update from a web interface and send a json object, using this method you don't have to send all the data
		/// You can only send an object {Id: 123, Name: "Name", Email: "abc@abc.com"}
		/// This would update just the Name and Email fields and ignore all the rest
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="Fields"></param>
		public virtual void UpdateFields(TEntity entity, string[] Fields)
		{
			var entry = _context.Entry(entity);
			entry.State = EntityState.Unchanged;
			foreach (var name in Fields)
			{
				entry.Property(name).IsModified = true;
			}
		}

		/// <summary>
		/// This would update a range of entities
		/// </summary>
		/// <param name="entities"></param>
		public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
		}

		/// <summary>
		/// This would remove an entiry from db
		/// </summary>
		/// <param name="entity"></param>
		public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

		/// <summary>
		/// This would remove a range of entities 
		/// </summary>
		/// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

		/// <summary>
		/// Returns the current row count
		/// </summary>
		/// <returns></returns>
        public virtual int Count()
        {
            return _entities.Count();
        }

		/// <summary>
		/// Shorthand for .Where basically calls the .Where method on the entity
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

		/// <summary>
		/// calls the .Where with AsNoTracking very usefull when working with big solutions that require many input outut
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual IEnumerable<TEntity> FindNoTracking(Expression<Func<TEntity, bool>> predicate)
		{
			return _entities.AsNoTracking().Where(predicate);
		}

		/// <summary>
		/// Calles .Find but with ASYNC
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual ValueTask<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _entities.FindAsync(predicate);
		}

		/// <summary>
		/// Returns the first row
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

		/// <summary>
		/// Returns the first row in ASYNC mode
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _entities.SingleOrDefaultAsync(predicate);
		}

		/// <summary>
		/// Gets by unique id one record
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual TEntity Get(int id)
        {
            return _entities.Find(id);
        }

		/// <summary>
		/// Gets by unique id one record in ASYNC mode
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public virtual ValueTask<TEntity> GetAsync(int id)
		{
			return _entities.FindAsync(id);
		}

		/// <summary>
		/// Return all records
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

		/// <summary>
		/// Return all records in async mode
		/// </summary>
		/// <returns></returns>
		public virtual Task<List<TEntity>> GetAllAsync()
		{
			return _entities.ToListAsync();
		}
	}
}
