namespace Brevis.Core.Tests.Models
{
    using Brevis.Core.Models;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using System.Collections.Generic;

    [TestFixture]
    public class CurriculumTests
    {
        private Curriculum _testClass;
        private ICollection<Related> _related;

        [SetUp]
        public void SetUp()
        {
            _related = Substitute.For<ICollection<Related>>();
            _testClass = new Curriculum(_related);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new Curriculum(_related);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullRelated()
        {
            Assert.Throws<ArgumentNullException>(() => new Curriculum(default(ICollection<Related>)));
        }

        [Test]
        public void CanCallRemoveFrom()
        {
            var anotherStudyPlan = new Curriculum(Substitute.For<ICollection<Related>>());
            _testClass.RemoveFrom(anotherStudyPlan);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallRemoveFromWithNullAnotherStudyPlan()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.RemoveFrom(default(Curriculum)));
        }

        [Test]
        public void CanSetAndGetCode()
        {
            var testValue = "TestValue1091300745";
            _testClass.Code = testValue;
            Assert.That(_testClass.Code, Is.EqualTo(testValue));
        }
    }
}