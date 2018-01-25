using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    class KMeans
    {
        private int noCluster;

        //number of clusters to create
        public int KCluster { get { return noCluster; } set { noCluster = value; } }

        //cluster list
        private IList<Cluster> currentClusters;

        //tolerancer
        private double tolerance;
        public double Tolerance
        {
            get { return tolerance; }
            set { tolerance = value; }
        }

        //mac iteration 
        private int maxIteration;
        public int MaxIteration
        { get { return maxIteration; }
            set { maxIteration = value; }
        }

        //constructor 
        public KMeans(int maxIteration, double tolerance, int k)
        {
            this.currentClusters = new List<Cluster>();
            this.noCluster = k;
            this.tolerance = tolerance;
            this.maxIteration = maxIteration;

        }

        //intialize centroids 
        public void InitializeCentroids(List<Observation> centroids)
        {
            for (int i = 0; i < centroids.Count; i++)
            {
                this.currentClusters.ElementAt(i).ClusterCentroid = centroids.ElementAt(i);
            }
        }
        

        //recalculate centroid 
        public void ReCalculateCentroids()
        {
            foreach (Cluster c in currentClusters)
            {
                c.ReCalculateCentroid();
            }
        }

        private void InitializeClusters()
        {
            for (int i = 0; i < this.noCluster; i++)
            {
                this.currentClusters.Add(new Cluster());
            }
        }
    }
}
