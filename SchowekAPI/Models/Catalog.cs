using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchowekAPI.Data;

namespace SchowekAPI.Models
{
    public class Catalog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwę.")]
        [MinLength(1, ErrorMessage = "Za krótka nazwa.")]
        public string CatalogName { get; set; }

        public string Icon { get; set; }

        [Required]
        public DateTime OnCreated { get; set; }

        // public ICollection<Item> Items { get; set; }

        // public string UserId { get; set; }

        // [ForeignKey("UserId")]
        // public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
