﻿using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brevis.Core.Tests.Model
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
        public void NullArgumentTest()
        {
            var related = CurriculumMocks.EmptyCurriculum();

            Assert.Throws<ArgumentException>(() =>
            {
                model.GetCriticalStudyPath(null);
            });
        }

        [Test]
        public void EstudianteSinMateriasAprobadas()
        {
            var related = CurriculumMocks.CurriculumWithOneRelated();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                ApprovedSubjects = new List<Subject>()
            });

            Assert.True(criticalPath.Count == related.Subjects.Count);
        }

        [Test]
        public void EstudianteConTodasLasMateriasAprobadas()
        {
            var related = CurriculumMocks.CurriculumWithOneRelated();
            var allSubjects = related.Subjects.Select(t => t.Subject);

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                ApprovedSubjects = allSubjects.ToList()
            });

            Assert.True(criticalPath.Count == 0);
        }

        [Test]
        public void EstudianteConAlMenosUnaMateriaAprobada()
        {
            var related = CurriculumMocks.CurriculumWithOneRelated();

            var criticalPath = model.GetCriticalStudyPath(new Models.ProgressCarreer
            {
                ApprovedSubjects = new List<Subject> { RelatedMocks.A.Subject }
            });

            Assert.True(criticalPath.Count == 1);
        }
    }
}
