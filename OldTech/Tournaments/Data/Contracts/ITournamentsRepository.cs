using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Tournaments.Contracts
{
    public interface ITournamentsRepository<T>
        where T : class
    {        
        IEnumerable<T> All();             

        ObservableCollection<T> Local { get; }

        IEnumerable<T> Search(Expression<Func<T, bool>> condition);

        T GetById(int id);

        T FirstOrDefault(Expression<Func<T, bool>> condition);

        bool Any();

        void Add(T entity);

        void Delete(T entity);

        void Delete(int id);

        void AddOrUpdate(T entity);

        void Update(T entity);

        IEnumerable<T1> GetAllForInclude<T1>(
            Expression<Func<T, bool>> filterExpression,
            Expression<Func<T, T1>> selectExpression,
            params Expression<Func<T, object>>[] includes);

    }
}




