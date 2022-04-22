namespace Brevis.Core.Test.Model
{
    using Brevis.Core.Model;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

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
        public void EmptyJsonTest()
        {
            Assert.Throws<ArgumentException>(() => { model.GetCriticalStudyPath("{}"); });
        }

        [Test]
        public void EstudianteSinMateriasAprobadas()
        {
            model.GetCriticalStudyPath("{dsadsadasda}");
        }

        [Test]
        public void EstudianteConTodasLasMateriasAprobadas()
        {
            Assert.Throws<ArgumentException>(() => { model.GetCriticalStudyPath("{}"); });
        }

        [Test]
        public void EstudianteConAlMenosUnaMateriaAprobada()
        {
            Assert.Throws<ArgumentException>(() => { model.GetCriticalStudyPath("{}"); });
        }
    }
}
