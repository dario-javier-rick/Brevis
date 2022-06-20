using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;

namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US01Test
    {
        StudyPath model;
        [SetUp]
        public void Setup()
        {
            model = new StudyPath();
        }
        [TearDown]
        public void TearDown()
        {
            this.model = null;

        }

        [Test]
        public void CA1() 
        {

            //Arrange
            List criticalPath = (List)this.model.GetCriticalStudyPath(new ProgressCarreer());
            //Act

            //Assert 
            Assert.IsTrue( criticalPath.Count() == 0);
        }
    }
}
