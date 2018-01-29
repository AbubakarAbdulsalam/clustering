using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace practiceMl
{
    public class ImageDetails
    {
        private Bitmap image;


        public ImageDetails(String path)
        {
      
            
            
        }

        public void GenerateObservation()
        {
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color pixel = image.GetPixel(i, j);
                    Feature pixelAttribute = new ComplexFeature(new AbsoluteDistance());

                    

                }
            }
        }

        
    }
}
