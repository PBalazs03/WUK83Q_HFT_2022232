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
            throw new NotImplementedException();
        }

        public void Update(Owner item)
        {
            throw new NotImplementedException();
        }
    }
}
