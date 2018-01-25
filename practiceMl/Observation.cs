using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    class Observation
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
        //constructor
        public Observation(int maxFeatureNumber)
        {
            this.features = new List<Feature>();
            this.maxFeatureNumber = maxFeatureNumber;
        }

        public int GetDistance(Observation observation)
        {
            return 0;
        }

        public void AddFeature(Feature newFeature)
        {
            if (this.features.Count == maxFeatureNumber)
            {

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
