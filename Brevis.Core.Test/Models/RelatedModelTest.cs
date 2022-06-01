using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;

namespace Brevis.Core.Tests.Model
{
    [TestFixture]
    public class RelatedModelTest
    {
        private Curriculum curriculum1;
        private Curriculum curriculum2;

        [SetUp]
        public void Setup()
        {
            this.curriculum1 = CurriculumMocks.EmptyCurriculum();
            this.curriculum2 = CurriculumMocks.EmptyCurriculum();
        }
        [TearDown]
        public void TearDown()
        {
            this.curriculum1 = null;
            this.curriculum2 = null;
        }

        [Test]
        public void TwoEmptyStudyPlans_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Act
            this.curriculum1.RemoveFrom(curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void OneEmptyStudyPlanAnotherWithOneSubject_RemoveFrom_ReturnEmptyStudyPlan()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneRelated();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void TwoStudyPlansWithTheSameRealted_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneRelated();
            this.curriculum2 = CurriculumMocks.CurriculumWithOneRelated();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void OneStudyPlanWithOneRelatedAnotherWithTwo_DifferenceWith_ReturnStudyPlanWithOneRelated()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneRelated();

            //Act
            curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 1);
        }

        [Test]
        public void OneStudyPlanWithOneRelatedAnotherWithThree_DifferenceWith_ReturnStudyPlanWithTwoRelated()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneRelated();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 2);
        }

    }
}
