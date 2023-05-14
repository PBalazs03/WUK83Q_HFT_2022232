using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Repository
{
    public class OwnerRepository : Repository<Owner>, IRepository<Owner>
    {
        public OwnerRepository(AutoDbContext ctx) : base(ctx)
        {
        }

        public override Owner Read(int id)
        {
            return ctx.OwnersTable.FirstOrDefault(t => t.OwnerId == id);
        }

        public override void Update(Owner item)
        {
            var old = Read(item.OwnerId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
