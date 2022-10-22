using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchowekAPI.Data;

namespace SchowekAPI.Models
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

        // public string UserId { get; set; }

        // [ForeignKey("UserId")]
        // public AspNetUsers AspNetUsers { get; set; }

    }
}
