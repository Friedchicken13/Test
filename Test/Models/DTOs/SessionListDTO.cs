using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.DTOs
{
    public class SessionListDTO
    {
        public string Version { get; set; }
        public List<string> Links { get; set; }
        public List<SessionDTO> Items { get; set; }
        public List<string> Queries { get; set; }
        public TemplateDataDTO Template { get; set; }
    }
}
