using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schowek.Library.Dtos
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