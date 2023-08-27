using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIService.Models
{
	public class APIField
	{
		[Key]
		public string Ksuid { get; set; }

		[ForeignKey(nameof(APIDefinition))]
		public string APIDefinitionKsuid { get; set; }

		public string Description { get; set; }

        public string Name { get; set; }

		public APIDefinition APIDefinition { get; set; }

        public APIField()
		{
		}
	}
}

