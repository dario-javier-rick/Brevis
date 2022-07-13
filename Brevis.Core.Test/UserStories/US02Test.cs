using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US02Test
    {
        private Discover discover;

        [SetUp]
        public void Setup()
        {
            discover = new Discover();
        }

        [TearDown]
        public void TearDown()
        {
            discover = null;
        }

        /// <summary>
        /// CA1. El discovery de la aplicación es capaz de resolver el lector de .csv correspondiente a la .dll integrada.
        /// </summary>
        [Test]
        public void US02_CA1()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US02/CA01";

            //Act
            var result = discover.GetProgressCarreerTransformers(path);

            //Assert
            Assert.IsTrue(result.ContainsKey("Brevis.Importer.CsvReader.CsvProgressCarreerTransformer"));
        }

        /// <summary>
        /// CA2. El discovery de la aplicación no es capaz de descubrir ninguna implementación.
        /// </summary>
        [Test]
        public void US02_CA2()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US02/CA02"; ;

            //Act
            var result = discover.GetProgressCarreerTransformers(path);

            //Assert
            Assert.IsTrue(!result.Any());
        }

        /// <summary>
        /// CA3 La aplicación permitirá agregar distintas implementaciones de lectores de archivos para diferentes formatos.
        // La aplicación debe decidir que implementación corresponde usar de forma automática.
        /// </summary>
        [Test]
        public void US02_CA3()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US02/CA03"; ;

            //Act
            var result = discover.GetProgressCarreerTransformers(path);

            //Assert
            Assert.IsTrue(result.ContainsKey("Brevis.Importer.CsvReader.CsvProgressCarreerTransformer")
                && result.ContainsKey("Brevis.Importer.XlsReader.XlsProgressCarreerTransformer"));
        }
    }
}
