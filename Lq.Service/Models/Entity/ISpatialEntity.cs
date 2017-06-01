namespace Lq.Service.Models.Entity
{
    public interface ISpatialEntity:IEntity
    {
        string Location { get; set; }
        string Contour { get; set; }
        string Geojson { get; set; }
    }
}
