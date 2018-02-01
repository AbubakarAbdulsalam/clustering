using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    public class AbsoluteDistance : DistanceMetric
    {

        public AbsoluteDistance()
        {
        }
        //gets the distance between two features (Absolute distance) ## consider double instead 
        public override int GetDistance(Feature observationOneFeature, Feature observationTwoFeature)
        {
            return (int) Math.Abs(observationOneFeature.FeatureValue - observationTwoFeature.FeatureValue);
        }
    }
}
