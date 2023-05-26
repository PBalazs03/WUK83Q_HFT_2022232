using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Repository
{
    public class ConcernRepository :Repository<Concern>, IRepository<Concern>
    {
        public ConcernRepository(AutoDbContext ctx) :base(ctx)
        {

        }

        public override Concern Read(int id)
        {
            return ctx.ConcernsTable.FirstOrDefault(t => t.ConcernId == id);
        }

        public override void Update(Concern item)
        {
            var old = Read(item.ConcernId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
