using Schowek.Shared.Core.Models.Enums;

namespace Schowek.Shared.Core.DTOs
{
    public class CreateItemDTO
    {
        public string? Content { get; set; }
        public string? FileName { get; set; }
        public Colors ItemColor { get; set; }
        public int CatalogId { get; set; }
    }
}