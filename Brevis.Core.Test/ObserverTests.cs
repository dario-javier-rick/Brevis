using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brevis.Core.Test
{
    [TestFixture]
    public class ObserverTests
    {
        Observer observer;

        [SetUp]
        public void Setup()
        {
            //observer = new Observer();
        }

        [Test]
        public void NullArgumentTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                observer.Update();
            });
        }
    }
}
