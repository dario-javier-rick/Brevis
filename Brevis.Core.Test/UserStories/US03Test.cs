using Brevis.Core.Models;
using NUnit.Framework;
using System;
using System.IO;

namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US03Test
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
        /// CA1. El discovery de la aplicación es capaz de resolver el lector de .XLSX correspondiente a la .dll integrada.
        /// </summary>
        [Test]
        public void CA01Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US03/CA01"; ;

            //Act
            var result = discover.GetProgressCarreerTransformers(path);

            //Assert
            Assert.IsTrue(result.ContainsKey("Brevis.Importer.XlsReader.XlsProgressCarreerTransformer"));
        }

        /// <summary>
        /// CA2. El archivo se procesa correctamente.
        /// </summary>
        [Test]
        public void CA02Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US03/CA02";

            var assemblyToUse = "Brevis.Importer.XlsReader.XlsProgressCarreerTransformer";
            var fileToProcess = path + "/approved_subjects.xlsx";

            //Act
            var progressCarreerTransformerImplementations = discover.GetProgressCarreerTransformers(path);
            var intent = progressCarreerTransformerImplementations.TryGetValue(assemblyToUse, out var progressCarreerTransformer);

            if (!intent)
            {
                throw new ArgumentException($"There was an error trying to resolve an IProgressCarreerTransformer. Key: {assemblyToUse}");
            }

            ProgressCarreer progressCarrer;

            using (var fs = File.OpenRead(fileToProcess))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    progressCarrer = progressCarreerTransformer.Transform(ms);
                }
            }

            //Assert
            Assert.IsTrue(progressCarrer.CurriculumCode == "Plan");
        }

    }
}
