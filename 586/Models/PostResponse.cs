using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _586.Models
{
    public class PostResponse
    {
        public string email { get; set; }
        [StringLength(256)]
        public string body { get; set; }
    }
}
