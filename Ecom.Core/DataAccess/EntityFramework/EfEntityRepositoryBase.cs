using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Ecom.Core.DataAccess.EntityFramework
{
  public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepostory<TEntity>
      where TEntity : IEntity, new()
      where TContext : DbContext, new()
  {
    public void Add(TEntity entity)
    {
      using (var context = new TContext())
      {
        context.Entry(entity).State = EntityState.Added;
        context.SaveChanges();
      }
    }

    public void Delete(TEntity entity)
    {
      using (var context = new TContext())
      {
        context.Entry(entity).State = EntityState.Deleted;
        context.SaveChanges();
      }
    }

    public void Update(TEntity entity)
    {
      using (var context = new TContext())
      {
        context.Entry(entity).State = EntityState.Modified;
        context.SaveChanges();
      }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
      using (var context = new TContext())
      {
        return context.Set<TEntity>().SingleOrDefault(filter);
      }
    }


    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter)
    {
      using (var context = new TContext())
      {
        return filter == null
            ? context.Set<TEntity>().ToList()
            : context.Set<TEntity>().Where(filter).ToList();
      }
    }




  }
}
