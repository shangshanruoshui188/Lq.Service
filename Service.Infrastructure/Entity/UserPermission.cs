using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Entity
{
    public class UserPermission : PerssionProperty
    {
        [Key,Column(Order =1)]
        [ColumnComment("用户id")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        

        public virtual User User { get; set; }
    }

}