using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schowek.Library.Dtos
{
    public class CatalogDTO
    {
        public string? CatalogName { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime OnCreated { get; set; }
    }
}