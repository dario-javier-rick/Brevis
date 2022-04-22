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
    public class StudyPathModelTest
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
            var studyPlan = StudyPlanMocks.EmptyStudyPlan();

            Assert.Throws<ArgumentException>(() =>
            {
                model.GetCriticalStudyPath(new Models.ProgressCarreer
                {
                    StudyPlan = studyPlan,
                    ApprovedSubjects = null
                });
            });
        }

        [Test]
        public void EstudianteSinMateriasAprobadas()
        {
            var studyPlan = StudyPlanMocks.StudyPlanWithOneCorrelativitie();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                StudyPlan = studyPlan,
                ApprovedSubjects = new List<Subject>()
            });

            Assert.True(criticalPath.Count == studyPlan.Correlativities.Count);
        }

        [Test]
        public void EstudianteConTodasLasMateriasAprobadas()
        {
            var studyPlan = StudyPlanMocks.StudyPlanWithOneCorrelativitie();
            var allSubjects = studyPlan.Correlativities.Select(t => t.Subject);

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                StudyPlan = studyPlan,
                ApprovedSubjects = allSubjects
            });

            Assert.True(criticalPath.Count == 0);
        }

        [Test]
        public void EstudianteConAlMenosUnaMateriaAprobada()
        {
            var studyPlan = StudyPlanMocks.StudyPlanWithTwoCorrelativities();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                StudyPlan = studyPlan,
                ApprovedSubjects = new List<Subject> { CorrelativitiesMocks.IntroduccionALaProgramacion.Subject }
            });

            Assert.True(criticalPath.Count == 1);
        }
    }
}
