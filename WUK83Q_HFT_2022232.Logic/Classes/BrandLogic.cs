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

        #region CRUD methods
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
           return this.repo.ReadAll();
        }

        public void Update(Brand item)
        {
            this.repo.Update(item);
        }
        #endregion

        #region NON-CRUD methods
        public string BrandWithTheMostCars()
        {
            var helper = repo.ReadAll().GroupBy(x => x.BrandName).Select(c => new
            {
                Name = c.Key,
                Autos = c.Count()
            }).OrderByDescending(x => x.Name).FirstOrDefault();
            return helper.Name;
        }
        public string ModelsOfBrand(string brandName)
        {
            string output = "";
            var selected = repo.ReadAll().Where(c => c.BrandName == brandName).SelectMany(x => x.Autos).Select(x => x.Type);
            foreach ( var item in selected)
            {
                output += item + ", ";
            }
            if (output.Length <= 1)
            {
                return "There was an error: Invalid output.";
            }
            else
            {
                return output.Remove(output.Length - 2);
            }
        }

        public List<Brand> GetBrandByName(string concernName)
        {
            return repo.ReadAll().Where(b => b._Concern.ConcernName == concernName).ToList();
        }


        #endregion

    }
}
