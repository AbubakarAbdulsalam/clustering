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
    }
}
