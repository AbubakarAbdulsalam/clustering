using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practiceMl
{
    public abstract class Feature
    {
        public abstract DistanceMetric MetricUsed { get; set; }

        public abstract Double FeatureValue { get; set; }

        public abstract int CalculateDistance(Feature otherFeature);

        public abstract Feature Sum(Feature otherFeature);

        public abstract Feature Average(int divisor);
    }
}
