using Lq.Service.Models.Attribute;
using Lq.Service.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Service.Models
{
    /// <summary>
    /// 管理员，运维用户
    /// </summary>
    [Table("adminuser")]
    public class Administrator : User
    {
        [ColumnComment("Mac地址")]
        [MaxLength(50)]
        public string Mac { get; set; }
        [ColumnComment("Ip地址")]
        [MaxLength(50)]
        public string Ip { get; set; }

        [ColumnComment("限制Mac地址登陆")]
        public bool RestrictMac { get; set; }
        [ColumnComment("限制Ip地址登陆")]
        public bool RestrictIp { get; set; }
    }
}