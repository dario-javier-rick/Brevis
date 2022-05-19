using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brevis.Core.Test.Model
{
    [TestFixture]
    public class CurriculumModelTest
    {
        StudyPath model;

        [SetUp]
        public void Setup()
        {
            model = new StudyPath();
        }

        [Test]
        public void EmptyCollectionTest()
        {
            var related = CurriculumMocks.EmptyCurriculum();

            Assert.Throws<ArgumentException>(() =>
            {
                model.GetCriticalStudyPath(new Models.ProgressCarreer
                {
                    RelatedCode = "",
                    ApprovedSubjects = null
                });
            });
        }

        [Test]
        public void EstudianteSinMateriasAprobadas()
        {
            var related = CurriculumMocks.CurriculumWithOneCorrelativitie();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                RelatedCode = "",
                ApprovedSubjects = new List<Subject>()
            });

            Assert.True(criticalPath.Count == related.Related.Count);
        }

        [Test]
        public void EstudianteConTodasLasMateriasAprobadas()
        {
            var related = CurriculumMocks.CurriculumWithOneCorrelativitie();
            var allSubjects = related.Related.Select(t => t.Subject);

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                RelatedCode = "",
                ApprovedSubjects = allSubjects
            });

            Assert.True(criticalPath.Count == 0);
        }

        [Test]
        public void EstudianteConAlMenosUnaMateriaAprobada()
        {
            var related = CurriculumMocks.CurriculumWithOneCorrelativitie();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                RelatedCode = "",
                ApprovedSubjects = new List<Subject> { RelatedMocks.A.Subject }
            });

            Assert.True(criticalPath.Count == 1);
        }
    }
}
