namespace EstudiarEsElCamino.Core.Test.Model
{
    using EstudiarEsElCamino.Core.Model;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

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
    }
}
