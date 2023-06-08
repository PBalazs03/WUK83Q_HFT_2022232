using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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


      

        [SetUp]
        public void Initialize()
        {
           
            _autorepository = new Mock<IRepository<Auto>>();
            _autorepository.Setup(auto => auto.ReadAll()).Returns(new List<Auto>()
            {
                new Auto("Acura", "Integra", 1996, 18, 139, 19),
                new Auto("Honda", "Jazz", 2018, 17, 140, 19),
                new Auto("Isuzu", "D-Max", 2005, 18, 141, 23),
                new Auto("Ssangyong", "Korando", 2023, 19, 142, 22),
                new Auto("Land Rover", "Discovery", 2020, 19, 143, 21),
                new Auto("Land Rover", "Range Rover", 2018, 19, 144, 21),
                new Auto("Jaguar", "F-Type", 2018, 16, 144, 20),
                
            }.AsQueryable());

            
            _brandrepository = new Mock<IRepository<Brand>>();
            _brandrepository.Setup(brand => brand.ReadAll()).Returns(new List<Brand>()
            {
                new Brand(19, "Honda", "Japan", 1948, true, false, 007),
                new Brand(20, "Jaguar", "UK", 1922, false, false, 016),
                new Brand(21, "Land Rover", "UK", 1978, false, false, 016),
                new Brand(22, "Ssangyong", "South-Korea", 1954, false, false, 017),
                new Brand(23, "Isuzu", "Japan", 1916, false, false,18),
                
            }.AsQueryable());

            
            _concernrepository = new Mock<IRepository<Concern>>();
            _concernrepository.Setup(concern => concern.ReadAll()).Returns(new List<Concern>()
            {
                new Concern(007, "Honda Motor Company", 1948, "Japan", 8),
                new Concern(016, "Tata Motors", 1945, "India", 21),
                new Concern(017, "Mahindra & Mahindra", 1945, "India", 24),
                new Concern(018, "Isuzu", 1916, "Japan", 25),
            }.AsQueryable());

            
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
            var ownedcar = autologic.CarOwnedByOwner(99);
        }

        [Test]
        public void ReadOwnerTest()
        {
            Owner createdOwner = new Owner("TestPerson", "9999.99.99", "Place", 99);
            ownerlogic.Read(99);

            _ownerrepository.Verify(owner => owner.Read(99), Times.Once);
        }



        [Test]
        public void ModelsOfBrandTest()
        {
            var modelsOfBrand = brandlogic.ModelsOfBrand("Toyota");
            Assert.That(modelsOfBrand.Equals(modelsOfBrand));
        }

        

        [Test]
        public void AverageVintageTest()
        {
            double? avg = autologic.AverageVintage();
            Assert.That(2014, Is.EqualTo(avg));
        }
    }
}
