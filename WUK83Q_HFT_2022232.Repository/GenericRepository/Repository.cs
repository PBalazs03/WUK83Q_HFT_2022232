﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AutoDbContext ctx;

        public Repository(AutoDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}