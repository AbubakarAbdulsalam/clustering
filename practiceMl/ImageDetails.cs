using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace practiceMl
{
    public class ImageDetails : Observation
    {

        private Bitmap image;

        public Image Image
        { get { return image; }
            set { image = new Bitmap(value); }
        }

        public int ImageWidth
        { get { return image.Width; } }

        public int ImageHeight
        { get { return image.Height; } }
       

        public ImageDetails(int max, string path) : base(max)
        {
            try
            {
                image = new Bitmap(path);
            }
            catch (FileNotFoundException e)
            {
                throw new ImageCreationException("filenotfound for image", e);
            }
            catch (Exception e)
            {
                throw new ImageCreationException("something went wrong", e);
            }
        }

        public ImageDetails(int max, Image image) : base(max)
        {
            try
            {
                image = new Bitmap(image);
            }
            catch(Exception e)
            {
                throw new ImageCreationException("something went wrong", e);
            }
        }

        public double GetRComponent(int x, int y)
        {
            return image.GetPixel(x, y).R;
        }

        public double GetGComponent(int x, int y)
        {
            return image.GetPixel(x, y).G;
        }

        public double GetBComponent(int x, int y)
        {
            return image.GetPixel(x, y).B;
        }

        public void Resize(int width, int height )
        {
            this.image = new Bitmap(this.image,width,height);
        }

    }
}
