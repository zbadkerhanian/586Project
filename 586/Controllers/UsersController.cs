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
    public class UsersController : Controller
    {
        private readonly JobContext _context;

        public UsersController(JobContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            string result;
            List<UserVM> users = _context.Users.Select(u => new UserVM
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                email = u.Email
            }).ToList();

            result = JsonConvert.SerializeObject(users);

            return Ok(result);

        }


    }
}