using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleKMeans;

namespace ImageClustering
{
    static class ImagePrep
    {

        static   IList<String> paths = new List<string>();

        static  IList<String> initialCentroidSPaths = new List<String>();
        
       

        static IList<Observation> MakeObservations(int maxWidth, int maxHeight)
        {
            IList<Observation> imageObservations = new List<Observation>();
            for(int i=0; i < paths.Count; i++)
            {
                ImageDetails image = new ImageDetails((maxHeight * maxWidth), paths.ElementAt(i));
                if (image.ImageHeight > maxHeight || image.ImageWidth > maxWidth)
                {
                    image.Resize(maxWidth, maxHeight);
                }
                imageObservations.Add(MakeObservation(image, (image.ImageHeight * image.ImageWidth)));
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

        static Observation MakeObservation(ImageDetails image, int size)
        {
            Observation imageObservation = new Observation((image.ImageHeight * image.ImageWidth));
            for (int i = 0; i < image.ImageHeight; i++)
            {
                for(int j =0; i < image.ImageWidth; i++)
                {
                    ComplexFeature pixel = new ComplexFeature(new EuclideanDistance());
                    pixel.AddChildFeature(new DoubleFeature(new AbsoluteDistance(), image.GetRComponent(j, i)));
                    pixel.AddChildFeature(new DoubleFeature(new AbsoluteDistance(), image.GetGComponent(j, i)));
                    pixel.AddChildFeature(new DoubleFeature(new AbsoluteDistance(), image.GetBComponent(j, i)));
                    imageObservation.AddFeature(pixel);
                }
            }
            return imageObservation;
        }
    }


}
