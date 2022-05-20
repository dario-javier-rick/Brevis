using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;


namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US01Test
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
            this.curriculum1 = CurriculumMocks.CurriculumWithOneRelated();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }

        [Test]
        public void TwocurriculumsWithTheSameRelated_DifferenceWith_ReturnEmptycurriculum()
        {
            //Arrange
            this.curriculum1 = CurriculumMocks.CurriculumWithOneRelated();
            this.curriculum2 = CurriculumMocks.CurriculumWithOneRelated();

            //Act
            this.curriculum1.RemoveFrom(this.curriculum2);

            //Assert 
            Assert.IsTrue(this.curriculum1.Related.Count == 0);
        }
    }
}
