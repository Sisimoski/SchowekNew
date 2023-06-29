using Schowek.Shared.Core.Models.Enums;

namespace Schowek.Shared.Core.DTOs
{
    public class CreateCatalogDTO
    {
        public string? CatalogName { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime OnCreated { get; set; }
        public Colors? CatalogColor { get; set; }
    }
}