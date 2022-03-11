using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
        public class Seed
        {
            public long Id { get; set; }
            public string Type { get; set; }
            public decimal Level { get; set; }
            public string Status { get; set; }
            public DateTime PlantingDate { get; set; }
       }
}
