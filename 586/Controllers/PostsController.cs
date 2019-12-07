using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _586.Models;
using _586.ViewModels;
using Newtonsoft.Json;

namespace _586.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]

    public class PostsController : Controller
    {
        private readonly JobContext _context;

        public PostsController(JobContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            string result;
            List<PostVM> posts = _context.Posts.Select(p => new PostVM
            {
                id = p.PostId,
                firstName = p.User.FirstName,
                lastName = p.User.LastName,
                email = p.User.Email,
                body = p.Body
            }).ToList();

            result = JsonConvert.SerializeObject(posts);

            return Ok(result);
            
        }

        [HttpPost]
        public IActionResult Post(PostResponse post)
        {
            User user = _context.Users.Where(u => u.Email == post.email).FirstOrDefault();
            if (user != null)
            {
                Post newPost = new Models.Post
                {
                    UserId = user.UserId,
                    Body = post.body
                };

                _context.Posts.Add(newPost);
                _context.SaveChanges();
                return Ok(post);
            }
            else
                return Ok("Author with email " + post.email + " does not exist.");
            
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {


            //Post postToDelete = _context.Posts.FirstOrDefault(p => p.User.Email == post.email && p.Body == post.body);
            Post postToDelete = _context.Posts.FirstOrDefault(p => p.PostId == id);
            if (postToDelete != null)
            {
                _context.Posts.Remove(postToDelete);
                _context.SaveChanges();
                return Ok("Deleted post " + postToDelete.Body);
            }
            else
                return Ok("The following post cannot be deleted because it does not exist: " + id);

        }
    }
}
