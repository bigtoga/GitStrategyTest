﻿using System.ComponentModel.DataAnnotations;

namespace Tournaments.Models
{
    public class Sponsor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(50)]
        public string Name { get; set; }

    }
}