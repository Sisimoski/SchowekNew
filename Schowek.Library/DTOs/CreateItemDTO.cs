using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schowek.Library.Models.Enums;

namespace Schowek.Library.DTOs
{
    public class CreateItemDTO
    {
        public string? Content { get; set; }
        public string? FileName { get; set; }
        public Colors ItemColor { get; set; }
        public int CatalogId { get; set; }
    }
}