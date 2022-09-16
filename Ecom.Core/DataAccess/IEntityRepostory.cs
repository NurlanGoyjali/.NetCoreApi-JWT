using Ecom.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ecom.Core.DataAccess
{
    public interface IEntityRepostory<T> where T:IEntity ,new()
    {
        T Get(Expression<Func<T,bool>>filter=null);
        List<T> GetList(Expression<Func<T,bool>>filter=null);
        void Add(T entity);
        void Update(T  entity);
        void Delete(T entity);
    }
}
