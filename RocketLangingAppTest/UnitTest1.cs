
using RocketLandingApp.Core;
using RocketLandingApp.Domain;

namespace RocketLangingAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_OkForLanding()
        {
            LandingPlatform landingPlatform = new LandingPlatform();

            landingPlatform.InitializeLandingArea(2);

            var result = landingPlatform.EvaluateLanding(1, 1);

            Assert.AreEqual(Constants.OkForLanding, result);
        }

        [TestMethod]
        public void Test_ClashLanding()
        {
            LandingPlatform landingPlatform = new LandingPlatform();

            landingPlatform.InitializeLandingArea(2);

            _ = landingPlatform.EvaluateLanding(1, 1);

            var result = landingPlatform.EvaluateLanding(1, 1);

            Assert.AreEqual(Constants.Clash, result);
        }

        [TestMethod]
        public void Test_OutOfPlatform()
        {
            LandingPlatform landingPlatform = new LandingPlatform();

            landingPlatform.InitializeLandingArea(2);

            var result = landingPlatform.EvaluateLanding(2, 2);

            Assert.AreEqual(Constants.OutOfPlatform, result);
        }

        [TestMethod]
        public void Test_Near_ClashLanding()
        {
            LandingPlatform landingPlatform = new LandingPlatform();

            landingPlatform.InitializeLandingArea(2);

            _ = landingPlatform.EvaluateLanding(0, 0);

            var result = landingPlatform.EvaluateLanding(1, 1);

            Assert.AreEqual(Constants.Clash, result);
        }


        [TestMethod]
        public void Test3x3_OkForLanding()
        {
            LandingPlatform landingPlatform = new LandingPlatform();

            landingPlatform.InitializeLandingArea(3);

            var result = landingPlatform.EvaluateLanding(1, 1);

            var result2 = landingPlatform.EvaluateLanding(2, 1);

            Assert.AreEqual(Constants.OkForLanding, result);
            Assert.AreEqual(Constants.Clash, result2);
        }
    }
}