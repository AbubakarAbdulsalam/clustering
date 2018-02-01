using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
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
        /// <summary>
        /// Calculates the distance between this feature and another feature instance based 
        /// on the distanceMetric specified for this instance
        /// </summary>
        /// <param name="otherFeature">Feature instance to be compared to this instance</param>
        /// <returns>the numerical distance between these two instances based on the distance metric specifie</returns>
        public override int CalculateDistance(Feature otherFeature)
        {
            if(!(otherFeature is ComplexFeature))
            {
                //###create new exception class or find something to return
                throw  new MaxFeatureNumberExceeded("wrong");
            }
            return this.distanceMetric.GetDistance(otherFeature,this);
        }
        
        //delete ######
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

        //check index and throwindex exception #####TO DO
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override Feature GetChildFeature(int index)
        {  
            return this.childFeatures.ElementAtOrDefault(index);
        }

        public override void AddChildFeature(Feature additionalFeature)
        {
            this.childFeatures.Add(additionalFeature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherFeature"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public override Feature Average(int divisor)
        {
            //#####check divisor not negative or zero
            try
            {
                ComplexFeature newComplex = new ComplexFeature(this.distanceMetric);

                for (int i = 0; i < this.childFeatures.Count; i++)
                {
                    newComplex.AddChildFeature(this.childFeatures.ElementAt(i).Average(divisor));
                }
                return newComplex;
            }
            //#### FIIIIXXXXXX
            catch (DivideByZeroException)
            {
                return null;
            }
            
        }

        
    }
}
