using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Tournaments.Contracts;
using System.Collections;

namespace Tournaments.Models
{
    public class TournamentsRepository<T> : ITournamentsRepository<T> where T : class
    {

        public TournamentsRepository(TournamentsDbContext context) // TODO finish interface ITournamentsDbContext
        {
            if (context == null)
            {
                throw new ArgumentNullException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; } 
        
        protected TournamentsDbContext Context { get; set; } // TODO use ITournamentsDbContext
                
        public ObservableCollection<T> Local
        {
            get
            {
                return this.DbSet.Local;
            }
        }

        public IEnumerable<T> All()
        {
            return this.DbSet.ToList();
        }
               

        public IEnumerable<T> Search(Expression<Func<T, bool>> condition)
        {
            return this.DbSet.Where(condition).ToList();
        }

        public T GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
            this.Context.SaveChanges(); //TODO REMOVE IT
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
            this.Context.SaveChanges();
        }

        public void Delete(int id)  // TODO REMOVE SAVE CHANGES
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
                this.Context.SaveChanges();
            }
        }

        private void ChangeEntityState(T entity, EntityState newEntityState)
        {
            var entry = this.Context.Entry(entity);
            entry.State = newEntityState;
        }

        public T FirstOrDefault(Expression<Func<T, bool>> condition)
        {
            return this.DbSet.FirstOrDefault(condition);
        }

        public bool Any()
        {
            return this.DbSet.Any();
        }

        public void SaveEntity(T entity)  // TODO TESTING
        {
            Console.WriteLine(entity.ToString());
        }

        public void AddOrUpdate(T entity)
        {
            this.Context.Set<T>().AddOrUpdate(entity);
            this.Context.SaveChanges();
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public IEnumerable<T1> GetAllForInclude<T1>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> selectExpression,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = this.DbSet;

            if (includes != null)
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T1>().ToList();
            }
        }
    }

}
