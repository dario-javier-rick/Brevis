
namespace Brevis.Core.Test.Model
{
    using Brevis.Core.Models;
    using Brevis.Core.Test.Mocks;
    using NUnit.Framework;
    [TestFixture]
    public class CA1Test
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
        public void TwoEmptycurriculums_DifferenceWith_ReturnEmptycurriculum()
        {
            //Act
            this.curriculum1.RemoveFrom(curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void OneEmptycurriculumAnotherWithOneSubject_RemoveFrom_ReturnEmptycurriculum()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneCorrelativitie();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void TwocurriculumsWithTheSameCorrelativities_DifferenceWith_ReturnEmptycurriculum()
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
        public void OnecurriculumWithOneCorrelativitieAnotherWithTwo_DifferenceWith_ReturncurriculumWithOneCorrelativitie()
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
        public void OnecurriculumWithOneCorrelativitieAnotherWithThree_DifferenceWith_ReturncurriculumWithTwoCorrelativities()
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
