using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EFCore.DataBase;

namespace EFCore
{
    public class TestDbContext : DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CompanyCity> CompanyCities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyCity>()
                .HasKey(x => new {x.CompanyId, x.CityId});
            modelBuilder.Entity<Owner>()
                .HasOne(x => x.Company)
                .WithOne(x => x.Owner)
                .HasForeignKey<Owner>(x => x.CompanyId);

            modelBuilder.Entity<PostTag>()
                .HasKey(t => new {t.PostId, t.TagId});
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);
            

            modelBuilder.Entity<StudentGroup>().HasKey(p => new { p.GroupId, p.StudentId });
            modelBuilder.Entity<Group>().HasData(new Group { GroupId = Guid.Parse("{366EBFBE-DFE6-4E04-97E9-5EDD07CE88C0}"), GroupName = "Math Group" });

            base.OnModelCreating(modelBuilder);
        }
    }


    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public List<PostTag> PostTags { get; set; }=new List<PostTag>();
    }

    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public List<Tag> Tags { get; set; }=new List<Tag>();
    }
    public class Tag
    {
        public int TagId { get; set; }
        public string Text { get; set; }

        public List<PostTag> PostTags { get; set; }=new List<PostTag>();
    }

    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    [Table("Student")]
    public class Student
    {
        public Student()
        {
            StudentGroups = new List<StudentGroup>();
        }

        [Key]
        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
    }

    [Table("Group")]
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }

        public string GroupName { get; set; }
    }

    [Table("StudentGroup")]
    public class StudentGroup
    {
        public Guid StudentId { get; set; }

        public Guid GroupId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }
}
