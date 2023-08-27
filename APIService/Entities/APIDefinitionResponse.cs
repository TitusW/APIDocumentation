using System;
namespace APIService.Entities
{
	public class APIDefinitionResponse
	{
        public string Description { get; set; }

        public string Name { get; set; }

        public List<CreateAPIFieldRequest> APIFields { get; set; }
    }
}

