using System;
using LandingSystem;
using NUnit.Framework;

namespace LandingRocketTest
{
    public class LandingSystemTests
    {
        private const string Clash = "clash";
        private const string Okforlanding = "ok for landing";
        private const string Outofplatform = "out of platform";

        private LandingSystem.LandingSystem _landing;

        [SetUp]
        public void SetUp()
        {
            _landing = new LandingSystem.LandingSystem();
        }


        [Test]
        public void RequestTopCornerPlatform_Test()
        {

            var arrange = new Arrange(5, 5);
            var result = _landing.LandingRequest(arrange);

            Assert.AreEqual(Okforlanding, result);
        }
        [Test]
        public void RequestDownCornerPlatform_Test()
        {
            var arrange = new Arrange(7, 7);
            var result = _landing.LandingRequest(arrange);

            Assert.AreEqual(Okforlanding, result);
        }
        [Test]
        public void RequestClash_Test()
        {
            var firstArrange = new Arrange(7, 7);
            var firstResult = _landing.LandingRequest(firstArrange);

            var secondArrange = new Arrange(7, 8);
            var secondResult = _landing.LandingRequest(secondArrange);


            Assert.AreEqual(Clash, secondResult);
        }

        [Test]
        public void RequestOutOfPlatform_Test()
        {
            var arrange = new Arrange(4, 5);
            var result = _landing.LandingRequest(arrange);

            Assert.AreEqual(Outofplatform, result);
        }
        [Test]
        public void RequestOutOfRange_Test()
        {
            Assert.Throws<Exception>(() => { new LandingSystem.LandingSystem(150); });
        }

    }
}