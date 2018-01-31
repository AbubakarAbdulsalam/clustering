using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    public class MaxFeatureNumberExceeded : System.Exception
    {
        public MaxFeatureNumberExceeded ()
            :base () { }

        public MaxFeatureNumberExceeded(String message)
            :base(message) { }
    }
}
