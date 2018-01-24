using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    abstract class Feature
    {
        public abstract DistanceMetric MetricUsed { get; set; }

        public abstract Double FeatureValue { get; set; }

        public abstract int calculateDistance(Feature otherFeature);
    }
}
