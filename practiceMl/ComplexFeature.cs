﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    class ComplexFeature : Feature
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

        public override double FeatureValue { get { return -1; } set {; } }


        //constructor
        public ComplexFeature(DistanceMetric metric)
        {
            childFeatures = new List<Feature>();
            this.distanceMetric = metric;
        }

        // remove cast somehow #to do 
        public override int CalculateDistance(Feature otherFeature)
        {
            return CalculateDistance((ComplexFeature)otherFeature);
        }
        //
        private  int CalculateDistance(ComplexFeature otherFeature)
        {
            int distance = 0;
            for (int i = 0; i < this.childFeatures.Count; i++)
            {
                int tempDistance = this.distanceMetric.getDistance(otherFeature.GetChildFeature(i), this.childFeatures.ElementAt(i));
                distance += Math.Abs(tempDistance);
            }
            return distance;
        }

        //#to do. defensive check if list is not initialized
        public Feature GetChildFeature(int index)
        {  
            return this.childFeatures.ElementAtOrDefault(index);
        }

        public void AddChildFeature(Feature additionalFeature)
        {
            this.childFeatures.Add(additionalFeature);
        }
        public override Feature Sum(Feature otherFeature)
        {
            ComplexFeature feature = (ComplexFeature)otherFeature;
            ComplexFeature newFeature = new ComplexFeature(this.distanceMetric);
            for (int i = 0; i < this.childFeatures.Count; i++)
            {
                newFeature.AddChildFeature(this.childFeatures.ElementAt(i).Sum(feature.GetChildFeature(i)));
            }
            return newFeature;
        }
    }
}
