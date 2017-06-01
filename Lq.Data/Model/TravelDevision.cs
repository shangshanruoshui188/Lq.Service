using Lq.Data.Attribute;
using Lq.Data.Model.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Data.Model
{
    /// <summary>
    /// 农家乐
    /// </summary>
    public class FarmHouse : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("详细地址")]
        public string Adress { get; set; }
        [MaxLength(100)]
        [ColumnComment("所属行政区划")]
        public string AdministrativeDevision { get; set; }
        [MaxLength(100)]
        [ColumnComment("建筑风格")]
        public string BuildStyle { get; set; }
        [MaxLength(100)]
        [ColumnComment("营业时间")]
        public string BusinessHours { get; set; }
        [MaxLength(100)]
        [ColumnComment("公交线路")]
        public string BusLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("人均消费")]
        public string PerCapitaConsumption { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文简称")]
        public string ChineseAbbrevition { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文名称")]
        public string ChineseName { get; set; }
        [MaxLength(100)]
        [ColumnComment("标识代码")]
        public string Code { get; set; }
        [MaxLength(100)]
        [ColumnComment("就餐方式")]
        public string EatType { get; set; }
        [MaxLength(100)]
        [ColumnComment("电子邮件")]
        public string Email { get; set; }
        [MaxLength(100)]
        [ColumnComment("英文名称")]
        public string EnglishName { get; set; }
        [MaxLength(100)]
        [ColumnComment("特色菜品")]
        public string Environment { get; set; }
        [MaxLength(100)]
        [ColumnComment("传真号码")]
        public string FaxNumber { get; set; }
        [MaxLength(100)]
        [ColumnComment("总机号码")]
        public string SwitchBoardPhone { get; set; }
        [MaxLength(100)]
        [ColumnComment("荣誉资质")]
        public string Honor { get; set; }
        [MaxLength(432)]
        [ColumnComment("餐饮场所简介")]
        public string Introduce { get; set; }
        [MaxLength(100)]
        [ColumnComment("关键词")]
        public string KeyWords { get; set; }
        [MaxLength(100)]
        [ColumnComment("装修时间")]
        public string LastDecorationTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("餐饮场所级别")]
        public string Level { get; set; }
        [MaxLength(500)]
        [ColumnComment("标识图片")]
        public string Logo { get; set; }
        [MaxLength(100)]
        [ColumnComment("主营菜系")]
        public string MainContent { get; set; }
        [MaxLength(100)]
        [ColumnComment("用餐目的")]
        public string MealPurpose { get; set; }
        [MaxLength(100)]
        [ColumnComment("包间数")]
        public string MeetingFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("开业时间")]
        public string OpeningTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边其它配套设施")]
        public string OtherFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("其它交通说明")]
        public string OtherLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("停车场")]
        public string ParkingLots { get; set; }
        [MaxLength(100)]
        [ColumnComment("图片库")]
        public string Photos { get; set; }
        [MaxLength(100)]
        [ColumnComment("门户网站")]
        public string Portals { get; set; }
        [MaxLength(100)]
        [ColumnComment("邮政编码")]
        public string PostCode { get; set; }
        [MaxLength(100)]
        [ColumnComment("状态")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("配套设施")]
        public string ResortFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("最大可容纳人数")]
        public string SafeFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("自驾线路")]
        public string SelfDrvingCircuit { get; set; }
        [MaxLength(100)]
        [ColumnComment("附加服务")]
        public string ServiceTypes { get; set; }
        [MaxLength(100)]
        [ColumnComment("更新时间")]
        public string UpdateTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边住宿")]
        public string SurroundomhAccommodation { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边娱乐")]
        public string SurroundingEntertainment { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边景点")]
        public string SurroundingScenicSpot { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边购物")]
        public string SurroundingShopping { get; set; }
        [MaxLength(100)]
        [ColumnComment("餐位数")]
        public string TableRoom { get; set; }
        [MaxLength(100)]
        [ColumnComment("餐饮场所类型")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微博")]
        public string WeiBoSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微信")]
        public string WeiXinSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("经纬度")]
        public string XY { get; set; }
        [MaxLength(100)]
        [ColumnComment("星级")]
        public string Star { get; set; }
        public virtual ICollection<LocalStore> LocalStores { get; set; }

    }
    /// <summary>
    /// 特产商店
    /// </summary>
    public class LocalStore : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("详细地址")]
        public string Adress { get; set; }
        [MaxLength(100)]
        [ColumnComment("所属行政区划")]
        public string AdministrativeDevision { get; set; }
        [MaxLength(100)]
        [ColumnComment("营业时间")]
        public string BusinessHours { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文名称")]
        public string ChineseName { get; set; }
        [MaxLength(100)]
        [ColumnComment("电话")]
        public string Telephone { get; set; }
        [MaxLength(432)]
        [ColumnComment("简介")]
        public string Introduce { get; set; }
        [MaxLength(100)]
        [ColumnComment("关键词")]
        public string KeyWords { get; set; }
        [MaxLength(100)]
        [ColumnComment("开业时间")]
        public string OpeningTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("主营产品")]
        public string Product { get; set; }
        [MaxLength(100)]
        [ColumnComment("图片库")]
        public string Photos { get; set; }
        [MaxLength(100)]
        [ColumnComment("邮政编码")]
        public string PostCode { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微博")]
        public string WeiBoSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微信")]
        public string WeiXinSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("经纬度")]
        public string XY { get; set; }
        [MaxLength(100)]
        [ColumnComment("星级")]
        public string Star { get; set; }

        public virtual FarmHouse FarmHouse { get; set; }
    }
    /// <summary>
    /// 酒店
    /// </summary>
    public class Hotel : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("详细地址")]
        public string Adress { get; set; }
        [MaxLength(100)]
        [ColumnComment("所属行政区划")]
        public string AdministrativeDivision { get; set; }
        [MaxLength(100)]
        [ColumnComment("总床位数")]
        public string BedNum { get; set; }
        [MaxLength(100)]
        [ColumnComment("建筑风格")]
        public string BuildingStyle { get; set; }
        [MaxLength(100)]
        [ColumnComment("公交路线")]
        public string BusLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("营业时间")]
        public string BusinessHours { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文简称")]
        public string ChineseAbbrevition { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文名称")]
        public string ChineseName { get; set; }
        [MaxLength(100)]
        [ColumnComment("标识代码")]
        public string Code { get; set; }
        [MaxLength(100)]
        [ColumnComment("押金/预付款")]
        public string Deposit { get; set; }
        [MaxLength(100)]
        [ColumnComment("电子邮件")]
        public string Email { get; set; }
        [MaxLength(100)]
        [ColumnComment("英文名称")]
        public string EnglishName { get; set; }
        [MaxLength(100)]
        [ColumnComment("传真号码")]
        public string FaxNumber { get; set; }
        [MaxLength(100)]
        [ColumnComment("总机号码")]
        public string SwitchBoardPhone { get; set; }
        [MaxLength(100)]
        [ColumnComment("荣誉资质")]
        public string Honor { get; set; }
        [MaxLength(1000)]
        [ColumnComment("简介")]
        public string Introduce { get; set; }
        [MaxLength(100)]
        [ColumnComment("关键词")]
        public string KeyWords { get; set; }
        [MaxLength(100)]
        [ColumnComment("装修时间")]
        public string LastDecorationTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("住宿场所级别")]
        public string Level { get; set; }
        [MaxLength(500)]
        [ColumnComment("标识图片")]
        public string Logo { get; set; }
        [MaxLength(100)]
        [ColumnComment("膳食安排")]
        public string Meals { get; set; }
        [MaxLength(100)]
        [ColumnComment("开业时间")]
        public string OpeningTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边其它配套设施")]
        public string OtherFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("其它线路")]
        public string OtherLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("停车场")]
        public string ParkingLots { get; set; }
        [MaxLength(100)]
        [ColumnComment("宠物")]
        public string Pets { get; set; }
        [MaxLength(100)]
        [ColumnComment("图片库")]
        public string Photos { get; set; }
        [MaxLength(100)]
        [ColumnComment("门户网站")]
        public string Portals { get; set; }
        [MaxLength(100)]
        [ColumnComment("邮政编码")]
        public string PostCode { get; set; }
        [MaxLength(100)]
        [ColumnComment("更新时间")]
        public string UpdateTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("配套设施")]
        public string ResortFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("客房数")]
        public string RoomNum { get; set; }
        [MaxLength(100)]
        [ColumnComment("房型")]
        public string RoomType { get; set; }
        [MaxLength(100)]
        [ColumnComment("自驾线路")]
        public string SelfDrvingCircuit { get; set; }
        [MaxLength(600)]
        [ColumnComment("特殊条款")]
        public string SpecialTerms { get; set; }
        [MaxLength(100)]
        [ColumnComment("状态")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边住宿")]
        public string SurroundomhAccommodation { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边娱乐")]
        public string SurroundingEntertainment { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边景点")]
        public string SurroundingScenicSpot { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边购物")]
        public string SurroundingShopping { get; set; }
        [MaxLength(100)]
        [ColumnComment("住宿场所类型")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微博")]
        public string WeiBoSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微信")]
        public string WeiXinSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("经纬度")]
        public string XY { get; set; }
        [MaxLength(100)]
        [ColumnComment("星级")]
        public string Star { get; set; }


    }
    /// <summary>
    /// 龙泉青瓷
    /// </summary>
    public class Celadon : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("名称")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("品类")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("年代")]
        public string Time { get; set; }
        [MaxLength(100)]
        [ColumnComment("产窑")]
        public string Kiln { get; set; }
        [MaxLength(200)]
        [ColumnComment("图片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("馆藏地")]
        public string CollectionPlace { get; set; }
        [ColumnComment("售价")]
        public decimal? Price { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有者")]
        public string Owner { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有者电话")]
        public string Telephone { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有者微信")]
        public string Wechat { get; set; }
        [MaxLength(100)]
        [ColumnComment("工艺特色")]
        public string Feature { get; set; }
        [MaxLength(100)]
        [ColumnComment("备注")]
        public string Comment { get; set; }
    }
    /// <summary>
    /// 景点
    /// </summary>
    public class ViewSpot : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("详细地址")]
        public string Adress { get; set; }
        [MaxLength(100)]
        [ColumnComment("所属行政区划")]
        public string AdministrativeDevision { get; set; }
        [MaxLength(1000)]
        [ColumnComment("公交线路")]
        public string BusLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("开放时间")]
        public string BusinessHours { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文简称")]
        public string ChineseAbbrevition { get; set; }
        [MaxLength(100)]
        [ColumnComment("中文名称")]
        public string ChineseName { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边餐饮")]
        public string CircumJacentmeal { get; set; }
        [MaxLength(100)]
        [ColumnComment("电子邮件")]
        public string Email { get; set; }
        [MaxLength(100)]
        [ColumnComment("英文名称")]
        public string EnglishName { get; set; }
        [MaxLength(100)]
        [ColumnComment("传真号码")]
        public string FaxNumber { get; set; }
        [MaxLength(100)]
        [ColumnComment("总机号码")]
        public string SwitchBoardPhone { get; set; }
        [MaxLength(100)]
        [ColumnComment("最大可容纳人数")]
        public string SafeFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("荣誉资质")]
        public string Honor { get; set; }
        [MaxLength(432)]
        [ColumnComment("景点简介")]
        public string Introduce { get; set; }
        [MaxLength(100)]
        [ColumnComment("关键词")]
        public string KeyWords { get; set; }
        [MaxLength(500)]
        [ColumnComment("标识图片")]
        public string Logo { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边其它配套设施")]
        public string OtherFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("其它交通说明")]
        public string OtherLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("停车场")]
        public string ParkingLots { get; set; }
        [MaxLength(100)]
        [ColumnComment("图片库")]
        public string Photos { get; set; }
        [MaxLength(100)]
        [ColumnComment("门户网站")]
        public string Portals { get; set; }
        [MaxLength(100)]
        [ColumnComment("邮政编码")]
        public string PostCode { get; set; }
        [MaxLength(100)]
        [ColumnComment("记录变更时间")]
        public string UpdateTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("推荐游览路线")]
        public string RecommendLine { get; set; }
        [MaxLength(100)]
        [ColumnComment("最佳游览季节")]
        public string RecommendTime { get; set; }
        [MaxLength(100)]
        [ColumnComment("配套设施")]
        public string ResortFacilities { get; set; }
        [MaxLength(100)]
        [ColumnComment("所在景区")]
        public string ScenicArea { get; set; }
        [MaxLength(100)]
        [ColumnComment("景点级别")]
        public string ScenicLevel { get; set; }
        [MaxLength(100)]
        [ColumnComment("状态")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("自驾线路")]
        public string SelfDrvingCircuit { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边住宿")]
        public string SurroundomhAccommodation { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边娱乐")]
        public string SurroundingEntertainment { get; set; }
        [MaxLength(100)]
        [ColumnComment("周边购物")]
        public string SurroundingShopping { get; set; }
        [MaxLength(100)]
        [ColumnComment("游览时长")]
        public string TourDuration { get; set; }
        [MaxLength(100)]
        [ColumnComment("景点类型")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微博")]
        public string WeiBoSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("官方微信")]
        public string WeiXinSpace { get; set; }
        [MaxLength(100)]
        [ColumnComment("经纬度")]
        public string XY { get; set; }
        [MaxLength(100)]
        [ColumnComment("星级")]
        public string Star { get; set; }
    }
    /// <summary>
    /// 龙泉宝剑
    /// </summary>
    [EntityMap("sword")]
    public class Sword : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("名称")]
        public string Name { get ; set; }
        [MaxLength(100)]
        [ColumnComment("材质")]
        public string Material { get; set; }
        [MaxLength(100)]
        [ColumnComment("年代")]
        public string Time { get; set; }
        [MaxLength(500)]
        [ColumnComment("产地")]
        public string Origin { get; set; }
        [MaxLength(200)]
        [ColumnComment("图片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("馆藏地")]
        public string CollectionPlace { get; set; }
        [ColumnComment("售价")]
        public decimal? Price { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有者")]
        public string Owner { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有者电话")]
        public string Telephone { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有者微信")]
        public string Wechat { get; set; }
        [MaxLength(100)]
        [ColumnComment("工艺特色")]
        public string Feature { get; set; }
        [MaxLength(100)]
        [ColumnComment("备注")]
        public string Comment { get; set; }

    }
    /// <summary>
    /// 青瓷大师
    /// </summary>
    public class CeladonMaster : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("姓名")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("出生日期")]
        public string Birth { get; set; }
        [MaxLength(200)]
        [ColumnComment("代表作")]
        public string Masterpiece { get; set; }
        [MaxLength(500)]
        [ColumnComment("住址")]
        public string Address { get; set; }
        [MaxLength(100)]
        [ColumnComment("单位")]
        public string Organization { get; set; }
        [MaxLength(200)]
        [ColumnComment("照片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("健康状况")]
        public string Condition { get; set; }
        [MaxLength(500)]
        [ColumnComment("荣誉")]
        public string Honor { get; set; }
        [MaxLength(200)]
        [ColumnComment("技术特点")]
        public string Skill { get; set; }
        [MaxLength(100)]
        [ColumnComment("联系电话")]
        public string Telephone { get; set; }
        [MaxLength(100)]
        [ColumnComment("微信")]
        public string Wechat { get; set; }
        [MaxLength(100)]
        [ColumnComment("坐标")]
        public string XY { get; set; }
        [MaxLength(200)]
        [ColumnComment("备注")]
        public string Comment { get; set; }
    }
    /// <summary>
    ///  青瓷世家
    /// </summary>
    public class CeladonFamly : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("创始人姓名")]
        public string Originator { get; set; }
        [MaxLength(100)]
        [ColumnComment("传承人姓名")]
        public string Inheritor { get; set; }
        [MaxLength(100)]
        [ColumnComment("创始人出生日期")]
        public string Birth { get; set; }
        [MaxLength(200)]
        [ColumnComment("代表作")]
        public string Masterpiece { get; set; }
        [MaxLength(200)]
        [ColumnComment("住址")]
        public string Address { get; set; }
        [MaxLength(200)]
        [ColumnComment("单位")]
        public string Organization { get; set; }
        [MaxLength(200)]
        [ColumnComment("照片")]
        public string Description { get; set; }
        [MaxLength(500)]
        [ColumnComment("历史")]
        public string History { get; set; }
        [MaxLength(200)]
        [ColumnComment("成就")]
        public string Achievement { get; set; }
        [MaxLength(100)]
        [ColumnComment("备注")]
        public string Comment { get; set; }
    }
    /// <summary>
    /// 宝剑大师
    /// </summary>
    public class SwordMaster : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("姓名")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("出生日期")]
        public string Birth { get; set; }
        [MaxLength(200)]
        [ColumnComment("代表作")]
        public string Masterpiece { get; set; }
        [MaxLength(500)]
        [ColumnComment("住址")]
        public string Address { get; set; }
        [MaxLength(100)]
        [ColumnComment("单位")]
        public string Organization { get; set; }
        [MaxLength(200)]
        [ColumnComment("照片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("健康状况")]
        public string Condition { get; set; }
        [MaxLength(500)]
        [ColumnComment("荣誉")]
        public string Honor { get; set; }
        [MaxLength(200)]
        [ColumnComment("技术特点")]
        public string Skill { get; set; }
        [MaxLength(100)]
        [ColumnComment("联系电话")]
        public string Telephone { get; set; }
        [MaxLength(100)]
        [ColumnComment("微信")]
        public string Wechat { get; set; }
        [MaxLength(100)]
        [ColumnComment("坐标")]
        public string XY { get; set; }
        [MaxLength(200)]
        [ColumnComment("备注")]
        public string Comment { get; set; }
    }
    /// <summary>
    /// 非物质文化遗产
    /// </summary>
    public class Culture : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("名称")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("级别")]
        public string Level { get; set; }
        [MaxLength(500)]
        [ColumnComment("概述")]
        public string OverView { get; set; }
        [MaxLength(500)]
        [ColumnComment("起源")]
        public string Origin { get; set; }
        [MaxLength(100)]
        [ColumnComment("种类")]
        public string Type { get; set; }
        [MaxLength(200)]
        [ColumnComment("图片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("分布")]
        public string Distribution { get; set; }
        [MaxLength(100)]
        [ColumnComment("习俗")]
        public string Custom { get; set; }
        [MaxLength(100)]
        [ColumnComment("现状")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("历史沿革")]
        public string History { get; set; }
        [MaxLength(100)]
        [ColumnComment("工艺特色")]
        public string Feature { get; set; }
        [MaxLength(100)]
        [ColumnComment("批准年份")]
        public string Year { get; set; }
    }
    /// <summary>
    /// 青瓷文化
    /// </summary>
    public class CeladonCulture : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("名称")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("品类")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("年代")]
        public string Time { get; set; }
        [MaxLength(500)]
        [ColumnComment("起源")]
        public string Origin { get; set; }
        [MaxLength(100)]
        [ColumnComment("产窑")]
        public string Kiln { get; set; }
        [MaxLength(200)]
        [ColumnComment("图片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("分布")]
        public string Distribution { get; set; }
        [MaxLength(100)]
        [ColumnComment("习俗")]
        public string Custom { get; set; }
        [MaxLength(100)]
        [ColumnComment("现状")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("历史沿革")]
        public string History { get; set; }
        [MaxLength(100)]
        [ColumnComment("发展前景")]
        public string Future { get; set; }
        [MaxLength(100)]
        [ColumnComment("工艺特色")]
        public string Feature { get; set; }
        [MaxLength(100)]
        [ColumnComment("备注")]
        public string Comment { get; set; }
    }
    /// <summary>
    /// 宝剑文化
    /// </summary>
    public class SwordCulture : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("名称")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("品类")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("年代")]
        public string Time { get; set; }
        [MaxLength(500)]
        [ColumnComment("起源")]
        public string Origin { get; set; }
        [MaxLength(200)]
        [ColumnComment("图片")]
        public string Photos { get; set; }
        [MaxLength(500)]
        [ColumnComment("描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("分布")]
        public string Distribution { get; set; }
        [MaxLength(100)]
        [ColumnComment("习俗")]
        public string Custom { get; set; }
        [MaxLength(100)]
        [ColumnComment("现状")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("历史沿革")]
        public string History { get; set; }
        [MaxLength(100)]
        [ColumnComment("发展前景")]
        public string Future { get; set; }
        [MaxLength(100)]
        [ColumnComment("工艺特色")]
        public string Feature { get; set; }
        [MaxLength(100)]
        [ColumnComment("备注")]
        public string Comment { get; set; }
    }
    /// <summary>
    /// 旅游问题咨询
    /// </summary>
    public class TravelConsult : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("咨询人")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("时间")]
        public string Time { get; set; }
        [MaxLength(100)]
        [ColumnComment("咨询类别")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("咨询主题")]
        public string Theme { get; set; }
        [MaxLength(500)]
        [ColumnComment("咨询内容")]
        public string Content { get; set; }
        [MaxLength(100)]
        [ColumnComment("咨询电话")]
        public string Telephone { get; set; }
        [MaxLength(100)]
        [ColumnComment("咨询状态")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("处理部门")]
        public string Department { get; set; }
        [MaxLength(100)]
        [ColumnComment("回复内容")]
        public string Answer { get; set; }
        [MaxLength(100)]
        [ColumnComment("满意程度")]
        public string Satisfaction { get; set; }
    }
    /// <summary>
    /// 投诉
    /// </summary>
    public class Complaint : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("投诉人")]
        public string Name { get; set; }
        [MaxLength(100)]
        [ColumnComment("投诉时间")]
        public string Time { get; set; }
        [MaxLength(100)]
        [ColumnComment("投诉类别")]
        public string Type { get; set; }
        [MaxLength(100)]
        [ColumnComment("投诉主题")]
        public string Theme { get; set; }
        [MaxLength(1000)]
        [ColumnComment("投诉内容")]
        public string Content { get; set; }
        [MaxLength(100)]
        [ColumnComment("被投诉地区")]
        public string Region { get; set; }
        [MaxLength(100)]
        [ColumnComment("投诉电话")]
        public string Telephone { get; set; }
        [MaxLength(100)]
        [ColumnComment("处理部门")]
        public string Department { get; set; }
        [MaxLength(100)]
        [ColumnComment("处理状态")]
        public string Status { get; set; }
        [MaxLength(100)]
        [ColumnComment("满意程度")]
        public string Satisfaction { get; set; }

    }
    /// <summary>
    /// 公交站点
    /// </summary>
    public class BusSite : BaseEntity
    {
        [MaxLength(100)]
        [ColumnComment("站点名称")]
        public string Name { get; set; }
        [MaxLength(500)]
        [ColumnComment("站点描述")]
        public string Description { get; set; }
        [MaxLength(100)]
        [ColumnComment("所有停站公交")]
        public string Bus { get; set; }
        public virtual ICollection<BusStationMap> Maps { get; set; }
    }
        /// <summary>
        /// 旅游路线
        /// </summary>
        public class TravelRoute : BaseEntity
        {
            [MaxLength(100)]
            [ColumnComment("站点名称")]
            public string Name { get; set; }
            [MaxLength(500)]
            [ColumnComment("站点描述")]
            public string Description { get; set; }
            [MaxLength(100)]
            [ColumnComment("所有停站公交")]
            public string Bus { get; set; }
        }
        /// <summary>
        /// 自行车
        /// </summary>
        public class Bicycle : BaseEntity
        {
            [MaxLength(100)]
            [ColumnComment("名称")]
            public string Name { get; set; }
            [MaxLength(100)]
            [ColumnComment("品牌")]
            public string Brand { get; set; }
            [MaxLength(100)]
            [ColumnComment("类型")]
            public string Type { get; set; }
            [MaxLength(100)]
            [ColumnComment("时速")]
            public string Speed { get; set; }
            [MaxLength(100)]
            [ColumnComment("适合人群")]
            public string People { get; set; }
            [MaxLength(100)]
            [ColumnComment("所属公司")]
            public string Company { get; set; }
            [MaxLength(100)]
            [ColumnComment("租赁费用")]
            public string Price { get; set; }
            [MaxLength(100)]
            [ColumnComment("所属站点")]
            public string Site { get; set; }
            [MaxLength(100)]
            [ColumnComment("租赁须知")]
            public string Notes { get; set; }
    }
        /// <summary>
        /// 公交路线
        /// </summary>
        public class BusRoute : BaseEntity
        {
            [MaxLength(100)]
            [ColumnComment("路线名称")]
            public string Name { get; set; }
            [MaxLength(100)]
            [ColumnComment("所属公司")]
            public string Company { get; set; }
            [MaxLength(100)]
            [ColumnComment("票价")]
            public string Price { get; set; }
            [MaxLength(100)]
            [ColumnComment("始发站")]
            public string Start { get; set; }
            [MaxLength(100)]
            [ColumnComment("终点站")]
            public string End { get; set; }
            [ColumnComment("总站数")]
            public decimal? Number { get; set; }
            [MaxLength(100)]
            [ColumnComment("全程长度")]
            public string Length { get; set; }
            [MaxLength(500)]
            [ColumnComment("途经站点")]
            public string Site { get; set; }
            [MaxLength(100)]
            [ColumnComment("发车时间间隔")]
            public string Interval { get; set; }
            [MaxLength(100)]
            [ColumnComment("首班车时间")]
            public string FirstBusTime { get; set; }
            [MaxLength(100)]
            [ColumnComment("末班车时间")]
            public string LastBusTime { get; set; }
            [MaxLength(100)]
            [ColumnComment("停止开行时间")]
            public string StopTime { get; set; }
            public virtual ICollection<BusStationMap> Maps { get; set; }


        }
        /// <summary>
        /// 公共自行车站点
        /// </summary>
        public class BicycleSite : BaseEntity
        {
            [MaxLength(100)]
            [ColumnComment("站点名称")]
            public string Name { get; set; }
            [MaxLength(100)]
            [ColumnComment("建成时间")]
            public string Time { get; set; }
            [MaxLength(100)]
            [ColumnComment("地点")]
            public string Place { get; set; }
            [MaxLength(100)]
            [ColumnComment("自行车数量")]
            public string Number { get; set; }
            [MaxLength(500)]
            [ColumnComment("站点描述")]
            public string Description { get; set; }
            [MaxLength(100)]
            [ColumnComment("所属公司")]
            public string Company { get; set; }
            [MaxLength(200)]
            [ColumnComment("站点坐标")]
            public string XY { get; set; }
    }
    /// <summary>
    /// 公交站点与公交路线的关联
    /// </summary>
        public class BusStationMap
        {
            [Key, Column(Order = 1)]
            public int BusRouteId { get; set; }

            [Key, Column(Order = 2)]
            public int BusSiteId { get; set; }

            public int? Order { get; set; }

            public virtual BusSite BusSite { get; set; }
            public virtual BusRoute BusRoute { get; set; }
        }
  
   
}
