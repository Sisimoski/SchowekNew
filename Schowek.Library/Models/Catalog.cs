using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.Models
{
    public class Catalog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie wprowadzono nazwy. Wprowadź nazwę schowka.")]
        [MinLength(1, ErrorMessage = "Za krótka nazwa.")]
        public string? CatalogName { get; set; }
        public string? Description { get; set; }

        public string? Icon { get; set; }

        [Required]
        public DateTime OnCreated { get; set; }
        public bool IsDeleted { get; set; }
        public Colors? CatalogColor { get; set; }

        public ICollection<Item>? Items { get; set; }

        // public string UserId { get; set; }

        // [ForeignKey("UserId")]
        // public virtual AspNetUsers AspNetUsers { get; set; }
    }
}