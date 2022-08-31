﻿using System.ComponentModel.DataAnnotations;

namespace SocialMediaAPI.Data.Models
{
    public class Verification
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
    }
}
