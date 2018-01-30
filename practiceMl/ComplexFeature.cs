using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public class ComplexFeature : Feature
    {
        //distancemetric
        private DistanceMetric distanceMetric;
        public override DistanceMetric MetricUsed
        {
            get { return distanceMetric; }
            set { distanceMetric = value; }
        }

        //list of child features
        private IList<Feature> childFeatures;
        public int ChildFeaturesCount
        {
            
            get { return childFeatures.Count; }
        }

        public override double FeatureValue {
            get { throw new NotImplementedException("The following class does not implement requested functionality " + this.GetType()); }
            set { throw new NotImplementedException("The following class does not implement requested functionality " + this.GetType()); }
        }




        //constructor
        public ComplexFeature(DistanceMetric metric)
        {
            //check distance metric is not null
            childFeatures = new List<Feature>();
            this.distanceMetric = metric;
        }

        // #####remove cast somehow #to do and check if otherFeature is null
        public override int CalculateDistance(Feature otherFeature)
        {
            return CalculateDistance((ComplexFeature)otherFeature);
        }
        

        private  int CalculateDistance(ComplexFeature otherFeature)
        {
            double distance = 0;
            for (int i = 0; i < this.childFeatures.Count; i++)
            {
                double tempDistance = this.distanceMetric.GetDistance(otherFeature.GetChildFeature(i), this.childFeatures.ElementAt(i));
                distance += Math.Pow(tempDistance,2);
            }
            return (int) Math.Sqrt( distance);
        }

        //check index and throwindex exception 
        public override Feature GetChildFeature(int index)
        {  
            return this.childFeatures.ElementAtOrDefault(index);
        }

        public override void AddChildFeature(Feature additionalFeature)
        {
            this.childFeatures.Add(additionalFeature);
        }

        
        public override Feature Sum(Feature otherFeature)
        {
            //#####check if otherFeature is null
            ComplexFeature feature = (ComplexFeature)otherFeature;
            ComplexFeature newFeature = new ComplexFeature(this.distanceMetric);
            for (int i = 0; i < this.childFeatures.Count; i++)
            {
                newFeature.AddChildFeature(this.childFeatures.ElementAt(i).Sum(feature.GetChildFeature(i)));
            }
            return newFeature;
        }

        public override Feature Average(int divisor)
        {
            //#####check divisor not negative or zero
            ComplexFeature newComplex = new ComplexFeature(this.distanceMetric);
            
            for (int i = 0; i < this.childFeatures.Count; i++)
            {
                newComplex.AddChildFeature(this.childFeatures.ElementAt(i).Average(divisor));
            }
            return newComplex;
        }

        
    }
}
