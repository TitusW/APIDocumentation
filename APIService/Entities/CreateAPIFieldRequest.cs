using System;
namespace APIService.Entities
{
	public class CreateAPIFieldRequest
	{
		public string? APIDefinitionKsuid { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
	}
}

