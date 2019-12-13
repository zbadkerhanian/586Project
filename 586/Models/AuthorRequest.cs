using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _586.Models
{
    public class AuthorRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }
}
