using Microsoft.AspNetCore.Mvc;
using Schowek.Library.Models;
using AutoMapper;
using Schowek.Library.Interfaces;
using Schowek.Library.DTOs;

namespace SchowekAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICatalogRepository catalogRepository;

        public CatalogController(IMapper mapper, ICatalogRepository catalogRepository)
        {
            this.mapper = mapper;
            this.catalogRepository = catalogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogDTO>>> Get()
        {
            try
            {
                var catalogs = await this.catalogRepository.GetCatalogsAsync();
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
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogDTO>> Get(int id)
        {
            try
            {
                var catalog = await this.catalogRepository.GetCatalogAsync(id);
                var result = mapper.Map<CatalogDTO>(catalog);

                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (System.Exception)
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
                var result = await this.catalogRepository.AddCatalogAsync(catalog);
                if (result is null) return BadRequest();
                return Created($"/api/catalog/{catalog.Id}", result);
            }
            catch (System.Exception)
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
                Catalog? existing = await catalogRepository.GetCatalogAsync(id);
                if (existing is null) return NotFound();

                var catalog = mapper.Map<CreateCatalogDTO, Catalog>(body, existing);
                await catalogRepository.UpdateCatalogAsync(id, catalog);

                return new NoContentResult();
            }
            catch (System.Exception)
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

                var result = await catalogRepository.GetCatalogAsync(id);
                if (result is null) return NotFound();
                await catalogRepository.DeleteCatalogAsync(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}