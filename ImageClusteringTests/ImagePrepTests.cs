using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageClustering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConsoleKMeans;

namespace ImageClustering.Tests
{
    [TestClass()]
    public class ImagePrepTests
    {
        [TestMethod()]
        public void MakeObservationTest()
        {
            ImageDetails s = new ImageDetails((626 * 469), @"C:\Users\ezabuab\Pictures\test2.jpg");
            ImagePrep.MakeObservation(s);
            //not a real test just checking that this works 
            //example shows this is not scalable unless parallel execution is enabled 
            
        }
    }
}