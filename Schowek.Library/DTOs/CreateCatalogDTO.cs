using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.DTOs
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