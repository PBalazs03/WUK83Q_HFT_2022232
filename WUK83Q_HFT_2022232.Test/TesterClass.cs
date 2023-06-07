using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WUK83Q_HFT_2022232.Logic;
using WUK83Q_HFT_2022232.Models;
using WUK83Q_HFT_2022232.Repository;

namespace WUK83Q_HFT_2022232.Test
{
    [TestFixture]
    public class TesterClass
    {
        AutoLogic autologic;
        Mock<IRepository<Auto>> _autorepository;

        BrandLogic brandlogic;
        Mock<IRepository<Brand>> _brandrepository;

        ConcernLogic concernlogic;
        Mock<IRepository<Concern>> _concernrepository;

        OwnerLogic ownerlogic;
        Mock<IRepository<Owner>> _ownerrepository;


        //public Auto(string brand, string type, int vintage, int ownerId, int autoId, int brandId)
        //{
        //    AutoId = autoId;
        //    Brand = brand;
        //    Type = type;
        //    OwnerId = ownerId;
        //    Vintage = vintage;
        //    BrandId = brandId;

        //}
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

        //new Owner("Kiss Pál", "1968.06.07.", "Budapest", 1),
        //        new Owner("Nagy András", "1963.09.01.", "Kaposvár", 2),
        //        new Owner("Lakatos József", "1974.03.21.", "Miskolcs", 3),
        //        new Owner("Veres Andor", "1993.10.10.", "Pécel", 4),
        //        new Owner("Kovács Júlia", "1973.01.30.", "Székesfehérvár", 5),
        //        new Owner("Kis Ferencné", "1962.05.01.", "Debrecen", 6),
        //        new Owner("Budai Ildikó", "1968.06.07.", "Veszprém", 7),
        //        new Owner("Pesti Balázs", "2001.12.04.", "Budapest", 8),
        //        new Owner("Kovács Károly", "1971.11.11.", "Szeged", 9),
        //        new Owner("Gazdag Imre", "1969.04.13.", "Szentendre", 10),
        //        new Owner("Papp Elek", "1992.12.13.", "Győr", 11),
        //        new Owner("Fekete József", "1970.01.04.", "Siófok", 12),
        //        new Owner("Szegedi Péter", "1980.07.10.", "Szombathely", 13),
        //        new Owner("Horváth Tamás", "1976.06.01.", "Piliscsaba", 14),
        //        new Owner("Gáspár József", "1970.09.09.", "Gyömrő", 15),


        //new Auto("Kia", "Carens", 2008, 8, 111, 01),
        //        new Auto("BMW", "M4", 2014, 4, 112, 04),
        //        new Auto("Kia", "Ceed", 2013, 1, 113, 01),
        //        new Auto("Opel", "Corsa", 2016, 1, 114, 05),
        //        new Auto("Suzuki", "Swift", 2001, 2, 115, 06),
        //        new Auto("Mercedes-Benz", "C36 AMG", 2011, 3, 116, 03),
        //        new Auto("Audi", "A8", 2018, 3, 117, 07),
        //        new Auto("Volkswagen", "Golf", 2008, 4, 118, 08),
        //        new Auto("Toyota", "Avensis", 2007, 2, 119, 02),
        //        new Auto("Peugeot", "306", 2004, 5, 120, 09),
        //        new Auto("Renault", "Clio", 2015, 6, 121, 10),
        //        new Auto("Fiat", "Bravo", 2009, 7, 122, 11),
        //        new Auto("Toyota", "Corolla", 2017, 7, 123, 02),
        //        new Auto("Mercedes-Benz", "C63 AMG", 2016, 8, 124, 03),
        //        new Auto("Nissan", "Qashqai", 2010, 9, 125, 12),
        //        new Auto("Ferrari", "Roma", 2021, 10, 126, 13),
        //        new Auto("Mercedes-Benz", "G63 AMG", 2022, 10, 127, 03),
        //        new Auto("Alfa Romeo", "Giulia", 2018, 9, 128, 14),
        //        new Auto("Aston Martin", "DB9", 2005, 10, 129, 15),
        //        new Auto("Ford", "Mustang", 2013, 11, 130, 16),
        //        new Auto("Ford", "Kuga", 2014, 12, 131, 16),
        //        new Auto("Nissan", "Micra", 2013, 13, 132, 12),
        //        new Auto("Opel", "Insignia", 2013, 13, 133, 05),
        //        new Auto("BMW", "I3", 2013, 12, 134, 04),
        //        new Auto("Toyota", "Celica", 1992, 12, 135, 02),
        //        new Auto("Tesla", "Model S", 2016, 14, 136, 17),
        //        new Auto("Volkswagen", "ID.3", 2022, 14, 137, 08),
        //        new Auto("Cadillac", "Escalade", 2013, 15, 138, 18)


        //new Brand(01, "Kia", "South-Korea", 1944, true, false, 010),
        //        new Brand(02, "Toyota", "Japan", 1936, false, false, 003),
        //        new Brand(03, "Mercedes-Benz", "Germany", 1890, true, true, 004),
        //        new Brand(04, "BMW", "Germany", 1916, true, false, 006),
        //        new Brand(05, "Opel", "Germany", 1862, true, false, 001),
        //        new Brand(06, "Suzuki", "Japan", 1909, false, false, 013),
        //        new Brand(07, "Audi", "Germany", 1932, true, false, 002),
        //        new Brand(08, "Volkswagen", "Germany", 1937, true, false, 002),
        //        new Brand(09, "Peugeot", "France", 1810, true, false, 001),
        //        new Brand(10, "Renault", "France", 1889, true, false, 011),
        //        new Brand(11, "Fiat", "Italy", 1899, true, false, 001),
        //        new Brand(12, "Nissan", "Japan", 1930, true, false, 011),
        //        new Brand(13, "Ferrari", "Italy", 1947, false, true, 001),
        //        new Brand(14, "Alfa Romeo", "Italy", 1910, false, true, 001),
        //        new Brand(15, "Aston Martin", "England", 1913, false, true, 015),
        //        new Brand(16, "Ford", "Germany", 1903, true, false, 005),
        //        new Brand(17, "Tesla", "USA", 2003, true, false, 014),
        //        new Brand(18, "Cadillac", "USA", 1902, true, false, 008),


        //new Concern(001, "Stellanois", 2021, "Netherland", 3),
        //        new Concern(002, "Volkswagen AG", 1937, "Germany", 1),
        //        new Concern(003, "Toyota", 1936, "Japan", 2),
        //        new Concern(004, "Mercedes-Benz Group", 1926, "Germany", 4),
        //        new Concern(005, "Ford Motor Company", 1903, "USA", 6),
        //        new Concern(006, "Bayerische Motoren Werke AG", 1916, "Germany", 7),
        //       
        //        new Concern(008, "General Motors", 1908, "USA", 9),
        //        new Concern(009, "SAIC Motor", 1997, "China", 10),
        //        new Concern(010, "Hyundai Motor Group", 1967, "South-Korea", 12),
        //        new Concern(011, "Renault-Nissan-Mitsubishi", 2017, "France-Japan", 5),
        //        new Concern(012, "Geely", 2017, "France-Japan", 13),
        //        new Concern(013, "Suzuki", 1909, "Japan", 22),
        //        new Concern(014, "Tesla", 2003, "USA", 19),
        //        new Concern(015, "Aston Martin", 1913, "England", 23),

        [SetUp]
        public void Initialize()
        {
            //public Auto(string brand, string type, int vintage, int ownerId, int autoId, int brandId)
            _autorepository = new Mock<IRepository<Auto>>();
            _autorepository.Setup(auto => auto.ReadAll()).Returns(new List<Auto>()
            {
                new Auto("Acura", "Integra", 1996, 18, 139, 19),
                new Auto("Honda", "Jazz", 2018, 17, 140, 19),
                new Auto("Isuzu", "D-Max", 2005, 18, 141, 23),
                new Auto("Ssangyong", "Korando", 2023, 19, 142, 22),
                new Auto("Land Rover", "Discovery", 2020, 16, 143, 21),
                new Auto("Land Rover", "Range Rover", 2018, 19, 144, 21),
                new Auto("Jaguar", "F-Type", 2018, 16, 144, 20),
            }.AsQueryable());

            //public Brand(int brandId, string brandName, string originOfBrand, int bornOfBrand, bool isProducingFullyElectricCars, bool hasFormula1Team, int concernId)
            _brandrepository = new Mock<IRepository<Brand>>();
            _brandrepository.Setup(brand => brand.ReadAll()).Returns(new List<Brand>()
            {
                new Brand(19, "Honda", "Japan", 1948, true, false, 007),
                new Brand(20, "Jaguar", "UK", 1922, false, false, 016),
                new Brand(21, "Land Rover", "UK", 1978, false, false, 016),
                new Brand(22, "Ssangyong", "South-Korea", 1954, false, false, 017),
                new Brand(23, "Isuzu", "Japan", 1916, false, false,18),
                
            }.AsQueryable());

            //public Concern(int concernId, string concernName, int bornOfConcern, string countryOfTheConcern, int positionInRanking)
            _concernrepository = new Mock<IRepository<Concern>>();
            _concernrepository.Setup(concern => concern.ReadAll()).Returns(new List<Concern>()
            {
                new Concern(007, "Honda Motor Company", 1948, "Japan", 8),
                new Concern(016, "Tata Motors", 1945, "India", 21),
                new Concern(017, "Mahindra & Mahindra", 1945, "India", 24),
                new Concern(018, "Isuzu", 1916, "Japan", 25),
            }.AsQueryable());

            //public Owner(string name, string birthDate, string birthPlace, int ownerId)
            _ownerrepository = new Mock<IRepository<Owner>>();
            _ownerrepository.Setup(owner => owner.ReadAll()).Returns(new List<Owner>()
            {
                new Owner("Nagy Károly", "1954.12.12", "Budapest", 16),
                new Owner("Kiss Marika", "1964.03.04", "Győr", 17),
                new Owner("Fekete Péter", "1970.07.01", "Berettyóújfalu", 18),
                new Owner("Juhász József", "1973.07.21", "Kecskemét", 19)
            }.AsQueryable());

            autologic = new AutoLogic(_autorepository.Object);
            brandlogic = new BrandLogic(_brandrepository.Object);
            concernlogic = new ConcernLogic(_concernrepository.Object);
            ownerlogic = new OwnerLogic(_ownerrepository.Object);
        }

        [Test]
        public void CreateCar()
        {
            Auto createdCar = new Auto("TestBrand", "TestType", 1234, 99, 999, 89);

            autologic.Create(createdCar);
            _autorepository.Verify(car => car.Create(createdCar), Times.Once);
        }
        [Test]
        public void CreateBrand()
        {
            Brand createdBrand = new Brand(89, "TestBrand", "Place", 9999, true, false, 907);

            brandlogic.Create(createdBrand);
            _brandrepository.Verify(brand => brand.Create(createdBrand), Times.Once);
        }
        [Test]
        public void CreateConcern()
        {
            Concern createdConcern = new Concern(907, "TestConcern", 9999, "Place", 100);

            concernlogic.Create(createdConcern);
            _concernrepository.Verify(concern => concern.Create(createdConcern), Times.Once);
        }
        [Test]
        public void CreateOwner()
        {
            Owner createdOwner = new Owner("TestPerson", "9999.99.99", "Place", 99);

            ownerlogic.Create(createdOwner);
            _ownerrepository.Verify(owner => owner.Create(createdOwner), Times.Once);
        }
        [Test]
        public void DeleteOwner()
        {
            Owner createdOwner = new Owner("TestPerson", "9999.99.99", "Place", 99);
            ownerlogic.Create(createdOwner);

            ownerlogic.Delete(99);

            _ownerrepository.Verify(owner => owner.Delete(99), Times.Once);
        }
        [Test]
        public void DeleteCar()
        {
            Auto createdCar = new Auto("TestBrand", "TestType", 1234, 99, 999, 89);
            autologic.Create(createdCar);

            autologic.Delete(999);

            _autorepository.Verify(car => car.Delete(999), Times.Once);
        }
        [Test]
        public void CarOwnedByOwnerTest()
        {
            //var ownedcar = autologic.CarOwnedByOwner(99);
        }

        [Test]
        public void BrandWithTheMostCarsTest()
        {
            var brandWithTheMostCars = brandlogic.BrandWithTheMostCars();
            Assert.That(brandWithTheMostCars.Equals("Toyota"));
        }



        [Test]
        public void ModelsOfBrandTest()
        {
            var modelsOfBrand = brandlogic.ModelsOfBrand("Mercedes-Benz");
            Assert.That(modelsOfBrand.Equals("Mercedes-Benz"));
        }
        
        //public void OwnerWithTheMostCarsTest()
        //{
        //    var ownerWithTheMostCars = ownerlogic.OwnerWithTheMostCars();
        //    Assert.That(ownerWithTheMostCars.)
        //}

        [Test]
        public void CountAutosByOwnerTest()
        {
            var countAutosByOwner = ownerlogic.CountAutosByOwner(1);
            Assert.That(countAutosByOwner.Equals(1));
        }
        [Test]
        public void AverageVintageTest()
        {
            double? avg = autologic.AverageVintage();
            Assert.That(2014, Is.EqualTo(avg));
        }
        //private YourClass yourObject;

        //[SetUp]
        //public void SetUp()
        //{
        //    // Inicializáld az objektumot a teszt előtt
        //    yourObject = new YourClass();
        //}

        //[Test]
        //public void AverageVintage_ShouldReturnAverageVintage()
        //{
        //    // Arrange
        //    var cars = new[]
        //    {
        //        new Auto { Vintage = 2000 },
        //        new Auto { Vintage = 2010 },
        //        new Auto { Vintage = 1995 }
        //    };

        //    yourObject.repo = new YourRepository(cars);

        //    // Act
        //    var average = yourObject.AverageVintage();

        //    // Assert
        //    Assert.AreEqual(2005, average);
        //}

        //[Test]
        //public void YoungestOrOldestCar_WhenYoung_ReturnsYoungestCar()
        //{
        //    // Arrange
        //    var cars = new[]
        //    {
        //        new Auto { Vintage = 2000 },
        //        new Auto { Vintage = 2010 },
        //        new Auto { Vintage = 1995 }
        //    };

        //    yourObject.repo = new YourRepository(cars);

        //    // Act
        //    var result = yourObject.YoungestOrOldestCar('y');

        //    // Assert
        //    Assert.AreEqual(2010, result.Vintage);
        //}

        //[Test]
        //public void YoungestOrOldestCar_WhenOld_ReturnsOldestCar()
        //{
        //    // Arrange
        //    var cars = new[]
        //    {
        //        new Auto { Vintage = 2000 },
        //        new Auto { Vintage = 2010 },
        //        new Auto { Vintage = 1995 }
        //    };

        //    yourObject.repo = new YourRepository(cars);

        //    // Act
        //    var result = yourObject.YoungestOrOldestCar('o');

        //    // Assert
        //    Assert.AreEqual(1995, result.Vintage);
        //}

        //[Test]
        //public void YoungestOrOldestCar_WhenInvalidChar_ReturnsNull()
        //{
        //    // Arrange
        //    var cars = new[]
        //    {
        //        new Auto { Vintage = 2000 },
        //        new Auto { Vintage = 2010 },
        //        new Auto { Vintage = 1995 }
        //    };

        //    yourObject.repo = new YourRepository(cars);

        //    // Act
        //    var result = yourObject.YoungestOrOldestCar('x');

        //    // Assert
        //    Assert.IsNull(result);
        //}

        //[Test]
        //public void CountAutosByOwner_ShouldReturnNumberOfAutosForOwner()
        //{
        //    // Arrange
        //    var owner = new Owner { OwnerId = 1 };
        //    owner.Autos = new[]
        //    {
        //        new Auto { Vintage = 2000 },
        //        new Auto { Vintage = 2010 },
        //        new Auto { Vintage = 1995 }
        //    };

        //    yourObject.repo = new YourRepository();
        //    yourObject.repo.Add(owner);

        //    // Act
        //    var result = yourObject.CountAutosByOwner(1);

        //    // Assert
        //    Assert.AreEqual(3, result);
        //}
    }
}
