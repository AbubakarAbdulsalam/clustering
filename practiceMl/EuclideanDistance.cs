using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public class EuclideanDistance : DistanceMetric
    {
        public EuclideanDistance() { }


        
        public override int getDistance(Feature observationOneFeature, Feature observationTwoFeature)
        {
            return GetDistance((ComplexFeature)observationOneFeature, (ComplexFeature)observationTwoFeature);
        }

        private int GetDistance(ComplexFeature featureOne, ComplexFeature featureTwo)
        {
            double runningSum = 0.0;
            for (int i = 0; i < featureOne.ChildFeaturesCount; i++)
            {
                runningSum +=Math.Pow(featureOne.GetChildFeature(i).CalculateDistance(featureTwo.GetChildFeature(i)),2);
            }
            return (int)Math.Sqrt(runningSum);
        }
    }
}
