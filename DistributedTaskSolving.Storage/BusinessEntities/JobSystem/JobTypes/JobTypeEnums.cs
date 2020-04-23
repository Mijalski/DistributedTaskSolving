using System;
using System.Collections.Generic;

namespace DistributedTaskSolving.Business.BusinessEntities.JobSystem.JobTypes
{
    public static class JobTypeEnums
    {
        public static List<string> DefaultJobTypes = new List<string>
        {
            "PasswordBruteForcing",
            "MonteCarlo",
            "WordGuessing"
        };
    }
}