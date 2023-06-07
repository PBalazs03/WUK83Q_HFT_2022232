using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Logic
{
    public interface IBrandLogic
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
        public string BrandWithTheMostCars();
        public string ModelsOfBrand(string brandName);
        public List<Brand> GetBrandByName(string concernName);
    }
}
