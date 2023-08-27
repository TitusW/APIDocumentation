using System;
using APIService.Data;
using APIService.Entities;
using APIService.Models;
using Microsoft.EntityFrameworkCore;
using KSUID;

namespace APIService.Repositories
{
	public class APIDefinitionRepo : IAPIDefinitionRepo
	{
		private readonly APIServiceContext _context;

		public APIDefinitionRepo(APIServiceContext context)
		{
			this._context = context;
		}

        public async Task<APIDefinition> Create(CreateAPIDefinitionRequest input)
        {
            var apiDefinition = new APIDefinition()
            {
                Ksuid = Ksuid.Generate().ToString(),
                Name = input.Name,
                Description = input.Description
            };

            await _context.APIDefinitions.AddAsync(apiDefinition);

            return apiDefinition;
        }

        public async Task<APIDefinition?> Get(string ksuid)
        {
            return await _context.APIDefinitions.FindAsync(ksuid);
        }

        public async Task<List<APIDefinition>> GetAll()
        {
            return await _context.APIDefinitions.FromSql($"SELECT * FROM APIDefinitions").ToListAsync();
        }

        public async Task<APIDefinition> Update(string ksuid, UpdateAPIDefinitionRequest input)
        {
            APIDefinition? current = await _context.APIDefinitions.FindAsync(ksuid);
            if (current == null)
            {
                throw new Exception("API Definition Not Found");
            }

            if (!string.IsNullOrEmpty(input.Description))
            {
                current.Description = input.Description;
            }

            if (!string.IsNullOrEmpty(input.Name))
            {
                current.Name = input.Name;
            }

            return current;
        }

        public async Task Delete(string ksuid)
        {
            APIDefinition? current = await _context.APIDefinitions.FindAsync(ksuid);

            if (current == null)
            {
                throw new Exception("API Definition Not Found");
            }

            _context.APIDefinitions.Remove(current);

            return;

        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

