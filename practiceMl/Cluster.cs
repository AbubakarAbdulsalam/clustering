using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    class Cluster
    {

        private Observation currentCentroid;

        private Observation prevCentroid;


        public Observation ClusterCentroid
        {
            get { return currentCentroid; }
            set { currentCentroid = value; }
        }

        public Observation OldClusterCentroid
        {
            get { return prevCentroid; }
            set { prevCentroid = value; }
        }

        public int ClusterCount
        {
            get { return members.Count; }
        }

        private String label;

        public String ClusterLabel
        {
            set { label = value; }
            get { return label; }
        }

        private IList<Observation> members;

        //constructor 
        public Cluster()
        {
            this.members = new List<Observation>();
        }

        public void ReCalculateCentroid()
        {
            int maxFeature = this.members.ElementAt(0).MaxFeatureNumber;
            IList<Feature> newCentroidFeatures = new List<Feature>();
            Observation newCentroid = new Observation(maxFeature);
            newCentroid = members.ElementAt(0);
            for (int i = 0; i < maxFeature; i++)
            {
                for (int j = 1; j < this.members.Count; j++)
                {
                   newCentroid.ReplaceFeature(i, newCentroid.GetFeature(i).Sum(this.members.ElementAt(j).GetFeature(i)));
                }
            }
           
        }

        



    }
}
