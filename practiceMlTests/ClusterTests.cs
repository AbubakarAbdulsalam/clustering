using ConsoleKMeans;
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
    public class ClusterTests
    {
        [TestMethod()]
        public void AddMemberTest()
        {
            Cluster testCluster = new Cluster();

            Feature testFeature = new DoubleFeature(new AbsoluteDistance(), 4.0);
            Observation testObservation = new Observation(3);
            testObservation.AddFeature(testFeature);

            //act
            testCluster.AddMember(testObservation);

            //assert
            Assert.AreEqual(testCluster.ClusterCount, 1);
        }

        [TestMethod()]
        public void ReCalculateCentroidTest()
        {
            Cluster testCluster = new Cluster();

            Feature testFeature = new DoubleFeature(new AbsoluteDistance(), 4.0);
            Feature testFeature1 = new DoubleFeature(new AbsoluteDistance(), 5.0);
            Feature testFeature2 = new DoubleFeature(new AbsoluteDistance(), 15.0);
            Feature testFeature3 = new DoubleFeature(new AbsoluteDistance(), 25.0);
            Feature testFeature4 = new DoubleFeature(new AbsoluteDistance(), 7.0);
            Feature testFeature5 = new DoubleFeature(new AbsoluteDistance(), 8.0);
            Feature testFeature6 = new DoubleFeature(new AbsoluteDistance(), 8.0);
            Feature testFeature7 = new DoubleFeature(new AbsoluteDistance(), 10.0);

            Observation testObservation = new Observation(2);
            Observation testObservation1 = new Observation(2);
            Observation testObservation2 = new Observation(2);

            Observation initialCentroid = new Observation(2);

            initialCentroid.AddFeature(testFeature);
            initialCentroid.AddFeature(testFeature1);
            testCluster.ClusterCentroid = initialCentroid;

            testObservation.AddFeature(testFeature2);
            testObservation.AddFeature(testFeature3);
            testCluster.AddMember(testObservation);

            testObservation1.AddFeature(testFeature4);
            testObservation1.AddFeature(testFeature5);
            testCluster.AddMember(testObservation1);

            testObservation2.AddFeature(testFeature6);
            testObservation2.AddFeature(testFeature7);
            testCluster.AddMember(testObservation2);



            //act
            testCluster.ReCalculateCentroid();

            //assert
            Assert.AreEqual(10.0, testCluster.ClusterCentroid.GetFeature(0).FeatureValue);
            Assert.AreSame(initialCentroid, testCluster.OldClusterCentroid);
            
        }
    }
}