using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    /// <summary>
    /// Represents a cluster of observations grouped together
    /// 
    /// </summary>
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
        

        /// <summary>
        /// recalculates the centroid of a cluster based on its current members 
        /// </summary>
        public void ReCalculateCentroid()
        {

            int maxFeature = this.currentCentroid.ExpectedNoOfFeatures;
            if(this.members.Count == 0)//implement better check #### TO-DOOOO
            {

            }
            else
            {
                //calculate the mean value for each attribute of the current centroid 
                
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
            
        }

        /// <summary>
        /// Adds a new observation into this cluster
        /// </summary>
        /// <param name="observation"></param>
        public void AddMember(Observation observation)
        {
            this.members.Add(observation);
        }

        /// <summary>
        /// Removes all observations belonging to this cluster
        /// </summary>
        public void EmptyMembers()
        {
            this.members.Clear();
        }

        



    }
}
