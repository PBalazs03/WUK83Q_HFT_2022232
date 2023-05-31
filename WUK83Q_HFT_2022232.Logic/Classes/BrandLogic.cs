using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Logic
{
    public class BrandLogic : IBrandLogic // Saját interface kell
    {
        IRepository<Brand> repo;
        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Brand Read(int id)
        {
           
            return this.repo.Read(id);
        }

        public IQueryable<Brand> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Brand item)
        {
            throw new NotImplementedException();
        }
    }
}
