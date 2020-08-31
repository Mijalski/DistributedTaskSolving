namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobInstances.Jsons
{
    public class MonteCarloJobInstanceJson
    {
        public long TotalPiCalculationsCount { get; set; }
        public long PiCalculationsCountPerClient { get; set; }
        public double CurrentPiValue { get; set; }
    }
}