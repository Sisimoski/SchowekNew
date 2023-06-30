using Schowek.Shared.Domain.Models.Enums;

namespace Schowek.Shared.Core.DTOs
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
        public int CatalogId { get; set; }
    }
}