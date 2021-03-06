﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    /// <summary>
    /// 
    /// </summary>
    public class DoubleFeature : Feature
    {
        //distance metric used for this 
        private DistanceMetric distanceMetric;
        public override DistanceMetric MetricUsed
        {
            get { return distanceMetric; }
            set { distanceMetric = value; } //consider making immutable 
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherFeature"></param>
        /// <returns></returns>
        public override int CalculateDistance(Feature otherFeature)
        {//####check otherFeature not null
            return distanceMetric.GetDistance(this, otherFeature);
        }

        //sum
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherFeature"></param>
        /// <returns></returns>
        public override Feature Sum(Feature otherFeature)
        {//####check other  feature not null
            return (new DoubleFeature(this.distanceMetric, (this.attributeValue + otherFeature.FeatureValue)));
        }

        //average
        /// <summary>
        /// 
        /// </summary>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public override Feature Average(int divisor)
        {
            //####change to virtual and specify some logic(error check ) in parent class 
            try
            {
                return (new DoubleFeature(this.distanceMetric, (this.FeatureValue / (double)divisor)));
            }
            catch (DivideByZeroException)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override Feature GetChildFeature(int index)
        {//###throw exception
             throw new NotImplementedException("The following class does not implement requested functionality " + this.GetType()); 
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        public override void AddChildFeature(Feature child)
        {//###throw exception
            throw new NotImplementedException("The following class does not implement requested functionality " + this.GetType()); 
            
        }
    }
}
