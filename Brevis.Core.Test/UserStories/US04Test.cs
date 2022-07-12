using Brevis.Core.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US04Test
    {
        private Discover discover;
        private ProgressCarreerImplementations _progressCarreerImplementations;

        public Dictionary<string, string> _progressCarreerTransformerImplementations = new Dictionary<string, string>();


        [SetUp]
        public void Setup()
        {
            discover = new Discover();
            _progressCarreerTransformerImplementations = new Dictionary<string, string>();
        }

        [TearDown]
        public void TearDown()
        {
            _progressCarreerImplementations = null;
            _progressCarreerTransformerImplementations = null;
        }

        /// <summary>
        /// CA1. El discovery de la aplicación no resuelve ningún lector. No se muestran implementaciones dentro de la lista.
        /// </summary>
        [Test]
        public void CA01Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US04/CA01"; ;
            _progressCarreerImplementations = new ProgressCarreerImplementations(discover.GetProgressCarreerTransformers(path));

            //Act
            foreach (var progressCarreerImplementation in _progressCarreerImplementations.registeredImplementations)
            {
                var type = progressCarreerImplementation.Value.GetType();
                _progressCarreerTransformerImplementations.Add(type.Assembly.GetName().Name, progressCarreerImplementation.Key);
            }

            //Assert
            Assert.IsTrue(!_progressCarreerTransformerImplementations.Any());
        }

        /// <summary>
        /// CA2 . El discovery de la aplicación resuelve el lector .csv. Se muestra el nombre de la .dll y la implementación correspondiente dentro de la lista.
        /// </summary>
        [Test]
        public void CA02Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US04/CA02"; ;
            _progressCarreerImplementations = new ProgressCarreerImplementations(discover.GetProgressCarreerTransformers(path));

            //Act
            foreach (var progressCarreerImplementation in _progressCarreerImplementations.registeredImplementations)
            {
                var type = progressCarreerImplementation.Value.GetType();
                _progressCarreerTransformerImplementations.Add(type.Assembly.GetName().Name, progressCarreerImplementation.Key);
            }

            //Assert
            Assert.IsTrue(_progressCarreerTransformerImplementations.ContainsKey("Brevis.Importer.CsvReader"));
        }

        /// <summary>
        /// CA3 . El discovery de la aplicación resuelve los lectores .csv y .xlsx. Se muestran los nombres de las .dll y las implementaciones correspondientes dentro de la lista.
        /// </summary>
        [Test]
        public void CA03Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US04/CA03"; ;
            _progressCarreerImplementations = new ProgressCarreerImplementations(discover.GetProgressCarreerTransformers(path));

            //Act
            foreach (var progressCarreerImplementation in _progressCarreerImplementations.registeredImplementations)
            {
                var type = progressCarreerImplementation.Value.GetType();
                _progressCarreerTransformerImplementations.Add(type.Assembly.GetName().Name, progressCarreerImplementation.Key);
            }

            //Assert
            Assert.IsTrue(_progressCarreerTransformerImplementations.ContainsKey("Brevis.Importer.CsvReader")
                && _progressCarreerTransformerImplementations.ContainsKey("Brevis.Importer.XlsReader"));
        }
    }
}
