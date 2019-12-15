using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _586.Models
{
    public partial class Post
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("author_id")]
        public int AuthorId { get; set; }
        [Required]
        [Column("body")]
        [StringLength(256)]
        public string Body { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty(nameof(Models.Author.Posts))]
        public virtual Author Author { get; set; }
    }
}
