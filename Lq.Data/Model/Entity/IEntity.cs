using System;

namespace Lq.Data.Model.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }

}
