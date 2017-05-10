using Lq.Data.Attribute;
using Lq.Data.Model.Entity;
using Lq.Data.Model.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lq.Data.Model
{
    #region 基类

    /// <summary>
    /// 政府部门用户
    /// </summary>
    [Table("agencyuser")]
    public class Agency : User
    {
        [ColumnComment("用户所属部门名称")]
        public string AgencyName { get; set; }
    }

    public class ManageIndex : BaseEntity
    {
        [MaxLength(50)]
        [ColumnComment("指标名")]
        public string Name { get; set; }
        [MaxLength(50)]
        [ColumnComment("指标详细描述")]
        public string Description { get; set; }
        [MaxLength(50)]
        [ColumnComment("指标类型")]
        public string Type { get; set; }
        [ColumnComment("指标级别")]
        public int Level { get; set; }
        [ColumnComment("父指标ID")]
        public int ParentId { get; set; }
        [ColumnComment("指标权重")]
        public decimal IndexWeight { get; set; }
        [ColumnComment("最大值")]
        public decimal? Maximum { get; set; }
        [ColumnComment("最小值")]
        public decimal? Minimum { get; set; }
        [MaxLength(50)]
        [ColumnComment("单位")]
        public string Unit { get; set; }
        [MaxLength(50)]
        [ColumnComment("归一化方法")]
        public string Normalization { get; set; }
        [MaxLength(50)]
        [ColumnComment("指标用途")]
        public string Usage { get; set; }
        [MaxLength(50)]
        [ColumnComment("备注")]
        public string Comment { get; set; }

    }


    public class ManageIndexValue
    {
        [Key, Column(Order = 1)]
        [ColumnComment("指标ID")]
        public int IndexId { get; set; }

        [ColumnComment("指标值")]
        [MaxLength(2000)]
        public string IndexValue { get; set; }
        [MaxLength(50)]
        [ColumnComment("录入时间")]
        public string RecordDate { get; set; }

        [ForeignKey("IndexId")]
        public virtual ManageIndex ManageIndex { get; set; }
    }
    /// <summary>
    /// 整治项目->多个任务
    /// 整治项目->一个整治方案
    /// </summary>


    public class ManageProject : SpatialEntity
    {
        [ColumnComment("项目管理部门Id")]
        [ForeignKey("Agency")]
        public int AgencyId { get; set; }


        [ColumnComment("项目所属行政区Id")]
        [ForeignKey("Region")]
        public int RegionId { get; set; }

        [ColumnComment("项目名称")]
        [MaxLength(500)]
        public string Name { get; set; }

        [ColumnComment("项目描述")]
        [MaxLength(500)]
        public string Description { get; set; }

        [ColumnComment("项目内容")]
        [MaxLength(3000)]
        public string Content { get; set; }

        [MaxLength(500)]
        [ColumnComment("项目规划")]
        public string Plan { get; set; }

        [MaxLength(50)]
        [ColumnComment("项目规划文件路径")]
        public string PlanDocument { get; set; }

        [MaxLength(500)]
        [ColumnComment("项目规划图片路径")]
        public string PlanPics { get; set; }


        [MaxLength(500)]
        [ColumnComment("项目图片")]
        public string Pics { get; set; }

        [MaxLength(500)]
        [ColumnComment("项目视频路径")]
        public string Videos { get; set; }


        [ColumnComment("项目预算")]
        public decimal? Budget { get; set; }


        [ColumnComment("项目花费")]
        public decimal? Cost { get; set; }

        [ColumnComment("项目开始时间")]
        public DateTime StartDate { get; set; }
        [ColumnComment("项目结束时间")]
        public DateTime EndDate { get; set; }
        [ColumnComment("项目验收时间")]
        public DateTime AcceptDate { get; set; }


        [MaxLength(50)]
        [ColumnComment("项目负责人")]
        public string Principal { get; set; }
        [MaxLength(50)]
        [ColumnComment("项目审批人")]
        public string Approver { get; set; }

        [MaxLength(50)]
        [ColumnComment("项目备注")]
        public string Comment { get; set; }

        public virtual Agency Agency { get; set; }


        public virtual Region Region { get; set; }
    }
    #endregion

    #region 美丽乡村建设管理
    /// <summary>
    /// 美丽乡村建设项目管理
    /// </summary>
    public class ConstructionProject : ManageProject
    {
        public virtual ICollection<ConstructionResult> Results { get; set; }
    }

    /// <summary>
    /// 美丽乡村建设成果
    /// </summary>
    public class ConstructionResult:ManageIndexValue
    {
        [Key, Column(Order = 2)]
        [ColumnComment("美丽乡村建设项目id")]
        public int ProjectId { get; set; }
        

        [ForeignKey("ProjectId")]
        public virtual ConstructionProject ConstructionProject { get; set; }
        
    }

    #endregion

    #region 环境综合整治管理
    public class GovernProject : ManageProject
    {
        [ForeignKey("GovernSolution")]
        [ColumnComment("所属整治方案id")]
        public int GovernSolutionId { get; set; }


        public virtual GovernSolution GovernSolution { get; set; }
        public virtual ICollection<GovernTask> Tasks { get; set; }
        public virtual ICollection<GovernResult> Results { get; set; }
    }


    public class GovernTask : SpatialEntity
    {
        [ColumnComment("所属项目id")]
        [ForeignKey("GovernProject")]
        public int GovernProjectId { get; set; }

        [ColumnComment("任务描述")]
        [MaxLength(500)]
        public string Description { get; set; }

        [ColumnComment("任务目标")]
        [MaxLength(500)]
        public string Goal { get; set; }

        [ColumnComment("任务图片")]
        [MaxLength(500)]
        public string Pics { get; set; }

        [ColumnComment("任务预算")]
        public decimal? Cost { get; set; }

        [ColumnComment("任务责任人")]
        [MaxLength(50)]
        public string Principal { get; set; }

        [ColumnComment("任务是否完成")]
        public bool? Finished { get; set; }

        [ColumnComment("任务启动日期")]
        public DateTime StartDate { get; set; }

        [ColumnComment("任务结束日期")]
        public DateTime EndDate { get; set; }


        public virtual GovernProject GovernProject { set; get; }
    }


    public class GovernResult : ManageIndexValue
    {
        [Key, Column(Order = 2)]
        [ColumnComment("整治项目id")]
        public int GovernProjectId { get; set; }


        [ForeignKey("GovernProjectId")]
        public virtual GovernProject GovernProject { get; set; }

    }

    public class GovernPoi : SpatialEntity
    {
        [ColumnComment("Poi 名称")]
        [MaxLength(20)]
        public string Name { get; set; }

        [ColumnComment("Poi 描述")]
        [MaxLength(20)]
        public string Description { get; set; }

        [ColumnComment("Poi 图片路径")]
        [MaxLength(20)]
        public string Pics { get; set; }

    }


    public class GovernSolution : BaseEntity
    {
        [ColumnComment("整治方案名称")]
        [MaxLength(100)]
        public string Name { get; set; }

        [ColumnComment("整治方案所属部门")]
        [MaxLength(50)]
        public string Department { get; set; }

        [ColumnComment("整治方案针对的问题")]
        [MaxLength(500)]
        public string Problem { get; set; }

        [ColumnComment("整治方案具体内容")]
        [MaxLength(500)]
        public string Content { get; set; }

        [ColumnComment("整治方案文件路径")]
        public string File { get; set; }

        [ColumnComment("整治方案创建日期")]
        public DateTime GenerateDate { get; set; }

        [ColumnComment("整治方案上传日期")]
        public DateTime UploadDate { get; set; }

        public virtual ICollection<GovernProject> GeovernProjects { get; set; }
        public virtual ICollection<SolutionComment> Comments { get; set; }
        public virtual ICollection<SolutionQuestion> Questions { get; set; }
    }


    public class SolutionComment : BaseEntity
    {
        [ColumnComment("评论针对的方案id")]
        public int GovernSolutionId { get; set; }

        [ColumnComment("评论人，只针对政府部门开放评论")]
        [ForeignKey("Commentor")]
        public int CommentorId { get; set; }

        [ColumnComment("评论内容")]
        [MaxLength(500)]
        public string Content { get; set; }

        [ColumnComment("评论日期")]
        public DateTime Date { get; set; }

        public virtual GovernSolution Solution { get; set; }
        public virtual Agency Commentor { get; set; }
    }


    public class SolutionQuestion : BaseEntity
    {
        [ColumnComment("问题内容")]
        [MaxLength(100)]
        public string Content { get; set; }

        [ColumnComment("问题涉及的方案id")]
        [ForeignKey("GovernSolution")]
        public int GovernSolutionId { get; set; }

        [ColumnComment("提问人id")]
        [ForeignKey("Questioner")]
        public int QuestionerId { get; set; }

        [ColumnComment("提问时间")]
        public DateTime Date { get; set; }


        public virtual ICollection<SolutionAnswer> Answers { get; set; }
        public virtual GovernSolution GovernSolution { get; set; }
        public virtual Agency Questioner { get; set; }
    }

    public class SolutionAnswer : BaseEntity
    {
        [ColumnComment("问题id")]
        [ForeignKey("Question")]
        public int SolutionQuestionId { get; set; }

        [ColumnComment("回答者id")]
        [ForeignKey("Responser")]
        public int ResponserId { get; set; }
        [ColumnComment("回答内容")]
        [MaxLength(500)]
        public string Content { get; set; }

        [ColumnComment("回答日期")]
        public DateTime Date { get; set; }

        public virtual Agency Responser { get; set; }
        public virtual SolutionQuestion Question { get; set; }
    }
    #endregion
}
