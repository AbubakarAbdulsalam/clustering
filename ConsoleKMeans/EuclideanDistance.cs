using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    public class EuclideanDistance : DistanceMetric
    {
        public EuclideanDistance() { }


        
        public override int GetDistance(Feature observationOneFeature, Feature observationTwoFeature)
        {
            if (observationTwoFeature is ComplexFeature && observationOneFeature is ComplexFeature)
            {
                return GetDistance((ComplexFeature)observationOneFeature, (ComplexFeature)observationTwoFeature);
            }
            //#### create distance metric mismatch exception class 
            throw new MaxFeatureNumberExceeded("Can't use euclidean distance");
            
        }

        //###consider definig childFeature count in base class feature and exceptions in none ComplexFeature sub classes 
        //and moving logic here to above function
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
