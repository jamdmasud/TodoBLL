using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWorkRepository
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState State { get; set; }
    }
}