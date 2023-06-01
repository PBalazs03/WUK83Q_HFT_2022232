using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Client
{
    internal class Program
    {



        static RestService rest;




        //public Auto(string brand, string type, int vintage, int ownerId, int autoId, int brandId)
        //{
        //    AutoId = autoId;
        //    Brand = brand;
        //    Type = type;
        //    OwnerId = ownerId;
        //    Vintage = vintage;
        //    BrandId = brandId;


        //public Brand(int brandId, string brandName, string originOfBrand, int bornOfBrand, bool isProducingFullyElectricCars, bool hasFormula1Team, int concernId)
        //{
        //    BrandId = brandId;
        //    BrandName = brandName;
        //    OriginOfBrand = originOfBrand;
        //    BornOfBrand = bornOfBrand;
        //    IsProducingFullyElectricCars = isProducingFullyElectricCars;
        //    HasFormula1Team = hasFormula1Team;
        //    ConcernId = concernId;
        //}

        //public Concern(int concernId, string concernName, int bornOfConcern, string countryOfTheConcern, int positionInRanking)
        //{
        //    ConcernId = concernId;
        //    ConcernName = concernName;
        //    BornOfConcern = bornOfConcern;
        //    CountryOfConcern = countryOfTheConcern;
        //    PositionInRanking = positionInRanking;
        //}

        //public Owner(string name, string birthDate, string birthPlace, int ownerId)
        //{
        //    Name = name;
        //    BirthDate = birthDate;
        //    BirthPlace = birthPlace;
        //    //Address = address;
        //    OwnerId = ownerId;
        //}
        //}

        static void Create(string entity)
        {

            switch (entity) 
            {
                case "Auto":
                    try
                    {
                        Console.Write("Enter car: ");
                        string car = Console.ReadLine();
                        string cBrand = car.Split(' ')[0];
                        string cType = car.Split(' ')[1];
                        Console.Write("Enter car's vintage: ");
                        int vintage = int.Parse(Console.ReadLine());
                        Console.Write("Enter car's ownerId: ");
                        int ownerID = int.Parse(Console.ReadLine());
                        Console.Write("Enter car's autoId: ");
                        int autoId = int.Parse(Console.ReadLine());
                        Console.Write("Enter car's brandId: ");
                        int brandId = int.Parse(Console.ReadLine());
                        rest.Post(new Auto() { Brand = cBrand, Type = cType, Vintage = vintage, OwnerId = ownerID, AutoId = autoId, BrandId = brandId}, "auto");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Brand":
                    try
                    {
                        Console.Write("Enter brandId: ");
                        int brandId = int.Parse(Console.ReadLine());
                        Console.Write("Enter brand name: ");
                        string brandName = Console.ReadLine();
                        Console.Write("Enter the capital of the brand: ");
                        string brandOrigin = Console.ReadLine();
                        Console.Write("Enter the born year of the brand: ");
                        int bornOfBrand = int.Parse(Console.ReadLine());
                        Console.Write("Is the company producing electric cars? (true/false): ");
                        bool hasElectricCars = bool.Parse(Console.ReadLine());
                        Console.Write("Has the company Formula 1 team? (true/false): ");
                        bool hasFormula1Team = bool.Parse(Console.ReadLine());
                        Console.Write("Enter the concernId: ");
                        int concernId = int.Parse(Console.ReadLine());
                        rest.Post(new Brand() { BrandId = brandId, BrandName = brandName, OriginOfBrand = brandOrigin, BornOfBrand = bornOfBrand, IsProducingFullyElectricCars = hasElectricCars, HasFormula1Team = hasFormula1Team, ConcernId = concernId }, "brand");

                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Owner":
                    try
                    {
                        Console.Write("Enter owner name: ");
                        string oName = Console.ReadLine();
                        Console.Write("Enter owner's birth date: ");
                        string birthDate = Console.ReadLine();
                        Console.Write("Enter owner's birth place: ");
                        string birthPlace = Console.ReadLine();
                        Console.Write("Enter ownerId: ");
                        int ownerId = int.Parse(Console.ReadLine());
                        rest.Post(new Owner() { Name = oName, BirthDate = birthDate, BirthPlace = birthPlace, OwnerId = ownerId}, "owner");

                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Concern":
                    try
                    {
                        Console.Write("Enter concern Id: ");
                        int concernId = int.Parse(Console.ReadLine());
                        Console.Write("Enter concern name: ");
                        string concernName = Console.ReadLine();
                        Console.Write("Enter the birth year of the concern: ");
                        int birthOfConcern = int.Parse(Console.ReadLine());
                        Console.Write("Enter the home country of the concern: ");
                        string homeOfConcern = Console.ReadLine();
                        Console.Write("Enter the position in world rankings: ");
                        int positionInRankings = int.Parse(Console.ReadLine());
                        rest.Post(new Concern() { ConcernId = concernId, ConcernName = concernName, BornOfConcern = birthOfConcern, CountryOfConcern = homeOfConcern, PositionInRanking = positionInRankings}, "concern");


                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid entity");
                    break;
            }
        }

        static void Read(string entity)
        {
            switch (entity)
            {
                case "Auto":
                    List<Auto> autos = rest.Get<Auto>("Auto");
                    Console.WriteLine();
                    Console.WriteLine("===============================================");
                    foreach (var item in autos)
                    {
                        Console.Write($"{item.Brand}\t{item.Type}\n\t{item.Vintage}\t{item.OwnerId}\t{item.AutoId}\t{item.BrandId}");
                        if (item._Owner == null)
                        {
                            Console.Write("Owner has been deleted\n=================================================\n");
                        }
                        else { Console.Write($"{item._Owner.Name}\n=================================================\n"); }
                    }

                    break;
                case "Brand":
                    List<Brand> brands = rest.Get<Brand>("Brand");
                    Console.WriteLine();
                    Console.WriteLine("===============================================");
                    foreach (var item in brands) 
                    {
                        Console.WriteLine($"{item.BrandId}\t{item.BrandName}\n\t{item.OriginOfBrand}\t{item.BornOfBrand}\t{item.IsProducingFullyElectricCars}\t{item.HasFormula1Team}\t{item.ConcernId}");
                    }
                    break;
                case "Owner":
                    List<Owner> owners = rest.Get<Owner>("Owner");
                    Console.WriteLine();
                    Console.WriteLine("===============================================");
                    foreach(var item in owners)
                    {
                        Console.WriteLine($"{item.Name}\n\t{item.BirthDate}\t{item.BirthPlace}\t{item.OwnerId}");
                    }

                    break;
                case "Concern":
                    List<Concern> concerns = rest.Get<Concern>("Concern");
                    Console.WriteLine();
                    Console.WriteLine("===============================================");
                    foreach (var item in concerns)
                    {
                        Console.WriteLine($"{item.ConcernId}\t{item.ConcernName}\n\t{item.BornOfConcern}\t{item.CountryOfConcern}\t{item.PositionInRanking}");
                    }

                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Auto")
            {
                List<Auto> cars = rest.Get<Auto>("auto");
                foreach (var item in cars)
                {
                    Console.WriteLine(item.AutoId + ": " + item.Brand + " " + item.Type);
                }

            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.Write($"Enter {entity}'s Id to update: ");
            int updateid = int.Parse(Console.ReadLine());
            switch(entity)
            {
                case "Auto":
                    try
                    {
                     
                        Auto autoUpdate = rest.Get<Auto>(updateid, "Auto/");
                        Console.Write($"Enter New car brand [old: {autoUpdate.Brand}]: ");
                        string brandName = Console.ReadLine();
                        Console.Write($"Enter New car type [old: {autoUpdate.Type}]: ");
                        string newType = Console.ReadLine();
                        Console.Write($"Enter New car vintage [old: {autoUpdate.Vintage}]: ");
                        int newVintage = int.Parse(Console.ReadLine());
                        Console.Write($"Enter New car ownerId [old: {autoUpdate.OwnerId}]: ");
                        int newOwnerId = int.Parse(Console.ReadLine());
                        Console.Write($"Enter New car autoId [old: {autoUpdate.AutoId}]: ");
                        int newAutoId = int.Parse(Console.ReadLine());
                        Console.Write($"Enter New car brandId [old: {autoUpdate.BrandId}]: ");
                        int newBrandId = int.Parse(Console.ReadLine());
                        rest.Put(autoUpdate, "auto");

                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"There was an error: {e.Message}");
                        
                    }
                    break;
                case "Brand":
                    try
                    {
                        Brand brandUpdate = rest.Get<Brand>(updateid, "Brand/");
                        Console.Write($"Enter new brand ID: [old: {brandUpdate.BrandId}]: ");
                        int newBrandId = int.Parse(Console.ReadLine());
                        Console.Write($"Enter new brand name: [old: {brandUpdate.BrandName}]: ");
                        string newBrandName = Console.ReadLine();
                        Console.Write($"Enter new brand origin: [old: {brandUpdate.OriginOfBrand}]: ");
                        string newOrigin = Console.ReadLine();
                        Console.Write($"Enter new brand birth year: [old: {brandUpdate.BornOfBrand}]: ");
                        int newBornDate = int.Parse(Console.ReadLine());
                        Console.Write($"Enter new brand production of electric cars(true/false): [old: {brandUpdate.IsProducingFullyElectricCars}]: ");
                        bool newIsProducingFullyElectricCars = bool.Parse(Console.ReadLine());
                        Console.Write($"Enter new brand status of having Formula 1 team(true/false): [old: {brandUpdate.HasFormula1Team}]:");
                        bool newHasFormula1Team = bool.Parse(Console.ReadLine());
                        Console.Write($"Enter new concern id: [old: {brandUpdate.ConcernId}]: ");
                        int newConcernId = int.Parse(Console.ReadLine());
                        rest.Put(brandUpdate, "brand");


                    }
                    catch (ArgumentException e)
                    {

                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Owner":
                    try
                    {
                        Owner ownerUpdate = rest.Get<Owner>(updateid, "Owner/");
                        Console.Write($"Enter new owner name: [old: {ownerUpdate.Name}]: ");
                        string newName = Console.ReadLine();
                        Console.Write($"Enter new owner birth date: [old: {ownerUpdate.BirthDate}]: ");
                        string newBirthDate = Console.ReadLine();
                        Console.Write($"Enter new owner birth place: [old: {ownerUpdate.BirthPlace}]: ");
                        string newBirthPlace = Console.ReadLine();
                        Console.Write($"Enter new owner ID: [old: {ownerUpdate.OwnerId}]: ");
                        int newOwnerId = int.Parse(Console.ReadLine());
                        rest.Put(ownerUpdate, "Owner");


                    }
                    catch (ArgumentException e)
                    {

                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                case "Concern":
                    try
                    {
                        Concern concernUpdate = rest.Get<Concern>(updateid, "Concern/");
                        Console.Write($"Enter new concern ID: [old: {concernUpdate.ConcernId}]: ");
                        int newConcernID = int.Parse(Console.ReadLine());
                        Console.Write($"Enter new concern name: [old: {concernUpdate.ConcernName}]: ");
                        string newName = Console.ReadLine();
                        Console.Write($"Enter new concern birth year: [old: {concernUpdate.BornOfConcern}]: ");
                        int newBornOfConcern = int.Parse(Console.ReadLine());
                        Console.Write($"Enter new concern home country: [old: {concernUpdate.CountryOfConcern}]: ");
                        string newCountryOfConcern = Console.ReadLine();
                        Console.Write($"Enter new concern ranking in the world: [old: {concernUpdate.PositionInRanking}]: ");
                        int newPositionInRankings = int.Parse(Console.ReadLine());
                        rest.Put(concernUpdate, "concern");

                    }
                    catch (ArgumentException e)
                    {

                        Console.WriteLine($"There was an error: {e.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid entity");
                    break;
            }
            
        }
        static void Delete(string entity)
        {
            if (entity == "Auto")
            {
                Console.Write("Enter the Auto's Id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "auto");
            }
        }

        static void Main(string[] args)
        {
            
            rest = new RestService("http://localhost:21840/", "auto");

            var autoSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Auto"))
                .Add("Create", () => Create("Auto"))
                .Add("Delete", () => Delete("Auto"))
                .Add("Update", () => Update("Auto"))
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var concernSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Concern"))
                .Add("Create", () => Create("Concern"))
                .Add("Delete", () => Delete("Concern"))
                .Add("Update", () => Update("Concern"))
                .Add("Exit", ConsoleMenu.Close);

            var ownerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Owner"))
                .Add("Create", () => Create("Owner"))
                .Add("Delete", () => Delete("Owner"))
                .Add("Update", () => Update("Owner"))
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
