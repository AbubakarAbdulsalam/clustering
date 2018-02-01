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
            Observation test = ImagePrep.MakeObservation(s, (626 *469));
        }
    }
}