using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Logic
{
    public class OwnerLogic : IOwnerLogic//  saját interface kell
    {
        IRepository<Owner> repo;
        public OwnerLogic(IRepository<Owner> repo)
        {
            this.repo = repo;
        }

        #region CRUD methods
        public void Create(Owner item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Owner Read(int id)
        {

            return this.repo.Read(id);
        }

        public IQueryable<Owner> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Owner item)
        {
            this.repo.Update(item);
        }


        #endregion

        #region NON-CRUD methods

        public int CountAutosByOwner(int ownerID)
        {
            return repo.Read(ownerID).Autos.Count();
        }
        

        public void OwnerWithTheMostCars()
        {
            
            var selected = repo.ReadAll().Select(x => new
            {
                Name = x.Name,
                CarNumbers = x.Autos.Count()
            }).OrderByDescending(x => x.CarNumbers).FirstOrDefault();
            
        }
        #endregion
    }
}
