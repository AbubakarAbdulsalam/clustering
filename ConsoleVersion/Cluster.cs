using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public class Cluster
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

        public Cluster(Observation centroid)
        {
            this.members = new List<Observation>();
            this.currentCentroid = centroid;
        }
        //constructor 
        public Cluster() : this(null) { }
        

        
        public void ReCalculateCentroid()
        {
            int maxFeature = this.members.ElementAt(0).MaxFeatureNumber;
           
            Observation newCentroid = new Observation(maxFeature);
            newCentroid = members.ElementAt(0);
            for (int i = 0; i < maxFeature; i++)
            {
                for (int j = 1; j < this.members.Count; j++)
                {
                   newCentroid.ReplaceFeature(i, newCentroid.GetFeature(i).Sum(this.members.ElementAt(j).GetFeature(i)));
                }
                newCentroid.ReplaceFeature(i, newCentroid.GetFeature(i).Average(this.members.Count));
            }
            this.prevCentroid = currentCentroid;
            this.currentCentroid = newCentroid;
        }

        public void AddMember(Observation observation)
        {
            this.members.Add(observation);
        }

        public void EmptyMembers()
        {
            this.members.Clear();
        }

        



    }
}
