using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKMeans
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class DistanceMetric
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="observationOneFeature"></param>
        /// <param name="observationTwoFeature"></param>
        /// <returns></returns>
        public abstract int GetDistance(Feature observationOneFeature, Feature observationTwoFeature);
        
    }
}
