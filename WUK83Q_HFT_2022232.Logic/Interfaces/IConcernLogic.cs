using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Logic
{
    public interface IConcernLogic
    {
        void Create(Concern item);
        void Delete(int id);
        Concern Read(int id);
        IQueryable<Concern> ReadAll();
        void Update(Concern item);

    }
}
