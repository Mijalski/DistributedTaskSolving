using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons
{
    public class SequencingJobInstanceJson
    {
        public IEnumerable<string> Vertices { get; set; }

        public long TargetLength { get; set; }
    }
}