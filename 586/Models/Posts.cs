using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _586.Models
{
    public partial class Posts
    {
        [Key]
        [Column("post_id")]
        [StringLength(50)]
        public string PostId { get; set; }
        [Required]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Required]
        [Column("body")]
        [StringLength(256)]
        public string Body { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Posts))]
        public virtual Users User { get; set; }
    }
}
