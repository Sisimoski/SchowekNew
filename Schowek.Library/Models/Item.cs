using System.ComponentModel.DataAnnotations;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public long FileSize { get; set; }
        public Colors ItemColor { get; set; }

        [Required]
        public DateTime OnCreated { get; set; }

        public int CatalogId { get; set; }
        public Catalog? Catalog { get; set; }
    }
}