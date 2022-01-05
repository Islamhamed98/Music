using System;
using System.ComponentModel.DataAnnotations;

namespace GigsHub.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}