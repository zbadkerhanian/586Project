using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _586.Models
{
    public partial class Post
    {
        [Key]
        [Column("post_id")]
        public int PostId { get; set; }
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("body")]
        [StringLength(256)]
        public string Body { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Models.User.Posts))]
        public virtual User User { get; set; }
    }
}
