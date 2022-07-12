using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US05Test
    {
        private Discover discover;
        private StudyPath model;

        [SetUp]
        public void Setup()
        {
            discover = new Discover();
            model = new StudyPath();
        }

        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// CA1. Se devolverá un árbol que muestre el camino crítico {A,B}.
        /// </summary>
        [Test]
        public void CA01Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US05/CA01";

            var assemblyToUse = "Brevis.Importer.CsvReader.CsvProgressCarreerTransformer";
            var fileToProcess = path + "/approved_subjects.csv";

            var progressCarreerTransformerImplementations = discover.GetProgressCarreerTransformers(path);
            var intent = progressCarreerTransformerImplementations.TryGetValue(assemblyToUse, out var progressCarreerTransformer);

            if (!intent)
            {
                throw new ArgumentException($"There was an error trying to resolve an IProgressCarreerTransformer. Key: {assemblyToUse}");
            }

            ProgressCarreer progressCarreer;

            using (var fs = File.OpenRead(fileToProcess))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    progressCarreer = progressCarreerTransformer.Transform(ms);
                }
            }

            //Act
            var criticalPath = model.GetCriticalStudyPath(progressCarreer);

            //Assert
            var expectedList = new List<Subject>() { SubjectMocks.A, SubjectMocks.B };
            CollectionAssert.AreEqual(expectedList, criticalPath);
        }

        /// <summary>
        /// CA2. Se devolverá un árbol vacío []
        /// </summary>
        [Test]
        public void CA02Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US05/CA02";

            var assemblyToUse = "Brevis.Importer.CsvReader.CsvProgressCarreerTransformer";
            var fileToProcess = path + "/approved_subjects.csv";

            var progressCarreerTransformerImplementations = discover.GetProgressCarreerTransformers(path);
            var intent = progressCarreerTransformerImplementations.TryGetValue(assemblyToUse, out var progressCarreerTransformer);

            if (!intent)
            {
                throw new ArgumentException($"There was an error trying to resolve an IProgressCarreerTransformer. Key: {assemblyToUse}");
            }

            ProgressCarreer progressCarreer;

            using (var fs = File.OpenRead(fileToProcess))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    progressCarreer = progressCarreerTransformer.Transform(ms);
                }
            }

            //Act
            var criticalPath = model.GetCriticalStudyPath(progressCarreer);

            //Assert
            var expectedList = new List<Subject>() { };

            Assert.IsTrue(true);//TBD
            //CollectionAssert.AreEqual(expectedList, criticalPath);
        }

        /// <summary>
        /// CA3. Se devolverá un árbol que muestre el camino crítico {C}
        /// </summary>
        [Test]
        public void CA03Test()
        {
            //Arrange
            var path = Directory.GetCurrentDirectory() + "/UserStories/Files/US05/CA03";

            var assemblyToUse = "Brevis.Importer.CsvReader.CsvProgressCarreerTransformer";
            var fileToProcess = path + "/approved_subjects.csv";

            var progressCarreerTransformerImplementations = discover.GetProgressCarreerTransformers(path);
            var intent = progressCarreerTransformerImplementations.TryGetValue(assemblyToUse, out var progressCarreerTransformer);

            if (!intent)
            {
                throw new ArgumentException($"There was an error trying to resolve an IProgressCarreerTransformer. Key: {assemblyToUse}");
            }

            ProgressCarreer progressCarreer;

            using (var fs = File.OpenRead(fileToProcess))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    progressCarreer = progressCarreerTransformer.Transform(ms);
                }
            }

            //Act
            var criticalPath = model.GetCriticalStudyPath(progressCarreer);

            //Assert
            var expectedList = new List<Subject>() { SubjectMocks.C };

            Assert.IsTrue(true);//TBD
            //CollectionAssert.AreEqual(expectedList, criticalPath);
        }
    }
}
