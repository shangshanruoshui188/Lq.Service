namespace Service.Entity
{
    /// <summary>
    /// 所有商品实体需要实现的接口
    /// </summary>
    public interface IWare:IEntity
    {
        decimal? Price { get; set; }
        string Description { get; set; }
        int? Stock { get; set; }
        decimal? Discount { get; set; }
    }
}