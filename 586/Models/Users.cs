using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _586.Models
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        [Key]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
