using System;
using APIService.Data;
using APIService.Entities;
using APIService.Models;
using Microsoft.EntityFrameworkCore;
using KSUID;

namespace APIService.Repositories
{
	public class APIFieldRepo : IAPIFieldRepo
	{
		private readonly APIServiceContext _context;

		public APIFieldRepo(APIServiceContext context)
		{
			this._context = context;
		}

        public IEnumerable<APIField> BulkCreate(List<CreateAPIFieldRequest> inputs)
        {
            var apiFields = new List<APIField>();
            for (int i=0;i<inputs.Count; i++)
            {
                var apiField = new APIField()
                {
                    APIDefinitionKsuid = inputs[i].APIDefinitionKsuid,
                    Ksuid = Ksuid.Generate().ToString(),
                    Name = inputs[i].Name,
                    Description = inputs[i].Description
                };
                apiFields.Add(apiField);
            }

            _context.APIFields.AddRangeAsync(apiFields);

            return apiFields;
        }

        public async Task<APIField> Create(CreateAPIFieldRequest input)
        {
            var apiField = new APIField()
            {
                Ksuid = Ksuid.Generate().ToString(),
                Name = input.Name,
                Description = input.Description
            };
            await _context.APIFields.AddAsync(apiField);

            return apiField;
        }

        public async Task<APIField?> Get(string ksuid)
        {
            return await _context.APIFields.FindAsync(ksuid);
        }

        public async Task<List<APIField>> GetAll(string? definitionKsuid)
        {
            IQueryable<APIField> query = _context.APIFields;
            if (!string.IsNullOrEmpty(definitionKsuid))
            {
                query = query.Where(field => field.APIDefinitionKsuid == definitionKsuid);
            }

            return await query.ToListAsync();
        }

        public async Task<APIField> Update(string ksuid, UpdateAPIFieldRequest input)
        {
            APIField? current = await _context.APIFields.FindAsync(ksuid);
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

        public void Delete(string ksuid)
        {
            APIField? current = _context.APIFields.Find(ksuid);
            if (current == null)
            {
                throw new Exception("API Definition Not Found");
            }

            _context.APIFields.Remove(current);

            return;

        }
    }
}

