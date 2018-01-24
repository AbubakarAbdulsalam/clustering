using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    abstract class DistanceMetric
    {

        public abstract int getDistance(Feature observationOneFeature, Feature observationTwoFeature);
        
    }
}
