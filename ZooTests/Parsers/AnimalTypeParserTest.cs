using System.IO;
using System.Linq;
using Xunit;
using Zoo;
using Zoo.Parsers;

namespace ZooTests.Parsers
{
    public class AnimalTypeParserTest
    {
        [Fact]
        public void ShouldCreateOneLionType()
        {
            const string type = "Lion";
            const double ratio = 0.3;
            const string diet = "meat";
            var animalTypesString = $"{type};{ratio};{diet}";
            var reader = new StringReader(animalTypesString);

            var types = new AnimalTypeParser().ParseTypes(reader);
            var lionType = types.ToList()[0];

            Assert.Equal(type, lionType.Animal);
            Assert.Equal(ratio, lionType.Ratio);
            Assert.Equal(Diet.Carnivore, lionType.Diet);
            Assert.Equal(0, lionType.MeatPercent);
        }

        [Fact]
        public void ShouldCreateWolfWithMeatPercent()
        {
            const string type = "Wolf";
            const double ratio = 0.3;
            const string diet = "meat";
            const double meatPercent = 10;
            var meatPercentDecimal = meatPercent / 100;
            var animalTypesString = $"{type};{ratio};{diet};{meatPercent}%";
            var reader = new StringReader(animalTypesString);

            var types = new AnimalTypeParser().ParseTypes(reader);
            var wolfType = types.ToList()[0];

            Assert.Equal(type, wolfType.Animal);
            Assert.Equal(ratio, wolfType.Ratio);
            Assert.Equal(Diet.Carnivore, wolfType.Diet);
            Assert.Equal(meatPercentDecimal, wolfType.MeatPercent);
        }
    }
}