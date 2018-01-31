using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageClustering
{
    public class ImageCreationException : Exception
    {

        public ImageCreationException(String message, Exception inner) : base(message,inner) { }

        public ImageCreationException(String message) : this(message, null) { }

        public ImageCreationException() : this("", null) { }
    }
}
