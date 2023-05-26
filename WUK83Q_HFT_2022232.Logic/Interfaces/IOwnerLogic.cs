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
        void Create(Auto item);
        void Delete(int id);
        Auto Read(int id);
        IQueryable<Auto> ReadAll();
        void Update(Auto item);
    }
}
