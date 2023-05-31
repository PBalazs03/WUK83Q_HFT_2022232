﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Logic
{
    public class ConcernLogic : IConcernLogic
    {
        IRepository<Concern> repo;
        public ConcernLogic(IRepository<Concern> repo)
        {
            this.repo = repo;
        }

        public void Create(Concern item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Concern Read(int id)
        {

            return this.repo.Read(id);
        }

        public IQueryable<Concern> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Concern item)
        {
            throw new NotImplementedException();
        }
    }
}
