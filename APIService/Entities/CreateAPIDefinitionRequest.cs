using System;
using APIService.Models;

namespace APIService.Entities
{
	public class CreateAPIDefinitionRequest
	{
        public string Description { get; set; }

        public string Name { get; set; }

		public List<CreateAPIFieldRequest> APIFields { get; set; }
	}
}

