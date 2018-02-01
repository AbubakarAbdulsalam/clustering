using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleKMeans;

namespace ImageClustering
{
    public static class ImagePrep
    {
        //###still need to fix a lot, like getting the specific number of pixels each picture should contain before starting
        //to use the following functions
        
        static   IList<String> paths = new List<string>();

        static  IList<String> initialCentroidSPaths = new List<String>();
        
       

        static IList<Observation> MakeObservations(int maxWidth, int maxHeight)
        {
            IList<Observation> imageObservations = new List<Observation>();
            for(int i=0; i < paths.Count; i++)
            {
                ImageDetails image = new ImageDetails((maxHeight * maxWidth), paths.ElementAt(i));
                if (image.ImageHeight != maxHeight || image.ImageWidth != maxWidth)
                {
                    image.Resize(maxWidth, maxHeight);
                }
                MakeObservation(image);
                imageObservations.Add(image);
            }
            return imageObservations;
        }

        static void AddInitialCentroid(string path)
        {
            initialCentroidSPaths.Add(path);
        }

        static void AddObservation(string path)
        {
            paths.Add(path);
        }

        public static void MakeObservation(ImageDetails image)
        {
           
            for (int i = 0; i < image.ImageHeight; i++)
            {
                for(int j =0; j < image.ImageWidth ; j++)
                {
                    ComplexFeature pixel = new ComplexFeature(new EuclideanDistance());
                    pixel.AddChildFeature(new DoubleFeature(new AbsoluteDistance(), image.GetRComponent(j, i)));
                    pixel.AddChildFeature(new DoubleFeature(new AbsoluteDistance(), image.GetGComponent(j, i)));
                    pixel.AddChildFeature(new DoubleFeature(new AbsoluteDistance(), image.GetBComponent(j, i)));
                    image.AddFeature(pixel);
                }
            }
            
        }
    }


}
