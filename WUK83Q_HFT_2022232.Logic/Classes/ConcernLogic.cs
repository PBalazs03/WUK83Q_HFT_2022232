using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        #region CRUD methods
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
            return this.repo.ReadAll();
        }

        public void Update(Concern item)
        {
            this.repo.Update
                (item);
        }
        #endregion

        #region NON-CRUD methods
        public void ConcernWithTheMostBrands()
        {
            var helper = repo.ReadAll().GroupBy(x => x.Brands).Select(x => new
            {
                ConcernName = x.Key,
                BrandsCount = x.Count()
            }).OrderByDescending(x => x.BrandsCount).FirstOrDefault();
            
        }
        public List<Concern> ConcernOfOneExactCountry(string countyName)
        {
            return repo.ReadAll().Where(x => x.CountryOfConcern == countyName).ToList();
        }

        public void ListOfConcerns()
        {
            var list = repo.ReadAll().Select(x => new
            {
                Name = x.ConcernName,
                Id = x.ConcernId,
                Born = x.BornOfConcern,
                Country = x.CountryOfConcern,
                Position = x.PositionInRanking
            }).ToList().OrderBy(x => x.Id);
            foreach (var item in list) 
            {
                if (item.Name == null || item.Id == 0)
                {
                    Console.WriteLine("Error: data was null");
                }
                else
                {
                    Console.WriteLine(item.Name + " " + item.Id + " " + item.Country + " " + item.Born + " " + item.Position);
                }
            }
        }
        #endregion
    }
}
