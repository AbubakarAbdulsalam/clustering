using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    public abstract class DistanceMetric
    {

        public abstract int GetDistance(Feature observationOneFeature, Feature observationTwoFeature);
        
    }
}
