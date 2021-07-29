using FilmsAboutBack.Models;
using FilmsAboutBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmsAboutBack.Controllers
{
    [ApiController]
    public class CRUDController<TEntity> : ControllerBase
    {
        private ICRUDService<TEntity> _service;

        public CRUDController(ICRUDService<TEntity> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<TEntity> GetAsync(int id)
        {
            return await _service.GetAsync(id);
        }

        [HttpGet("remove{id}")]
        public async Task RemoveAsync(int id)
        {
            await _service.RemoveAsync(id);
        }

        [HttpPost("add")]
        public virtual async Task CreateAsync(TEntity entity)
        {
            await _service.CreateAsync(entity);
        }

        [HttpPut("update")]
        public async Task UpdateAsync(TEntity entity)
        {
            await _service.UpdateAsync(entity);
        }
    }
}
