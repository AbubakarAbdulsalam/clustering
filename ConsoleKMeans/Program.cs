using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            DistanceMetric firstMetric = new AbsoluteDistance();
            Feature testFeature9 = new DoubleFeature(firstMetric, 13.0);
            Feature testFeature8 = new DoubleFeature(firstMetric, 12.0);
            Feature testFeature = new DoubleFeature(new AbsoluteDistance(), 7.0);
            Feature testFeature1 = new DoubleFeature(new AbsoluteDistance(), 11.0);
            Feature testFeature2 = new DoubleFeature(new AbsoluteDistance(), 27.0);
            Feature testFeature3 = new DoubleFeature(new AbsoluteDistance(), 6.0);
            Feature testFeature4 = new DoubleFeature(new AbsoluteDistance(), 19.0);
            Feature testFeature5 = new DoubleFeature(new AbsoluteDistance(), 17.0);
            Feature testFeature6 = new DoubleFeature(new AbsoluteDistance(), 10.0);
            Feature testFeature7 = new DoubleFeature(new AbsoluteDistance(), 11.0);
            Feature testFeature10 = new DoubleFeature(new AbsoluteDistance(), 14.0);
            Feature testFeature11 = new DoubleFeature(new AbsoluteDistance(), 15.0);
            Feature testFeature12 = new DoubleFeature(new AbsoluteDistance(), 16.0);
            Feature testFeature13= new DoubleFeature(new AbsoluteDistance(), 17.0);
            Feature testFeature14 = new DoubleFeature(new AbsoluteDistance(), 18.0);
            Feature testFeature15= new DoubleFeature(new AbsoluteDistance(), 19.0);
            Feature testFeature16= new DoubleFeature(new AbsoluteDistance(), 20.0);
            Feature testFeature17 = new DoubleFeature(new AbsoluteDistance(), 21.0);
            Feature testFeature18 = new DoubleFeature(new AbsoluteDistance(), 22.0);
            Feature testFeature19 = new DoubleFeature(new AbsoluteDistance(), 23.0);
            Feature testFeature20 = new DoubleFeature(new AbsoluteDistance(), 24.0);
            Feature testFeature21 = new DoubleFeature(new AbsoluteDistance(), 25.0);
            Feature testFeature22 = new DoubleFeature(new AbsoluteDistance(), 26.0);
            Feature testFeature23 = new DoubleFeature(new AbsoluteDistance(), 27.0);
            Feature testFeature24 = new DoubleFeature(new AbsoluteDistance(), 28.0);
            Feature testFeature25 = new DoubleFeature(new AbsoluteDistance(), 29.0);

            //First
            ComplexFeature testComplex1 = new ComplexFeature(new EuclideanDistance());
            testComplex1.AddChildFeature(testFeature1);
            testComplex1.AddChildFeature(testFeature2);

            Observation testObservation1 = new Observation(2);
            testObservation1.AddFeature(testFeature);
            testObservation1.AddFeature(testComplex1);

            //second
            ComplexFeature testComplex2 = new ComplexFeature(new EuclideanDistance());
            testComplex2.AddChildFeature(testFeature3);
            testComplex2.AddChildFeature(testFeature4);

            Observation testObservation2 = new Observation(2);
            testObservation2.AddFeature(testFeature5);
            testObservation2.AddFeature(testComplex2);

            //third
            ComplexFeature testComplex3 = new ComplexFeature(new EuclideanDistance());
            testComplex3.AddChildFeature(testFeature6);
            testComplex3.AddChildFeature(testFeature7);

            Observation testObservation3 = new Observation(2);
            testObservation3.AddFeature(testFeature8);
            testObservation3.AddFeature(testComplex3);

            //fourth
            ComplexFeature testComplex4 = new ComplexFeature(new EuclideanDistance());
            testComplex4.AddChildFeature(testFeature9);
            testComplex4.AddChildFeature(testFeature10);

            Observation testObservation4 = new Observation(2);
            testObservation4.AddFeature(testFeature11);
            testObservation4.AddFeature(testComplex4);

            //fifth
            ComplexFeature testComplex5 = new ComplexFeature(new EuclideanDistance());
            testComplex5.AddChildFeature(testFeature12);
            testComplex5.AddChildFeature(testFeature13);

            Observation testObservation5 = new Observation(2);
            testObservation5.AddFeature(testFeature14);
            testObservation5.AddFeature(testComplex5);


            //sixth
            ComplexFeature testComplex6 = new ComplexFeature(new EuclideanDistance());
            testComplex6.AddChildFeature(testFeature15);
            testComplex6.AddChildFeature(testFeature16);

            Observation testObservation6 = new Observation(2);
            testObservation6.AddFeature(testFeature17);
            testObservation6.AddFeature(testComplex6);

            //seventh
            ComplexFeature testComplex7 = new ComplexFeature(new EuclideanDistance());
            testComplex7.AddChildFeature(testFeature18);
            testComplex7.AddChildFeature(testFeature19);

            Observation testObservation7 = new Observation(2);
            testObservation7.AddFeature(testFeature20);
            testObservation7.AddFeature(testComplex7);

            //eigth
            ComplexFeature testComplex8 = new ComplexFeature(new EuclideanDistance());
            testComplex8.AddChildFeature(testFeature21);
            testComplex8.AddChildFeature(testFeature22);

            Observation testObservation8 = new Observation(2);
            testObservation8.AddFeature(testFeature23);
            testObservation8.AddFeature(testComplex8);


            //two clusters 
            List<Observation> centroids = new List<Observation>
            {
                testObservation1,
                testObservation2
            };

            List<Observation> obs = new List<Observation>
            {
                testObservation3,
                testObservation4,
                testObservation5,
                testObservation6,
                testObservation7,
                testObservation8
            };

            Console.Write("Observations initialized");
            Console.Read();
            KMeans means = new KMeans(3, 0.1, 2);
            means.InitializeCentroids(centroids);
            means.AssignCluster(obs);
            means.ReCalculateCentroids();
            
        }
    }
}
