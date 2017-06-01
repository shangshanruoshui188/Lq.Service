namespace Lq.Service.Models.Entity
{
    public interface IWare:IEntity
    {
        decimal? Price { get; set; }
        string Description { get; set; }
        int? Stock { get; set; }
        decimal? Discount { get; set; }
    }
}