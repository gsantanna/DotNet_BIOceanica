﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bie.evgestao.domain.Interfaces.Repository;
using bie.evgestao.infra.data.Context;

namespace bie.evgestao.infra.data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected MainDataContext Db = new MainDataContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAllOnline()
        {
            return Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetTakeSkip(int take, int skip)
        {
            return Db.Set<TEntity>().Take(take).Skip(skip);
        }

        public IEnumerable<TEntity> GetSkipTake(int skip, int take)
        {
            return Db.Set<TEntity>().Skip(skip).Take(take);
        }

        //TODO Use a String linq Query to get item by this name if property called name exists
        public IEnumerable<TEntity> DoSearch(string strSearch)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return Db.Set<TEntity>().Count();

        }

        public long LongCount()
        {
            return Db.Set<TEntity>().LongCount();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();

        }
    }


}
