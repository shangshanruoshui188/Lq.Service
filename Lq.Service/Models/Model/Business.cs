using Lq.Service.Models.Attribute;
using Lq.Service.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lq.Service.Models
{
    /// <summary>
    /// 商户用户
    /// </summary>
    [Table("merchantuser")]
    public class Merchant : User
    {
        [ColumnComment("商户描述")]
        public string Description { get; set; }
    }

    #region 商品

    #endregion
}