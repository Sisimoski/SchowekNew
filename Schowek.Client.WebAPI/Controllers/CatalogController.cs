using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Schowek.Shared.Core.Interfaces;
using Schowek.Shared.Core.DTOs;
using Schowek.Shared.Domain.Models;

namespace Schowek.Client.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICatalogService catalogService;

        public CatalogController(IMapper mapper, ICatalogService catalogService)
        {
            this.mapper = mapper;
            this.catalogService = catalogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> Get()
        {
            try
            {
                var catalogs = await catalogService.GetCatalogsAsync();
                var result = mapper.Map<IEnumerable<CatalogDTO>>(catalogs);

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogDTO>> Get(int id)
        {
            try
            {
                var catalog = await catalogService.GetCatalogAsync(id);
                var result = mapper.Map<CatalogDTO>(catalog);

                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Catalog>> Create([FromBody] CreateCatalogDTO body)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var catalog = mapper.Map<Catalog>(body);
                var result = await catalogService.AddCatalogAsync(catalog);
                if (result is null) return BadRequest();
                return Created($"/api/catalog/{catalog.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Catalog>> Update(int id, [FromBody] CreateCatalogDTO body)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (body is null) return BadRequest();
                Catalog? existing = await catalogService.GetCatalogAsync(id);
                if (existing is null) return NotFound();

                var catalog = mapper.Map<CreateCatalogDTO, Catalog>(body, existing);
                await catalogService.UpdateCatalogAsync(id, catalog);

                return new NoContentResult();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Catalog>> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await catalogService.GetCatalogAsync(id);
                if (result is null) return NotFound();
                await catalogService.DeleteCatalogAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}