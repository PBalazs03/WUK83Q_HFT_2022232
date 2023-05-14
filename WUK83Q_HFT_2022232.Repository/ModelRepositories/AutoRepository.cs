using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Repository
{
    public class AutoRepository : Repository<Auto>, IRepository<Auto>
    {
        public AutoRepository(AutoDbContext ctx) : base(ctx)
        {
        }

        public override Auto Read(int id)
        {
            return ctx.AutosTable.FirstOrDefault(t => t.AutoId == id);
        }

        public override void Update(Auto item)
        {
            var old = Read(item.AutoId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
