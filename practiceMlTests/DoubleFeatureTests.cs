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
    public class DoubleFeatureTests
    {
        [TestMethod()]
        public void CalculateDistanceTest()
        {
            //arrange
            DistanceMetric firstMetric = new AbsoluteDistance();
            Feature initial = new DoubleFeature(firstMetric, 20.0);
            Feature initial2 = new DoubleFeature(firstMetric, 22.0);

            //act, assert
            Assert.AreEqual(initial.CalculateDistance(initial2), 2);
        }

        [TestMethod()]
        public void SumTest()
        {
            //arrange 
            DistanceMetric firstMetric = new AbsoluteDistance();
            Feature initial = new DoubleFeature(firstMetric, 20.0);
            Feature initial2 = new DoubleFeature(firstMetric, 22.0);

            //act
            Feature result = initial2.Sum(initial);

            //assert
            Assert.AreEqual(result.FeatureValue, 42.0);
            
            Assert.AreSame(result.MetricUsed, firstMetric);

        }

        [TestMethod()]
        public void AverageTest()
        {
            //arrange 
            DistanceMetric firstMetric = new AbsoluteDistance();
            Feature initial = new DoubleFeature(firstMetric, 20.0);
            Feature initial2 = new DoubleFeature(firstMetric, 22.0);

            //act
            Feature result = initial2.Sum(initial);
            result = result.Average(2);

            //assert
            Assert.AreEqual(result.FeatureValue, 21.0);
            Assert.AreSame(result.MetricUsed, firstMetric);
        }
    }
}