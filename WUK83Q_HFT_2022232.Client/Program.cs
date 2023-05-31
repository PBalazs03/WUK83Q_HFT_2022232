using ConsoleTools;
using System;
using System.Linq;
using WUK83Q_HFT_2022232.Logic;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Client
{
    internal class Program
    {
        static AutoLogic autoLogic;
        static BrandLogic brandLogic;
        static ConcernLogic concernLogic;
        static OwnerLogic ownerLogic;
        static void Main(string[] args)
        {
            AutoDbContext ctx = new AutoDbContext();

            var autos = ctx.AutosTable.ToArray();

            ;


            // Logic osztályok és interfacek lepéldányosítása

            

            static void Create(string entity)
            {
                Console.WriteLine(entity + "create");
                Console.ReadLine();
            }
            static void List(string entity)
            {
                if (entity == "Auto")
                {
                    var items = autoLogic.ReadAll();
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.AutoId + "\t" + item.Brand + item.Type);
                    }
                }
                Console.ReadLine();
            }
            static void Update(string entity)
            {
                Console.WriteLine(entity + "update");
                Console.ReadLine();
            }
            static void Delete(string entity)
            {
                Console.WriteLine(entity + "delete");
                Console.ReadLine();
            }
            static void Main(string[] args)
            {


                var ctx = new AutoDbContext();

                var autorepo = new AutoRepository(ctx);
                var brandrepo = new BrandRepository(ctx);
                var concernrepo = new ConcernRepository(ctx);
                var ownerrepo = new OwnerRepository(ctx);

                autoLogic = new AutoLogic(autorepo);
                brandLogic = new BrandLogic(brandrepo);
                concernLogic = new ConcernLogic(concernrepo);
                ownerLogic = new OwnerLogic(ownerrepo);

                var autoSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Auto"))
                    .Add("Create", () => List("Auto"))
                    .Add("Delete", () => List("Auto"))
                    .Add("Update", () => List("Auto"))
                    .Add("Exit", ConsoleMenu.Close);

                var brandSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Brand"))
                    .Add("Create", () => List("Brand"))
                    .Add("Delete", () => List("Brand"))
                    .Add("Update", () => List("Brand"))
                    .Add("Exit", ConsoleMenu.Close);

                var concernSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Concern"))
                    .Add("Create", () => List("Concern"))
                    .Add("Delete", () => List("Concern"))
                    .Add("Update", () => List("Concern"))
                    .Add("Exit", ConsoleMenu.Close);

                var ownerSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Owner"))
                    .Add("Create", () => List("Owner"))
                    .Add("Delete", () => List("Owner"))
                    .Add("Update", () => List("Owner"))
                    .Add("Exit", ConsoleMenu.Close);


                var menu = new ConsoleMenu(args, level: 0)
                    .Add("Owner", () => ownerSubMenu.Show())
                    .Add("Auto", () => autoSubMenu.Show())
                    .Add("Brands", () => brandSubMenu.Show())
                    .Add("Concerns", () => concernSubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);

                menu.Show();
            }
        }
    }
}
