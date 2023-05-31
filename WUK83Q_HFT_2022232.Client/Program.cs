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

            var item = ctx.AutosTable.ToArray();

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

                var actorSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Actor"))
                    .Add("Create", () => List("Actor"))
                    .Add("Delete", () => List("Actor"))
                    .Add("Update", () => List("Actor"))
                    .Add("Exit", ConsoleMenu.Close);

                var roleSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Role"))
                    .Add("Create", () => List("Role"))
                    .Add("Delete", () => List("Role"))
                    .Add("Update", () => List("Role"))
                    .Add("Exit", ConsoleMenu.Close);

                var directorSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Director"))
                    .Add("Create", () => List("Director"))
                    .Add("Delete", () => List("Director"))
                    .Add("Update", () => List("Director"))
                    .Add("Exit", ConsoleMenu.Close);

                var movieSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Movie"))
                    .Add("Create", () => List("Movie"))
                    .Add("Delete", () => List("Movie"))
                    .Add("Update", () => List("Movie"))
                    .Add("Exit", ConsoleMenu.Close);


                var menu = new ConsoleMenu(args, level: 0)
                    .Add("Movies", () => movieSubMenu.Show())
                    .Add("Actor", () => actorSubMenu.Show())
                    .Add("Roles", () => roleSubMenu.Show())
                    .Add("Director", () => directorSubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);

                menu.Show();
            }
        }
    }
}
