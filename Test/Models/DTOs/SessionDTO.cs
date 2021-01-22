using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.DTOs
{
    public class SessionDTO
    {
        public string Href { get; set; }
        public List<DataDTO> Data { get; set; }
        public List<LinkDTO> Links { get; set; }
    }
}
