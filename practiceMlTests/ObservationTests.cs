using Microsoft.VisualStudio.TestTools.UnitTesting;
using practiceMl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl.Tests
{
    [TestClass()]
    public class ObservationTests
    {
        [TestMethod()]
        public void AddFeatureTest()
        {
            Feature testingFeature = new DoubleFeature(new AbsoluteDistance(), 2.0);

            Observation testingObs = new Observation(1);

            testingObs.AddFeature(testingFeature);

            Assert.AreEqual(testingObs.FeaturesCount, 1);
        }

        [TestMethod()]
        public void AddFeatureOverflowTest()
        {
            Feature testFeature = new DoubleFeature(new AbsoluteDistance(),4.0);
            Feature testFeature2 = new DoubleFeature(new AbsoluteDistance(), 3.0);
            Observation testObservation = new Observation(1);

            testObservation.AddFeature(testFeature);

            try
            {
                testObservation.AddFeature(testFeature2);
            }
            catch (MaxFeatureNumberExceeded e)
            {
                Console.Write(e.Message);
            }
            
        }

        [TestMethod()]
        public void GetFeatureTest()
        {
            Feature testingFeature = new DoubleFeature(new AbsoluteDistance(), 2.0);

            Observation testingObs = new Observation(1);

            testingObs.AddFeature(testingFeature);

            Feature returned = testingObs.GetFeature(0);

            Assert.AreSame(returned, testingFeature);
        }

        [TestMethod()]
        public void ReplaceFeatureTest()
        {
            Feature testingFeature = new DoubleFeature(new AbsoluteDistance(), 2.0);
            Feature replacement = new DoubleFeature(new AbsoluteDistance(), 6.0);
            Observation testingObs = new Observation(1);

            testingObs.AddFeature(testingFeature);
            testingObs.ReplaceFeature(0, replacement);

            Assert.AreSame(replacement, testingObs.GetFeature(0));
            Assert.AreEqual(6.0,testingObs.GetFeature(0).FeatureValue);
        }
    }
}