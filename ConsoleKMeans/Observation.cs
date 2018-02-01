using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    /// <summary>
    /// 
    /// </summary>
    public class Observation
    {
        //list of all attributes for an observation
        private IList<Feature> features;

        //using this so that all observations have the same number of attributes being used to describe them
        private int expectedNoOfFeatures;

        public int ExpectedNoOfFeatures
        {
            get { return expectedNoOfFeatures; }
            set { expectedNoOfFeatures = value; }
        }

        
        public int FeaturesCount
        { get { return this.features.Count; } }


        //constructor
        public Observation(int maxFeatureNumber)
        {
            this.features = new List<Feature>();
            this.expectedNoOfFeatures = maxFeatureNumber;
        }

        public int GetDistance(Observation observation)
        {
            //#### CONSIDER NORMALIZING in KMEANS
            int runningSum = 0;
            for(int i=0; i < this.features.Count; i++)
            {
               runningSum +=  this.features.ElementAt(i).CalculateDistance(observation.GetFeature(i));
            }
            return runningSum;
        }

        /// <summary>
        /// safeguarding against observations having unequal number of features 
        /// </summary>
        /// <param name="newFeature"></param>
        public void AddFeature(Feature newFeature)
        {
            if (this.features.Count == expectedNoOfFeatures)
            {
                throw new MaxFeatureNumberExceeded("feature can't be added, maximum will be exceeded");
            }
            else
            {
                this.features.Add(newFeature);
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newFeature"></param>

        public void ReplaceFeature(int index, Feature newFeature)
        {
            this.features.RemoveAt(index);
            this.features.Insert(index, newFeature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Feature GetFeature(int index)
        {
            return features.ElementAt(index);
        }

        public bool IsFeaturesComplete()
        {
            return this.features.Count == this.expectedNoOfFeatures;
        }
    }
}
