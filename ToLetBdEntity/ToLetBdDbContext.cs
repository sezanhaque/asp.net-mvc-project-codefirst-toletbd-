using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLetBdEntity
{
    public class ToLetBdDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<User>().HasMany(u => u.Comments).WithRequired(c => c.User)
                   .HasForeignKey(u => u.UserId).WillCascadeOnDelete(value: false);

            builder.Entity<Post>().HasMany(u => u.Comments).WithRequired(c => c.Post)
                   .HasForeignKey(u => u.PostId).WillCascadeOnDelete(value: false);

            // Add other non-cascading FK declarations here

            base.OnModelCreating(builder);
        }

    }
}
