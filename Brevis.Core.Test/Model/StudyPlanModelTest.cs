
namespace Brevis.Core.Test.Model
{
    using Brevis.Core.Models;
    using Brevis.Core.Test.Mocks;
    using NUnit.Framework;
    [TestFixture]
    public class StudyPlanModelTest
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
            this.curriculum1 = CurriculumMocks.CurriculumWithOneCorrelativitie();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void TwoStudyPlansWithTheSameCorrelativities_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneCorrelativitie();
            this.curriculum2 = CurriculumMocks.CurriculumWithOneCorrelativitie();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void OneStudyPlanWithOneCorrelativitieAnotherWithTwo_DifferenceWith_ReturnStudyPlanWithOneCorrelativitie()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneCorrelativitie();
            this.curriculum2 = CurriculumMocks.CurriculumWithTwoCorrelativities();

            //Act
            curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 1);
        }

        [Test]
        public void OneStudyPlanWithOneCorrelativitieAnotherWithThree_DifferenceWith_ReturnStudyPlanWithTwoCorrelativities()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneCorrelativitie();
            this.curriculum2 = CurriculumMocks.CurriculumWithThreeCorrelativities();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 2);
        }

    }
}
