using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EFCore.DTOs;
using EFCore.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentManager _studentManager = null;
        private readonly TestDbContext _testDb;

        public StudentController(
            StudentManager studentManager,
            TestDbContext testDb
            )
        {
            _studentManager = studentManager;
            _testDb = testDb;
        }

        // GET api/values
        [HttpPost]
        public IActionResult Post([FromBody]AddStudentDTO dto)
        {
            try
            {
                _studentManager.AddStudent(dto.Name, dto.GroupId);

                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500, new { message = "Unexpected Issue." });
            }
        }

        [HttpGet("getAllStudents")]
        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                var datas= await _testDb.Students.ToListAsync();
                
                return datas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("getGroupsByStudentId/{id}")]
        public async Task<List<Group>> GetStudentsByGroupId(Guid id)
        {
            try
            {
                var datas=await _testDb.StudentGroups.Include(x => x.Group).Where(x => x.StudentId == id).ToListAsync();
                List<Group> groups=new List<Group>();
                foreach (var data in datas)
                {
                    groups.Add(data.Group);
                }

                return groups;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("getAllPosts")]
        public List<Post> GetAllPost()
        {
            var posts = _testDb.Posts
                .Include(x => x.PostTags)
                .ThenInclude(x => x.Tag)
                .ToList();
            foreach (var post in posts)
            {
                Console.WriteLine("Post {post.Title}");
                foreach (var tagResult in post.PostTags.Select(e=>e.Tag))
                {
                    Console.WriteLine("Tag {tagResult.Text}");
                }
            }
            Console.WriteLine();
            return posts;
        }

        /// <summary>
        /// 获取post（每个post都含有下面的tag）
        /// </summary>
        /// <returns></returns>
        [HttpGet("gePosts")]
        public List<PostViewModel> GetPost()
        {
            var posts = _testDb.Posts.ToList();

            var postViewModel = new List<PostViewModel>();
            foreach (var post in posts)
            {
                var postTags = _testDb.PostTags.Where(x => x.PostId == post.PostId).Select(x=>x.TagId).ToList();
                var tags = _testDb.Tags.Where(x => postTags.Contains(x.TagId)).ToList();
                postViewModel.Add(new PostViewModel()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Tags = tags
                });
            }

            var posts2 = postViewModel;
            return postViewModel;
            //return posts.ToList();            //return posts.ToList();
        }


    }
}
