using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lq.Service.Models.Entity
{
    public interface ISpatialEntity:IEntity
    {
        string Location { get; set; }
        string Contour { get; set; }
        string Geojson { get; set; }
    }
}
