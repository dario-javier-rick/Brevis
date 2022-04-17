
namespace EstudiarEsElCamino.Core.Test.Model
{
    using EstudiarEsElCamino.Core.Model;
    using EstudiarEsElCamino.Core.Test.Mocks;
    using NUnit.Framework; 
    public class StudyPlanModelTest
    {
        private StudyPlan studyPlan1;
        private StudyPlan studyPlan2;

        [SetUp]
        public void Setup()
        {
            this.studyPlan1 = StudyPlanMocks.EmptyStudyPlan;
            this.studyPlan2 = StudyPlanMocks.EmptyStudyPlan;
        }

        [Test]
        public void TwoEmptyStudyPlans_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Act
            var result = studyPlan1.DifferenceWith(studyPlan2);

            //Assert 
            Assert.IsTrue(result.Correlativities.Count == 0);
        }

        [Test]
        public void OneEmptyStudyPlanAnotherWithOneSubject_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Arrange
            studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie;

            //Act
            var result = studyPlan1.DifferenceWith(studyPlan2);

            //Assert 
            Assert.IsTrue(result.Correlativities.Count == 0);
        }

        [Test]
        public void TwoStudyPlansWithTheSameCorrelativities_DifferenceWith_ReturnEmptyStudyPlan()
        {
            //Arrange
            studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie;
            studyPlan2 = StudyPlanMocks.StudyPlanWithOneCorrelativitie;

            //Act
            var result = studyPlan1.DifferenceWith(studyPlan2);

            //Assert 
            Assert.IsTrue(result.Correlativities.Count == 0);
        }

        [Test]
        public void OneStudyPlanWithOneCorrelativitieAnotherWithTwo_DifferenceWith_ReturnStudyPlanWithOneCorrelativitie()
        {
            //Arrange
            studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie;
            studyPlan2 = StudyPlanMocks.StudyPlanWithTwoCorrelativities;

            //Act
            var result = studyPlan1.DifferenceWith(studyPlan2);

            //Assert 
            Assert.IsTrue(result.Correlativities.Count == 1);
        }

        [Test]
        public void OneStudyPlanWithOneCorrelativitieAnotherWithThree_DifferenceWith_ReturnStudyPlanWithTwoCorrelativities()
        {
            //Arrange
            studyPlan1 = StudyPlanMocks.StudyPlanWithOneCorrelativitie;
            studyPlan2 = StudyPlanMocks.StudyPlanWithThreeCorrelativities;

            //Act
            var result = studyPlan1.DifferenceWith(studyPlan2);

            //Assert 
            Assert.IsTrue(result.Correlativities.Count == 2);
        }

    }
}
