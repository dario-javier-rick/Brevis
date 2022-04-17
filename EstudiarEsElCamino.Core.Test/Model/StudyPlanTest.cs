
namespace EstudiarEsElCamino.Core.Test.Model
{
    using EstudiarEsElCamino.Core.Model;
    using EstudiarEsElCamino.Core.Test.Mocks;
    using NUnit.Framework;
    using System;
    public class StudyPlanTest
    {
        StudyPlan model;

        [SetUp]
        public void Setup()
        {
            model = StudyPlanMocks.EmptyStudyPlan;
        }

        [Test]
        public void EmptyJsonTest()
        {
        }
    }
}
