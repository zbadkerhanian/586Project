using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _586.Models;
using _586.ViewModels;
using Newtonsoft.Json;

using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace _586.Controllers
{
    [Authorize]
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
            //var authToken = Request.Headers["Authorization"];

            //var principal = HttpContext.User.Identity as ClaimsIdentity;

            //var login = principal.Claims
            //    .SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
            //    ?.Value;


            string result;
            List<PostVM> posts = _context.Posts.Select(p => new PostVM
            {
                id = p.Id,
                firstName = p.Author.FirstName,
                lastName = p.Author.LastName,
                email = p.Author.Email,
                body = p.Body
            }).ToList();

            result = JsonConvert.SerializeObject(posts);

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post(PostRequest post)
        {
            Author author = _context.Authors.Where(u => u.Email == post.email).FirstOrDefault();
            if (author != null)
            {
                Post newPost = new Post
                {
                    AuthorId = author.Id,
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

            Post postToDelete = _context.Posts.FirstOrDefault(p => p.Id == id);
            if (postToDelete != null)
            {
                _context.Posts.Remove(postToDelete);
                _context.SaveChanges();
                return Ok(postToDelete);
            }
            else
                return Ok("The following post cannot be deleted because it does not exist: " + id);

        }
    }
}
