using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.CurriculumCode = "Plan0";
            progressCarreer.ApprovedSubjects = new List<Subject>();

            //Act
            var criticalPath = this.model.GetCriticalStudyPath(progressCarreer);

            //Assert
            var expectedList = new List<Subject>() { SubjectMocks.A, SubjectMocks.B };
//            Assert.AreEqual(expectedList.Count, criticalPath.Count);

            foreach (var subject in criticalPath)
            {
                Assert.IsTrue(expectedList.Contains(subject));
            }


        }
        [Test]
        public void CA2()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.ApprovedSubjects = new List<Subject>();
            progressCarreer.CurriculumCode = "Plan0";
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.A);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.C);
            //Act
            var criticalPath = this.model.GetCriticalStudyPath(progressCarreer);
            //Assert 
            Assert.AreEqual(0, criticalPath.Count);
        }
        [Test]
        public void CA3()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.ApprovedSubjects = new List<Subject>();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);
            progressCarreer.CurriculumCode = "Plan0";
            //Act
            var criticalPath = this.model.GetCriticalStudyPath(new ProgressCarreer());

            //Assert 
            var expectedList = new List<Subject>() { SubjectMocks.A, SubjectMocks.B };
            foreach (var subject in criticalPath)
            {
                Assert.IsTrue(expectedList.Contains(subject));
            }  

        }
        [Test]
        public void CA4()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.ApprovedSubjects = new List<Subject>();
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
