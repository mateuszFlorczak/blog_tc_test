﻿using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Model
{
    public class Comment
    {
        [Key, Required]
        public long Id { get; set; }
        [Required]
        public long PostId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
