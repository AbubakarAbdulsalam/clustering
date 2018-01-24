using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    class DoubleFeature : Feature
    {
        //distance metric used for this 
        private DistanceMetric distanceMetric;
        public override DistanceMetric MetricUsed
        {
            get { return distanceMetric; }
            set { distanceMetric = value; }
        }

        //value of the specific attriubute
        private Double attributeValue;
        public override Double FeatureValue
        {
            get { return attributeValue; }
            set { attributeValue = value; }
        }

        //constructor
        public DoubleFeature(DistanceMetric distanceMetric, Double value)
        {
            this.distanceMetric = distanceMetric;
            this.attributeValue = value;
        }

        //distanceCalculation
        public override int CalculateDistance(Feature otherFeature)
        {
            return distanceMetric.getDistance(this, otherFeature);
        }
    }
}
