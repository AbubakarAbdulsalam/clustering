using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public class Observation
    {
        //list of all attributes for an observation
        private IList<Feature> features;
        private int maxFeatureNumber;

        public int MaxFeatureNumber
        {
            get { return maxFeatureNumber; }
            set
            {
                maxFeatureNumber = value;
            }
        }

        
        public int FeaturesCount
        { get { return this.features.Count; } }
        //constructor
        public Observation(int maxFeatureNumber)
        {
            this.features = new List<Feature>();
            this.maxFeatureNumber = maxFeatureNumber;
        }

        public int GetDistance(Observation observation)
        {
            //#### CONSIDER NORMALIZING 
            int runningSum = 0;
            for(int i=0; i < this.features.Count; i++)
            {
               runningSum +=  this.features.ElementAt(i).CalculateDistance(observation.GetFeature(i));
            }
            return runningSum;
        }

        public void AddFeature(Feature newFeature)
        {
            if (this.features.Count == maxFeatureNumber)
            {
                throw new MaxFeatureNumberExceeded("feature can't be added, maximum will be exceeded");
            }
            else
            {
                this.features.Add(newFeature);
                
            }
        }

        

        public void ReplaceFeature(int index, Feature newFeature)
        {
            this.features.RemoveAt(index);
            this.features.Insert(index, newFeature);
        }


        public Feature GetFeature(int index)
        {
            return features.ElementAt(index);
        }
    }
}
