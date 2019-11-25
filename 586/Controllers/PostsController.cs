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
                firstName = p.User.FirstName,
                lastName = p.User.LastName,
                body = p.Body
            }).ToList();

            result = JsonConvert.SerializeObject(posts);

            return Ok(result);
            
        }
    }
}
