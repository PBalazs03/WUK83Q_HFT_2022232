using System;
using System.Linq;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Logic
{
    public class AutoLogic   // kell saját inteface     // ebben vannak noncrud metodusok
    {
        IRepository<Auto> repo;

        public AutoLogic(IRepository<Auto> repo)
        {
            this.repo = repo;
        }

        public void Create(Auto item)
        {
            if (item.Brand == null)
            {
                throw new Exception("Add the barnd name");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Auto Read(int id)
        {
            var auto = this.repo.Read(id);
            if (auto == null)
            {
                throw new Exception("The car does not exists in the database");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Auto> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Auto item)
        {
            this.repo.Update(item);
        }


        //////  NON-CRUD METHODS  //////
        //  Average car age
        //  Average horsepower
        //  Formula 1 teams
    }
}
