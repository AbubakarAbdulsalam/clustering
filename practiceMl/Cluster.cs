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

        }

        



    }
}
