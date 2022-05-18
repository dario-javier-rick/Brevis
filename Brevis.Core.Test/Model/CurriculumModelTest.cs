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
            var studyPlan = CurriculumMocks.EmptyCurriculum();

            Assert.Throws<ArgumentException>(() =>
            {
                model.GetCriticalStudyPath(new Models.ProgressCarreer
                {
                    StudyPlanCode = "",
                    ApprovedSubjects = null
                });
            });
        }

        [Test]
        public void EstudianteSinMateriasAprobadas()
        {
            var studyPlan = CurriculumMocks.CurriculumWithOneCorrelativitie();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                StudyPlanCode = "",
                ApprovedSubjects = new List<Subject>()
            });

            Assert.True(criticalPath.Count == studyPlan.Related.Count);
        }

        [Test]
        public void EstudianteConTodasLasMateriasAprobadas()
        {
            var studyPlan = CurriculumMocks.CurriculumWithOneCorrelativitie();
            var allSubjects = studyPlan.Related.Select(t => t.Subject);

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                StudyPlanCode = "",
                ApprovedSubjects = allSubjects
            });

            Assert.True(criticalPath.Count == 0);
        }

        [Test]
        public void EstudianteConAlMenosUnaMateriaAprobada()
        {
            var studyPlan = CurriculumMocks.CurriculumWithTwoCorrelativities();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                StudyPlanCode = "",
                ApprovedSubjects = new List<Subject> { CorrelativitiesMocks.IntroduccionALaProgramacion.Subject }
            });

            Assert.True(criticalPath.Count == 1);
        }
    }
}
