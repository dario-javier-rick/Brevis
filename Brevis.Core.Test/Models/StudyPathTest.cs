using Brevis.Core.Models;
using Brevis.Core.Test.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brevis.Core.Tests.Model
{
    [TestFixture]
    public class StudyPathTest
    {
        StudyPath model;

        [SetUp]
        public void Setup()
        {
            model = new StudyPath();
        }

        [Test]
        public void NullArgumentTest()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                model.GetCriticalStudyPath(null);
            });
        }
    }
}
