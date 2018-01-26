using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public class DoubleFeature : Feature
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

        //sum
        public override Feature Sum(Feature otherFeature)
        {
            return (new DoubleFeature(this.distanceMetric, (this.attributeValue + otherFeature.FeatureValue)));
        }

        //average
        public override Feature Average(int divisor)
        {
            return (new DoubleFeature(this.distanceMetric,(this.FeatureValue / (double)divisor)));
        }

        public override Feature GetChildFeature(int index)
        {
            throw new NotImplementedException();
        }
    }
}
