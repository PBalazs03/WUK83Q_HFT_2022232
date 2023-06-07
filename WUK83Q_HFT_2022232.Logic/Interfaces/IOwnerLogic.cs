using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner item);
        void Delete(int id);
        Owner Read(int id);
        IQueryable<Owner> ReadAll();
        void Update(Owner item);
        public int CountAutosByOwner(int ownerID);
        public void OwnerWithTheMostCars();
    }
}
