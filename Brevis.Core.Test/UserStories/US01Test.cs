using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;
using System.Collections.Generic;

namespace Brevis.Core.Test.UserStories
{
    [TestFixture]
    public class US01Test
    {
        private StudyPath model;

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
            CollectionAssert.AreEqual(expectedList, criticalPath);
        }
        [Test]
        public void CA2()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.CurriculumCode = "Plan0";
            progressCarreer.ApprovedSubjects = new List<Subject>();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.A);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.C);

            //Act
            var criticalPath = this.model.GetCriticalStudyPath(progressCarreer);

            //Assert 
            var expectedList = new List<Subject>() { };
            CollectionAssert.AreEqual(expectedList, criticalPath);
        }
        [Test]
        public void CA3()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.CurriculumCode = "Plan0";
            progressCarreer.ApprovedSubjects = new List<Subject>();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.A);

            //Act
            var criticalPath = this.model.GetCriticalStudyPath(progressCarreer);

            //Assert 
            var expectedList = new List<Subject>() { SubjectMocks.B, SubjectMocks.C };
            CollectionAssert.AreEqual(expectedList, criticalPath);
        }
        [Test]
        public void CA4()
        {
            //Arrange
            ProgressCarreer progressCarreer = new ProgressCarreer();
            progressCarreer.CurriculumCode = "Plan0";
            progressCarreer.ApprovedSubjects = new List<Subject>();
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.A);
            progressCarreer.ApprovedSubjects.Add(SubjectMocks.B);

            //Act
            var criticalPath = this.model.GetCriticalStudyPath(progressCarreer);

            //Assert 
            var expectedList = new List<Subject>() { SubjectMocks.C };
            CollectionAssert.AreEqual(expectedList, criticalPath);
        }
    }
}
