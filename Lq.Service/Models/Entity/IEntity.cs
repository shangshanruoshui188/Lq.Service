using System;

namespace Lq.Service.Models.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
