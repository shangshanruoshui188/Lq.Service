namespace Service.Entity
{
    /// <summary>
    /// 具有空间属性实体必须实现的接口
    /// </summary>
    public interface ISpatialEntity:IEntity
    {
        string Location { get; set; }
        string Contour { get; set; }
        string GeoJson { get; set; }
    }
}
