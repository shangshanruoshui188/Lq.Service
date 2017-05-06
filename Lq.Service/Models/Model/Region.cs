using Lq.Service.Models.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lq.Service.Models.Attribute;

namespace Lq.Service.Models
{
    /// <summary>
    /// 行政区用户
    /// </summary>
    [Table("regionuser")]
    public class Regioner : User
    {
        [ColumnComment("用户所属行政区Id")]
        [ForeignKey("Region")]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }

    /// <summary>
    /// 行政区划
    /// </summary>
    public class Region:SpatialEntity
    {
        /// <summary>
        /// 行政编号
        /// </summary>
        [Index(IsUnique =true)]
        [MaxLength(50)]
        [ColumnComment("行政区id")]
        public string Code { get; set; }
        /// <summary>
        /// 行政级别
        /// </summary>
        [MaxLength(50)]
        [ColumnComment("行政级别")]
        public string Level { get; set; }
        /// <summary>
        /// 行政类别额
        /// </summary>
        [MaxLength(50)]
        [ColumnComment("行政类别")]
        public string Category { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [MaxLength(50)]
        [ColumnComment("区域名称")]
        public string Name { get; set; }
        /// <summary>
        /// 父级行政编码
        /// </summary>
        [MaxLength(50)]
        [ColumnComment("父级行政区编码")]
        public string PCode { get; set; }

        [ColumnComment("父级行政区id")]
        public int Pid { get; set; }


        public virtual ICollection<BasicInfo> BasicInfos { get; set; }
        public virtual ICollection<Infrastructure> Infrastructures { get; set; }
        public virtual ICollection<LandUse> LandUses { get; set; }
        public virtual ICollection<PopulationInfo> PopulationInfos { get; set; }
        public virtual ICollection<EconomyInfo> EconomyInfos { get; set; }
        public virtual ICollection<FeatureIndustry> FeatureIndustries { get; set; }
        public virtual ICollection<LandUse> LaborResources { get; set; }
        public virtual ICollection<ConstructionProject> ConstructionProjects { get; set; }
        public virtual ICollection<GovernProject> GovernProjects { get; set; }


    }
    /// <summary>
    /// 基本概况
    /// </summary>
    public class BasicInfo:BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [ColumnComment("平均海拔")]
        public decimal? Altitude { get; set; }
        [ColumnComment("平均气温")]
        public decimal? Temperature { get; set; }
        [ColumnComment("区域面积")]
        public decimal? Area { get; set; }
        [ColumnComment("常用耕地面积")]
        public decimal? ArableArea { get; set; }
        [ColumnComment("人均耕地面积")]
        public decimal? PerArableArea { get; set; }
        [ColumnComment("林地面积")]
        public decimal? ForestArea { get; set; }
        [ColumnComment("经济果林面积")]
        public decimal? FruitArea { get; set; }
        [ColumnComment("养殖水面面积")]
        public decimal? WaterSurfaceArea { get; set; }
        [ColumnComment("园地面积")]
        public decimal? GardenArea { get; set; }

        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }
    /// <summary>
    /// 基础设施
    /// </summary>
    public class Infrastructure : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [ColumnComment("区域名称")]
        public string Name { get; set; }
        [ColumnComment("安装有线电视户数")]
        public decimal? CableTV { get; set; }
        [ColumnComment("自来水使用户数")]
        public decimal? TapWater { get; set; }
        [ColumnComment("垃圾中转站数")]
        public decimal? TrashTransSite { get; set; }
        [ColumnComment("燃气管道通达户数")]
        public decimal? GasPipeline { get; set; }
        [ColumnComment("农用运输车保有量")]
        public decimal? AgriculturalVehicles { get; set; }
        [ColumnComment("保洁员")]
        public decimal? Cleaners { get; set; }
        [ColumnComment("生态墓地数")]
        public decimal? Cemetery { get; set; }
        [ColumnComment("卫生厕所数量")]
        public decimal? Toilets { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }
    /// <summary>
    /// 土地利用
    /// </summary>
    public class LandUse : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [MaxLength(50)]
        [ColumnComment("区域名称")]
        public string Name { get; set; }
        [ColumnComment("耕地保有量")]
        public decimal? ArableLandArea { get; set; }
        [ColumnComment("基本农田面积")]
        public decimal? FarmlandArea { get; set; }
        [ColumnComment("建设用地面积")]
        public decimal? ConstructionLandArea { get; set; }
        [ColumnComment("宅基地面积")]
        public decimal? HomesteadArea { get; set; }
        [ColumnComment("人均建设用地面积")]
        public decimal? PerConstructionLandArea { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }
    /// <summary>
    /// 人口信息
    /// </summary>
    public class PopulationInfo : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [ColumnComment("总人口")]
        public int? Total { get; set; }
        [ColumnComment("总户数")]
        public int? Households { get; set; }
        [ColumnComment("户口原则-农业人口")]
        public int? Agricultural { get; set; }
        [ColumnComment("户口原则-非农业人口")]
        public int? NonAgricultural { get; set; }
        [ColumnComment("性别构成-男")]
        public int? Men { get; set; }
        [ColumnComment("性别构成-女")]
        public int? Women { get; set; }
        [ColumnComment("年龄结构-18岁以下")]
        public int? Under18 { get; set; }
        [ColumnComment("年龄结构-19至40岁")]
        public int? NineToForty { get; set; }
        [ColumnComment("年龄结构-41至65岁")]
        public int? FortyOneToSixtyFive { get; set; }
        [ColumnComment("年龄结构-65岁以上")]
        public int? Over65 { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }

    }
    /// <summary>
    /// 经济信息
    /// </summary>
    public class EconomyInfo : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [ColumnComment("乡镇经济总收入-渔业收入_万元")]
        public decimal? YYSR { get; set; }
        [ColumnComment("乡镇经济总收入-林业收入_万元")]
        public decimal? LYSR { get; set; }
        [ColumnComment("村民收入-村民外出劳务收入_万元")]
        public decimal? WCLWSR { get; set; }
        [ColumnComment("总费用-总额_万元")]
        public decimal? TotalIncome { get; set; }
        [MaxLength(500)]
        [ColumnComment("所属乡村")]
        public string VillageName { get; set; }
        [MaxLength(50)]
        [ColumnComment("所属乡镇")]
        public string TownName { get; set; }
        [ColumnComment("乡镇经济总收入-村组集体经营收入_万元")]
        public decimal? CZJY { get; set; }
        [ColumnComment("乡镇经济总收入-农民家庭经营收入_万元")]
        public decimal? NMJY { get; set; }
        [ColumnComment("乡镇经济总收入-农业收入_万元")]
        public decimal? NYSR { get; set; }
        [ColumnComment("乡镇经济总收入-其他收入中从集体外或转移性收入_万元")]
        public decimal? ZYXSR { get; set; }
        [ColumnComment("乡镇经济总收入-其它收入总额_万元")]
        public decimal? QTSRZE { get; set; }
        [ColumnComment("乡镇经济总收入-服务业收入总额_万元")]
        public decimal? FWYSR { get; set; }
        [ColumnComment("乡镇经济总收入-商饮业收入总额_万元")]
        public decimal? SYYSR { get; set; }
        [ColumnComment("乡镇经济总收入-运输业收入总额_万元")]
        public decimal? YSYSR { get; set; }
        [ColumnComment("乡镇经济总收入-建筑业收入总额_万元")]
        public decimal? JZYSR { get; set; }
        [ColumnComment("乡镇经济总收入-工业收入总额_万元")]
        public decimal? GYSR { get; set; }
        [ColumnComment("农民负担情况-一事一议筹劳_万元")]
        public decimal? YSYYCL { get; set; }
        [ColumnComment("农民负担情况-一事一议筹资_万元")]
        public decimal? YSYYCZ { get; set; }
        [ColumnComment("农民负担情况-是否建立一事一议制度")]
        public decimal? JLYSYY { get; set; }
        [ColumnComment("农民专业合作组织-参加专业合作组织的人数")]
        public decimal? CJZYHZZZRS { get; set; }
        [ColumnComment("农民专业合作组织-已登记注册数")]
        public decimal? YDJZCS { get; set; }
        [ColumnComment("农民专业合作组织-农民专业合作组织数")]
        public decimal? NMZYHZZZS { get; set; }
        [ColumnComment("土地承包管理-土地流转面积_亩")]
        public decimal? TDLZMJ { get; set; }
        [ColumnComment("土地承包管理-土地承包经营的耕地面积_亩")]
        public decimal? TDCBMJ { get; set; }
        [ColumnComment("土地承包管理-土地承包合同份数")]
        public decimal? TDCBHTFS { get; set; }
        [ColumnComment("农村财务管理-是否成立民主理财小组")]
        public decimal? MZLCXZ { get; set; }
        [ColumnComment("农村财务管理-是否进行财务公开")]
        public decimal? CWGK { get; set; }
        [ColumnComment("农村财务管理-管理形式 a.自行管理、b.委托管理")]
        public decimal? GLXS { get; set; }
        [ColumnComment("村集体收入-村集体总收入_万元")]
        public decimal? CJTZSR { get; set; }
        [ColumnComment("村民所得-人均所得_万元")]
        public decimal? CMRJSD { get; set; }
        [ColumnComment("村民所得-总额_万元")]
        public decimal? CMSDZE { get; set; }
        [ColumnComment("村民收入-村民从集体再分配收入_万元")]
        public decimal? JTZFPSR { get; set; }
        [ColumnComment("村民收入-村民从村民专业合作社得到的收入_万元")]
        public decimal? ZYHZSSR { get; set; }
        [ColumnComment("村民收入-村民从乡镇级集体企业得到收入_万元")]
        public decimal? JTQYSR { get; set; }
        [ColumnComment("可分配净收入-农民经营所得_万元")]
        public decimal? NMJYSD { get; set; }
        [ColumnComment("可分配净收入-总额_万元")]
        public decimal? JSRZE { get; set; }
        [ColumnComment("村集体收入-投资收益_万元")]
        public decimal? TZSY { get; set; }
        [ColumnComment("村集体收入-净收入_万元")]
        public decimal? JSR { get; set; }
        [ColumnComment("总费用-生产经营费用_万元")]
        public decimal? SCJY { get; set; }
        [ColumnComment("总费用-管理费_万元")]
        public decimal? GLF { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }
    /// <summary>
    /// 基层组织
    /// </summary>
    public class GrassrootsOrganization : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [ColumnComment("自然村数")]
        public int? NatureVillageNum { get; set; }
        [ColumnComment("党员人数")]
        public int? PartyMembers { get; set; }
        [ColumnComment("党支部数")]
        public int? PartyBranchNum { get; set; }
        [ColumnComment("党小组数")]
        public int? PartyGroupNum { get; set; }
        [ColumnComment("党员人数-少数民族党员数")]
        public int? MinorityPartyMembers { get; set; }
        [ColumnComment("党员人数-男党员数")]
        public int? MalePartyMembers { get; set; }
        [ColumnComment("党员人数-女党员数")]
        public int? FemalePartyMembers { get; set; }
        [ColumnComment("团支部数")]
        public int? LeagueBranchNum { get; set; }
        [ColumnComment("团员人数")]
        public int? LeagueMembers { get; set; }
        [ColumnComment("村干部数")]
        public int? VillageCadres { get; set; }
        [ColumnComment("行政村数")]
        public int? AdministrativeVillageNum { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }

    /// <summary>
    /// 特色产业
    /// </summary>
    public class FeatureIndustry : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [MaxLength(500)]
        [ColumnComment("所属乡村")]
        public string VillageName { get; set; }
        [MaxLength(500)]
        [ColumnComment("所属乡镇")]
        public string TownName { get; set; }
        [ColumnComment("青瓷总产值_万元")]
        public decimal? CeladonOutputValue { get; set; }
        [ColumnComment("青瓷店铺数")]
        public int? CeladonShopNum { get; set; }
        [ColumnComment("竹产品-竹产品总产值_万元")]
        public decimal? BambooOutputValue { get; set; }
        [ColumnComment("竹产品-竹产品农作物面积_亩")]
        public decimal? BambooArea { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }
    /// <summary>
    /// 劳动力资源
    /// </summary>
    public class LaborResource : BaseEntity
    {
        [Key, Column(Order = 1)]
        [ColumnComment("行政区id")]
        public int RegionId { get; set; }
        [Key, Column(Order = 2)]
        [ColumnComment("统计年份")]
        public int Year { get; set; }
        [ColumnComment("劳动力资源总数")]
        public int? LaborsNum { get; set; }
        [ColumnComment("劳动年龄内人数")]
        public int? InWorkingAge { get; set; }
        [ColumnComment("外来从业劳动力")]
        public int? FromOutside { get; set; }
        [ColumnComment("外出劳工劳动力")]
        public int? ToOutside { get; set; }
        [ColumnComment("性别-男")]
        public int? MaleLabors { get; set; }
        [ColumnComment("性别-女")]
        public int? FemaleLabors { get; set; }
        [ColumnComment("部门-农业")]
        public int? Agriculture { get; set; }
        [ColumnComment("部门-林业")]
        public int? Forestry { get; set; }
        [ColumnComment("部门-牧业")]
        public int? Farming { get; set; }
        [ColumnComment("部门-渔业")]
        public int? Fishing { get; set; }
        [ColumnComment("部门-工业")]
        public int? Industry { get; set; }
        [ColumnComment("部门-建筑业")]
        public int? Building { get; set; }
        [ColumnComment("部门-其他行业")]
        public int? Others { get; set; }
        [MaxLength(500)]
        [ColumnComment("所属乡村")]
        public string VillageName { get; set; }
        [MaxLength(50)]
        [ColumnComment("所属乡镇")]
        public string TownName { get; set; }

        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
    }
   
}

