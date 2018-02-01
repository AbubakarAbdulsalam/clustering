using System.Collections.Generic;
using System.Linq;

namespace ConsoleKMeans
{
    public class KMeans
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

        //max  iteration 
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
            InitializeClusters();
            for (int i = 0; i < centroids.Count; i++)
            {
                this.currentClusters.ElementAt(i).ClusterCentroid = centroids.ElementAt(i);
            }
        }
        

        //recalculate centroid 
        public void ReCalculateCentroids()
        {
            foreach (Cluster c in currentClusters)
                c.ReCalculateCentroid();
        }

        private void InitializeClusters()
        {
            for (int i = 0; i < this.noCluster; i++)
                this.currentClusters.Add(new Cluster());
        }

        private void AssignCluster(Observation someObservation)
        {
            var distances  = new Dictionary<Cluster, int>();
          

            for (int i = 0; i < this.currentClusters.Count; i++)
                distances.Add(this.currentClusters.ElementAt(i), this.currentClusters.ElementAt(i).ClusterCentroid.GetDistance(someObservation));

            int closestDistance = distances.Min(dis => dis.Value);
            distances.FirstOrDefault(dis => dis.Value == closestDistance).Key.AddMember(someObservation);
               
        }

        public void AssignCluster(IList<Observation> observations)
        {
            for (int i = 0; i < observations.Count; i++)
                AssignCluster(observations.ElementAt(i));
        }

        public void EmptyClusters()
        {
            foreach (Cluster someCluster in this.currentClusters)
                someCluster.EmptyMembers();
        }
    }
}
