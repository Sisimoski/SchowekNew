using Schowek.Library.Models;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.DTOs
{
    public class CatalogDTO
    {
        public string? CatalogName { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime OnCreated { get; set; }
        public Colors? CatalogColor { get; set; }
        public List<ItemDTO>? Items { get; set; }
    }
}