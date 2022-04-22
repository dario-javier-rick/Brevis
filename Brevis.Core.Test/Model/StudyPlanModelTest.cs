
namespace Brevis.Core.Test.Model
{
    using Brevis.Core.Model;
    using Brevis.Core.Test.Mocks;
    using NUnit.Framework;
    [TestFixture]
    public class StudyPlanModelTest
    {
        private StudyPlan studyPlan1;
        private StudyPlan studyPlan2;

        [SetUp]
        public void Setup()
        {
            this.studyPlan1 = StudyPlanMocks.EmptyStudyPlan();
            this.studyPlan2 = StudyPlanMocks.EmptyStudyPlan();
        }
        [TearDown]
        public void TearDown()
        {
            this.studyPlan1 = null;
            this.studyPlan2 = null;
        }

        [Test]
        public void TwoEmptyStudyPlans_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Act
            this.studyPlan1.RemoveFrom(studyPlan2);

            //Assert 
            Assert.IsTrue(this.studyPlan1.Correlativities.Count == 0);
        }

        [Test]
        public void OneEmptyStudyPlanAnotherWithOneSubject_RemoveFrom_ReturnEmptyStudyPlan()
        {
            //Arrange
            this.studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie();

            //Act
            this.studyPlan1.RemoveFrom(this.studyPlan2);

            //Assert 
            Assert.IsTrue(this.studyPlan1.Correlativities.Count == 0);
        }

        [Test]
        public void TwoStudyPlansWithTheSameCorrelativities_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Arrange
            this.studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie();
            this.studyPlan2 = StudyPlanMocks.StudyPlanWithOneCorrelativitie();

            //Act
            this.studyPlan1.RemoveFrom(this.studyPlan2);

            //Assert 
            Assert.IsTrue(this.studyPlan1.Correlativities.Count == 0);
        }

        [Test]
        public void OneStudyPlanWithOneCorrelativitieAnotherWithTwo_DifferenceWith_ReturnStudyPlanWithOneCorrelativitie()
        {
            //Arrange
            this.studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie();
            this.studyPlan2 = StudyPlanMocks.StudyPlanWithTwoCorrelativities();

            //Act
            studyPlan1.RemoveFrom(this.studyPlan2);

            //Assert 
            Assert.IsTrue(this.studyPlan1.Correlativities.Count == 1);
        }

        [Test]
        public void OneStudyPlanWithOneCorrelativitieAnotherWithThree_DifferenceWith_ReturnStudyPlanWithTwoCorrelativities()
        {
            //Arrange
            this.studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie();
            this.studyPlan2 = StudyPlanMocks.StudyPlanWithThreeCorrelativities();

            //Act
            this.studyPlan1.RemoveFrom(this.studyPlan2);

            //Assert 
            Assert.IsTrue(this.studyPlan1.Correlativities.Count == 2);
        }

    }
}
