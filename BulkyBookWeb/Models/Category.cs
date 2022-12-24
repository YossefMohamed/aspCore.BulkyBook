﻿using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

       
        [Required]
        public string Name { get; set; }
        public string DisplayOrder{ get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;

         
    }
}
 