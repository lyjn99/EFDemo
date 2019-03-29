using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore
{
    public static class TestDbSeed
    {
        public static void InitializeWithSeed(this TestDbContext db)
        {
            if (db.Students.Any())
            {
                return;
            }

            var student = new Student
            {
                Name = "张三",
                Credits = 3
            };
            db.Students.Add(student);
            db.SaveChanges();
            
            var group=new Group()
            {
                GroupName = "第一组"
            };
            db.Groups.Add(group);
            db.SaveChanges();
            student.StudentGroups.Add(new StudentGroup()
            {
                GroupId =group.GroupId,
                StudentId = student.StudentId
            });
            db.SaveChanges();


            var tags = new[]
            {
                new Tag { Text = "Golden" },
                new Tag { Text = "Pineapple" },
                new Tag { Text = "Girlscout" },
                new Tag { Text = "Cookies" }
            };

            var posts = new[]
            {
                new Post { Title = "Best Boutiques on the Eastside" },
                new Post { Title = "Avoiding over-priced Hipster joints" },
                new Post { Title = "Where to buy Mars Bars" }
            };

            db.AddRange(
                new PostTag { Post = posts[0], Tag = tags[0] },
                new PostTag { Post = posts[0], Tag = tags[1] },
                new PostTag { Post = posts[1], Tag = tags[2] },
                new PostTag { Post = posts[1], Tag = tags[3] },
                new PostTag { Post = posts[2], Tag = tags[0] },
                new PostTag { Post = posts[2], Tag = tags[1] },
                new PostTag { Post = posts[2], Tag = tags[2] },
                new PostTag { Post = posts[2], Tag = tags[3] });

            db.SaveChanges();
        }
    }
}
