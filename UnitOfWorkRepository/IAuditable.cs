
using System;

namespace UnitOfWorkRepository
{
    public interface IAuditable
    {
        Guid CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        Guid UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}