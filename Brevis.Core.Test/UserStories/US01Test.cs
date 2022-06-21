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
            Subject subject = new Subject();
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.CurriculumCode = "1";
            //          pg.ApprovedSubjects.Add(subject);
            var criticalPath = this.model.GetCriticalStudyPath(progressCarreer);
            //Act

            var criticalStudyPath = this.model.GetCriticalStudyPath(new ProgressCarreer());
            criticalStudyPath.Add(SubjectMocks.B);
            criticalStudyPath.Add(SubjectMocks.C);
            //Assert
            Assert.AreEqual(criticalPath, criticalStudyPath);
        }
        [Test]
        public void CA2()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.A);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.C);
            progressCarreer.CurriculumCode = "1";

            //Act
            
            var criticalPath = this.model.GetCriticalStudyPath(new ProgressCarreer());

            //Assert 
            Assert.IsTrue( criticalPath.Count == 0);
        }
        [Test]
        public void CA3()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);
            //Act
            var criticalPath = this.model.GetCriticalStudyPath(new ProgressCarreer());

            //Assert 
            var criticalStudyPath = this.model.GetCriticalStudyPath(new ProgressCarreer());
            criticalStudyPath.Add(SubjectMocks.A);
            criticalStudyPath.Add(SubjectMocks.B);
            Assert.AreEqual(criticalPath, criticalStudyPath);
        }
        [Test]
        public void CA4()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);
            //Act
            var criticalPath = this.model.GetCriticalStudyPath(new ProgressCarreer());

            //Assert
            
//            var criticalStudyPath = this.model.GetCriticalStudyPath(new ProgressCarreer());
//            criticalStudyPath.Add(SubjectMocks.A);

            Assert.AreEqual(criticalPath, SubjectMocks.A);
        }

    }
}
