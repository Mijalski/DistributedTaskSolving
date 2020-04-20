using System;

namespace DistributedTaskSolving.Business.IGenerics
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletionDateTime { get; set; }
    }
}