using Directory.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Directory.Services.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
         where T : class
    {
        protected readonly DirectoryDBContext _dbContext;
        private readonly ILogger _logger;
        internal DbSet<T> dbSet;

        public BaseRepository(DirectoryDBContext dbContext, ILogger<BaseRepository<T>> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("context is empty");
            _logger = logger;
            this.dbSet = _dbContext.Set<T>();
        }

        public T Single(int primaryKey)
        {
            try
            {
                var dbResult = dbSet.Find(primaryKey);
                return dbResult;
            }
            catch(Exception ex)
            {
                _logger.LogError("Fetch Failed. Please check error Message" + ex.Message, primaryKey);
                return null;
            }
        }
        
        public T SingleOrDefault(int primaryKey)
        {
            try
            {
                var dbResult = dbSet.Find(primaryKey);
                return dbResult;
            }
            catch(Exception ex)
            {
                _logger.LogError("Fetch Failed. Please check error Message" + ex.Message, primaryKey);
                return default(T);
            }
        }

        public bool Exists(int primaryKey)
        {
            try
            {
                return dbSet.Find(primaryKey) == null ? false : true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Match Check Failed. Please check error Message" + ex.Message, primaryKey);
                return false;
            }
        }

        public virtual bool Insert(T entity)
        {
            try
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError("Insertion Failed. Please check error Message" + ex.Message, entity);
                return false;
            }
        }

        public virtual bool Update(T entity)
        {
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError("Updation Failed. Please check error Message" + ex.Message, entity);
                return false;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                _dbContext.Attach(entity);
                dynamic obj = _dbContext.Remove(entity);
                this._dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError("Deletion Failed. Please check error Message" + ex.Message, entity);
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return dbSet.AsEnumerable().ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError("Fetch of all Details Failed. Please check error Message" + ex.Message);
                return default(IEnumerable<T>);
            }
        }

    }

}
    