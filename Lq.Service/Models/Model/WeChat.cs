using Lq.Service.Models.Attribute;
using Lq.Service.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Service.Models
{
    public class WCAccount:BaseEntity
    {
        [MaxLength(20)]
        [ColumnComment("微信账号属性名")]
        public string Key { get; set; }

        [MaxLength(100)]
        [ColumnComment("微信账号属性值")]
        public string Value { get; set; }

        [MaxLength(50)]
        [ColumnComment("属性值生成时间")]
        public DateTime Date { get; set; }
    }

    [Table("WCUser")]
    public class WCUser: User
    {
        [MaxLength(255)]
        [ColumnComment("用户性别")]
        public string Sex { get; set; }


        [ColumnComment("用户年龄")]
        public int Age { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户昵称")]
        public string NickName { get; set; }


        [MaxLength(255)]
        [ColumnComment("用户登录密码")]
        public string Password { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户所在省份")]
        public string Province { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户所在城市")]
        public string City { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户所在县区")]
        public string County { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户详细地址")]
        public string Address { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户职业")]
        public string Occupation { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户邮编")]
        public string PostCode { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户设置安全问题")]
        public string SecurityQuestion { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户所设置安全问题的答案")]
        public string Answer { get; set; }

        [MaxLength(255)]
        [ColumnComment("用户固定电话")]
        public string FixedTel { get; set; }

        [MaxLength(255)]
        [ColumnComment("订阅日期")]
        public string RegDate { get; set; }

        [MaxLength(200)]
        [ColumnComment("用户微信识别ID")]
        public string WeChatId { get; set; }

        [MaxLength(20)]
        [ColumnComment("用户订阅状态")]
        public string RegState { get; set; }

        public virtual ICollection<WCPushMessageUserMap> ReceiveMessages { get; set; }
        public virtual ICollection<WCOrder> Orders { get; set; }
        public virtual ICollection<WCComment> Comments { get; set; }
        public virtual ICollection<WCUserMessage> SendMessages { get; set; }
        public virtual ICollection<WCBrowseHistory> BrowseHistories { get; set; }
        public virtual ICollection<WCSearchHistory> SearchHistories { get; set; }
        public virtual ICollection<WCCollection> Collections { get; set; }
        public virtual ICollection<WCTrace> Traces { get; set; }
    }

    public class WCOrder : BaseEntity
    {
        [ColumnComment("用户ID")]
        [ForeignKey("User")]
        public int WCUserId { get; set; }

        [ColumnComment("订单包含的物品id集合，每个id应包含类别前缀")]
        [MaxLength(500)]
        public string Goods { get; set; }


        [MaxLength(255)]
        [ColumnComment("订单支付方式")]
        public string Payment { get; set; }

        [ColumnComment("订单创建日期")]
        public DateTime GenerateDate { get; set; }


        [ColumnComment("订单付款时间")]
        public DateTime PaymentTime { get; set; }

        [ColumnComment("订单发货时间")]
        public DateTime DeliverTime { get; set; }

        [ColumnComment("订单成交时间")]
        public DateTime TransactionTime { get; set; }

        [MaxLength(255)]
        [ColumnComment("订单物流公司")]
        public string Logistics { get; set; }

        [MaxLength(22)]
        [ColumnComment("订单物流编号")]
        public string TrackingNum { get; set; }

        [ColumnComment("订单包含物品数量")]
        public int Quantity { get; set; }

        [MaxLength(255)]
        [ColumnComment("订单是否包含发票")]
        public string Invoice { get; set; }

        [MaxLength(255)]
        [ColumnComment("订单是否购买订单险")]
        public string Insurance { get; set; }

        [MaxLength(255)]
        [ColumnComment("订单状态")]
        public string Status { get; set; }

        [MaxLength(255)]
        [ColumnComment("备注信息")]
        public string Remark { get; set; }

        [ColumnComment("订单金额")]
        public decimal? Sum { get; set; }


        public virtual WCUser User { get; set; }
    }

    public class WCComment : BaseEntity
    {
        public virtual WCUser User { get; set; }

        [ForeignKey("User")]
        [ColumnComment("评论者ID")]
        public int WCUserId { get; set; }

        [ColumnComment("评论时间")]
        public DateTime CommentTime { get; set; }

        [MaxLength(255)]
        [ColumnComment("评论内容")]
        public string CommentContent { get; set; }

        [MaxLength(255)]
        [ColumnComment("评论回复")]
        public string Reply { get; set; }

        [ColumnComment("评论对象ID，格式为前缀+id，前缀识别评论对象类别，id为该类别对象编号")]
        public int CommentObjectId { get; set; }

        [MaxLength(255)]
        [ColumnComment("评论反馈")]
        public string Feedback { get; set; }

        [MaxLength(255)]
        [ColumnComment("附加建议")]
        public string Advice { get; set; }

        [ColumnComment("评论时间")]
        public DateTime Date { get; set; }
    }

    public class WCMaterial : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("素材类型")]
        public string Type { get; set; }

        [MaxLength(100)]
        [ColumnComment("素材URL")]
        public string Url { get; set; }


        [ColumnComment("素材上传时间")]
        public DateTime UploadTime { get; set; }

        [ColumnComment("素材过期时间")]
        public DateTime OverdueTime { get; set; }


        [ColumnComment("素材上传者ID")]
        public int? UploadorId { get; set; }
    }

    public class WCPushMessage : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("消息URL")]
        public string Url { get; set; }

        [MaxLength(50)]
        [ColumnComment("标题")]
        public string Title { get; set; }

        [MaxLength(20)]
        [ColumnComment("类型")]
        public string Type { get; set; }

        [MaxLength(20)]
        [ColumnComment("主题")]
        public string Theme { get; set; }

        [MaxLength(100)]
        [ColumnComment("内容")]
        public string Content { get; set; }

        [MaxLength(100)]
        [ColumnComment("消息摘要")]
        public string Abstract { get; set; }

        [ColumnComment("生成时间")]
        public DateTime CreateTime { get; set; }

        [ColumnComment("推送时间")]
        public DateTime PushTime { get; set; }

        [ColumnComment("推送目标用户数")]
        public int TargetUserCount { get; set; }

        public virtual ICollection<WCPushMessageUserMap> Users { get; set; }
    }

    public class WCPushMessageUserMap
    {
        [Key,Column(Order =1)]
        [ForeignKey("User")]
        [ColumnComment("消息目标用户id")]
        public int WCUserId { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Message")]
        [ColumnComment("消息id")]
        public int WCPushMessageId { get; set; }

        [ColumnComment("推送时间")]
        public DateTime PushDate { get; set; }


        public virtual WCUser User { get; set; }
        public virtual WCPushMessage Message { get; set; }

    }

    public class WCUserMessage : BaseEntity
    {
        public virtual WCUser User { get; set; }

        [ForeignKey("User")]
        [ColumnComment("用户id")]
        public int WCUserId { get; set; }

        [ColumnComment("消息内容")]
        [MaxLength(500)]
        public string Content { get; set; }

        [ColumnComment("发送时间")]
        public DateTime SendTime { get; set; }
    }

    public class WCBrowseHistory : BaseEntity
    {
        public virtual WCUser User { get; set; }

        [ForeignKey("User")]
        [ColumnComment("用户id")]
        public int WCUserId { get; set; }

        [MaxLength(100)]
        [ColumnComment("浏览内容URL")]
        public string ContentUrl { get; set; }

        [MaxLength(20)]
        [ColumnComment("内容类别")]
        public string ContentType { get; set; }

        [ColumnComment("内容识别ID")]
        public int ContentRecognizeId { get; set; }

        [ColumnComment("浏览时间")]
        public DateTime ViewTime { get; set; }
    }

    public class WCSearchHistory : BaseEntity
    {

        public virtual WCUser User { get; set; }

        [ForeignKey("User")]
        [ColumnComment("用户id")]
        public int WCUserId { get; set; }


        [MaxLength(50)]
        [ColumnComment("搜索关键字")]
        public string SearchKeyword { get; set; }

        [ColumnComment("搜索时间")]
        public DateTime SearchTime { get; set; }
    }

    public class WCCollection : BaseEntity
    {

        public virtual WCUser User { get; set; }

        [ForeignKey("User")]
        [ColumnComment("用户id")]
        public int WCUserId { get; set; }

        [MaxLength(100)]
        [ColumnComment("收藏内容")]
        public string Content { get; set; }

        [MaxLength(20)]
        [ColumnComment("收藏URL")]
        public string Url { get; set; }

        [MaxLength(20)]
        [ColumnComment("收藏标题")]
        public string Theme { get; set; }

        [ColumnComment("收藏时间")]
        public DateTime Date { get; set; }
    }

    public class WCTrace : BaseEntity
    {
        public virtual WCUser User { get; set; }

        [ForeignKey("User")]
        [ColumnComment("用户id")]
        public int WCUserId { get; set; }

        [ColumnComment("时间")]
        public DateTime Date { get; set; }

        [MaxLength(50)]
        [ColumnComment("位置")]
        public string Location { get; set; }

        [MaxLength(100)]
        [ColumnComment("位置描述")]
        public string Description { get; set; }
    }
}

