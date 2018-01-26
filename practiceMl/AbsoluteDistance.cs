using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public class AbsoluteDistance : DistanceMetric
    {

        public AbsoluteDistance()
        {
        }
        public override int getDistance(Feature observationOneFeature, Feature observationTwoFeature)
        {
            return (int) Math.Abs(observationOneFeature.FeatureValue - observationTwoFeature.FeatureValue);
        }
    }
}
