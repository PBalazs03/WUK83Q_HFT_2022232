using NUnit.Framework;
using System;
using WUK83Q_HFT_2022232.Models;

namespace WUK83Q_HFT_2022232.Test
{
    [TestFixture]
    public class TesterClass
    {
        private YourClass yourObject;

        [SetUp]
        public void SetUp()
        {
            // Inicializáld az objektumot a teszt előtt
            yourObject = new YourClass();
        }

        [Test]
        public void AverageVintage_ShouldReturnAverageVintage()
        {
            // Arrange
            var cars = new[]
            {
                new Auto { Vintage = 2000 },
                new Auto { Vintage = 2010 },
                new Auto { Vintage = 1995 }
            };

            yourObject.repo = new YourRepository(cars);

            // Act
            var average = yourObject.AverageVintage();

            // Assert
            Assert.AreEqual(2005, average);
        }

        [Test]
        public void YoungestOrOldestCar_WhenYoung_ReturnsYoungestCar()
        {
            // Arrange
            var cars = new[]
            {
                new Auto { Vintage = 2000 },
                new Auto { Vintage = 2010 },
                new Auto { Vintage = 1995 }
            };

            yourObject.repo = new YourRepository(cars);

            // Act
            var result = yourObject.YoungestOrOldestCar('y');

            // Assert
            Assert.AreEqual(2010, result.Vintage);
        }

        [Test]
        public void YoungestOrOldestCar_WhenOld_ReturnsOldestCar()
        {
            // Arrange
            var cars = new[]
            {
                new Auto { Vintage = 2000 },
                new Auto { Vintage = 2010 },
                new Auto { Vintage = 1995 }
            };

            yourObject.repo = new YourRepository(cars);

            // Act
            var result = yourObject.YoungestOrOldestCar('o');

            // Assert
            Assert.AreEqual(1995, result.Vintage);
        }

        [Test]
        public void YoungestOrOldestCar_WhenInvalidChar_ReturnsNull()
        {
            // Arrange
            var cars = new[]
            {
                new Auto { Vintage = 2000 },
                new Auto { Vintage = 2010 },
                new Auto { Vintage = 1995 }
            };

            yourObject.repo = new YourRepository(cars);

            // Act
            var result = yourObject.YoungestOrOldestCar('x');

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void CountAutosByOwner_ShouldReturnNumberOfAutosForOwner()
        {
            // Arrange
            var owner = new Owner { OwnerId = 1 };
            owner.Autos = new[]
            {
                new Auto { Vintage = 2000 },
                new Auto { Vintage = 2010 },
                new Auto { Vintage = 1995 }
            };

            yourObject.repo = new YourRepository();
            yourObject.repo.Add(owner);

            // Act
            var result = yourObject.CountAutosByOwner(1);

            // Assert
            Assert.AreEqual(3, result);
        }
    }
}
}
