using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lq.Identity
{
    public class IdentityDbContext<TUser> :
        IdentityDbContext<TUser, IdentityRole, int, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
        where TUser : IdentityUser
    {
       
        public IdentityDbContext()
            : this("DefaultConnection")
        {
        }

        
        public IdentityDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, true)
        {
        }

        
        public IdentityDbContext(string nameOrConnectionString, bool throwIfV1Schema)
            : base(nameOrConnectionString)
        {
            
        }


        public IdentityDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

       
        public IdentityDbContext(DbCompiledModel model)
            : base(model)
        {
        }

        
        public IdentityDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

       
        public IdentityDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }



    }

    public class IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityDbContext()
            : base("Mysql")
        {
        }

        public IdentityDbContext(string connectionString)
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

            // Needed to ensure subclasses share the same table
            var user = modelBuilder.Entity<IdentityUser>()
                .ToTable("User");
            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));

            // CONSIDER: u.Email is Required if set on options?
            user.Property(u => u.Email).HasMaxLength(256);

            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("UserRole");

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("UserLogin");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");

            var role = modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }

    }
}