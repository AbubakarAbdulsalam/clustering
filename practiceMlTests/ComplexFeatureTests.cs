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
    public class ComplexFeatureTests
    {
        
        static DistanceMetric first = new AbsoluteDistance();
        Feature one = new DoubleFeature(first,12.0);
        Feature tow = new DoubleFeature(first,14.0);
        Feature three = new DoubleFeature(first,15.0);
        Feature four = new DoubleFeature(first,5.0);
        Feature five = new DoubleFeature(first,11.0);
        Feature six = new DoubleFeature(first,15.0);
        Feature seven = new DoubleFeature(first,9.0);
        Feature eight = new DoubleFeature(first,6.0);
        Feature nine = new DoubleFeature(first, 8.0);
        Feature ten = new DoubleFeature(first, 9.0);

        [TestMethod()]
        public void ComplexFeatureTest()
        {

        }


        [TestMethod()]
        public void CalculateDistanceTest()
        {
            ComplexFeature test = new ComplexFeature(first);
            test.AddChildFeature(one);
            test.AddChildFeature(tow);
            test.AddChildFeature(three);
            ComplexFeature otherTest = new ComplexFeature(first);

            otherTest.AddChildFeature(four);
            otherTest.AddChildFeature(five);
            otherTest.AddChildFeature(six);

            //ACT
            int distance = otherTest.CalculateDistance(test);

            //assert
            Assert.AreEqual(distance, 7);
        }

        [TestMethod()]
        public void GetChildFeatureTest()
        {

        }

        [TestMethod()]
        public void AddChildFeatureTest()
        {

        }

        [TestMethod()]
        public void SumTest()
        {
            ComplexFeature testintest1 = new ComplexFeature(first);
            testintest1.AddChildFeature(one);
            testintest1.AddChildFeature(tow);

            ComplexFeature test1 = new ComplexFeature(first);
            test1.AddChildFeature(testintest1);
            test1.AddChildFeature(three);

            ComplexFeature testintest2 = new ComplexFeature(first);
            testintest2.AddChildFeature(four);
            testintest2.AddChildFeature(five);

            ComplexFeature test2 = new ComplexFeature(first);
            test2.AddChildFeature(testintest2);
            test2.AddChildFeature(six);

            //act
            ComplexFeature result = (ComplexFeature)test2.Sum(test1);

            //assert
            Assert.AreEqual(result.GetChildFeature(1).FeatureValue,30);
            Assert.AreEqual(result.GetChildFeature(0).GetChildFeature(0).FeatureValue, 17);
        }

        [TestMethod()]
        public void AverageTest()
        {

        }
    }
}