using Lq.Data.Model;
using Lq.Data.Model.Security;
using MySql.Data.Entity;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq.Expressions;

namespace Lq.Store.DbContext
{
    /// <summary>
    /// EF数据映射与访问类
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DbContext: System.Data.Entity.DbContext,IDbContext
    {
        public DbContext() : base("Mysql")
        {
        }
        public DbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            SetIndexAnnotation<Region>(modelBuilder, r => r.Code, "Code",true);
            SetIndexAnnotation<Role>(modelBuilder, r => r.Name, "Name",true);
            SetIndexAnnotation<User>(modelBuilder, r => r.Name, "Name",true);
            SetIndexAnnotation<User>(modelBuilder, r => r.Email, "Name");
            SetIndexAnnotation<User>(modelBuilder, r => r.Phone, "Name");



        }

        /// <summary>
        /// 设置唯一值索引
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="builder"></param>
        /// <param name="expression">用于指定要设置索引的属性表达式</param>
        /// <param name="propertyName">属性名，用以生成索引名称</param>
        private void SetIndexAnnotation<TEntity>(DbModelBuilder builder,Expression<Func<TEntity,string>> expression,string propertyName,bool isRequired=false) 
            where TEntity:class 
        {
            var config=builder.Entity<TEntity>()
                .Property(expression)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute($"{typeof(TEntity).Name}{propertyName}Index")));
            if (isRequired)
                config.IsRequired();
                
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
    }
}
