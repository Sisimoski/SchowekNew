using System.ComponentModel.DataAnnotations;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.DTOs
{
    public class CatalogDTO
    {
        [Required(ErrorMessage = "Nie wprowadzono nazwy. Wprowadź nazwę schowka.")]
        [MinLength(1, ErrorMessage = "Za krótka nazwa.")]
        public string? CatalogName { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime OnCreated { get; set; }
        public Colors? CatalogColor { get; set; }
    }
}