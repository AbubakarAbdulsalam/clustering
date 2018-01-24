using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    class DoubleFeature : Feature
    {
        private DistanceMetric distanceMetric;
        

        public override DistanceMetric MetricUsed
        {
            get { return distanceMetric; }
            set { distanceMetric = value; }
        }
        public DoubleFeature(DistanceMetric distanceMetric)
        {
            this.distanceMetric = distanceMetric;
        }
    }
}
