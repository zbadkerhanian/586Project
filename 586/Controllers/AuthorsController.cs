using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _586.Models;
using _586.ViewModels;
using Newtonsoft.Json;

namespace BarHopApp.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    public class AuthorsController : Controller
    {
        private readonly JobContext _context;

        public AuthorsController(JobContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string result;

            List<AuthorVM> authors = _context.Authors.Select(u => new AuthorVM
            {
                id = u.Id,
                firstName = u.FirstName,
                lastName = u.LastName,
                email = u.Email,
                posts = u.Posts.Select(p => p.Body).ToList()
            }).ToList();

            result = JsonConvert.SerializeObject(authors);

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Post(AuthorRequest author)
        {
            //check if author already exists
            Author auth = _context.Authors.Where(u => u.Email == author.email).FirstOrDefault();
            if (auth == null)
            {
                Author newAuthor = new Author
                {
                    FirstName = author.firstName,
                    LastName = author.lastName,
                    Email = author.email
                };

                _context.Authors.Add(newAuthor);
                _context.SaveChanges();
                return Ok(newAuthor.Id);
            }
            else
                return Ok("Author " + author.email + " already exists.");
            //return Ok("Author blah blah already exists.");


        }

        //public IActionResult Delete(int id)
        //{

        //    //Post postToDelete = _context.Posts.FirstOrDefault(p => p.Author.Email == post.email && p.Body == post.body);
        //    Author authorToDelete = _context.Authors.FirstOrDefault(a => a.Id == id);
        //    if (authorToDelete != null)
        //    {
        //        foreach(Post post in authorToDelete.Posts)
        //        {
        //            _context.Posts.Remove(post);
        //        }
        //        _context.SaveChanges();

        //        _context.Authors.Remove(authorToDelete);
                
        //        _context.SaveChanges();
        //        return Ok("Deleted author " + authorToDelete.Email);
        //    }
        //    else
        //        return Ok("The following author cannot be deleted because it does not exist: " + id);

        //}
    }
}