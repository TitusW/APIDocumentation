using System;
using System.ComponentModel.DataAnnotations;

namespace APIService.Models
{
    public class APIDefinition
    {
        [Key]
        public string Ksuid { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public IEnumerable<APIField> APIFields { get; set; }

        public APIDefinition()
        {
        }
    }
}

