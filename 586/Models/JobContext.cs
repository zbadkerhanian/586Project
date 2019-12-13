using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _586.Models
{
    public partial class JobContext : DbContext
    {
        public JobContext()
        {
        }

        public JobContext(DbContextOptions<JobContext> options)
            : base(options)
        {
        }

        
        public JobContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JobContext>();
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1IAKBLN\\SQLEXPRESS;Initial Catalog=586;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new JobContext(optionsBuilder.Options);
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Authors_Posts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
