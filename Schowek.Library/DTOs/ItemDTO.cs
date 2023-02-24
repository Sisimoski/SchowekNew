using System.ComponentModel.DataAnnotations;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.DTOs
{
    public class ItemDTO
    {
        public string? Content { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public long FileSize { get; set; }
        public Colors ItemColor { get; set; }
        public DateTime OnCreated { get; set; }
    }
}