using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Schowek.Library.Models;
using AutoMapper;
using Schowek.Library.Interfaces;

namespace SchowekAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        // private readonly DataContext data;

        // public CatalogController(DataContext data)
        // {
        //     this.data = data;
        // }

        private readonly IMapper mapper;
        private readonly ICatalogRepository catalogRepository;

        public CatalogController(IMapper mapper, ICatalogRepository catalogRepository)
        {
            this.mapper = mapper;
            this.catalogRepository = catalogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog>>> Get()
        {
            try
            {
                var catalogs = await this.catalogRepository.GetCatalogsAsync();
                // var catalogsResult = this.mapper.Map<CatalogDTO>(catalogs);

                if (catalogs is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(catalogs);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Catalog>> Get(int id)
        {
            try
            {
                var result = await this.catalogRepository.GetCatalogAsync(id);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Catalog>> Create([FromBody] Catalog catalog)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await this.catalogRepository.AddCatalogAsync(catalog);
                if (result is null) return BadRequest();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int catalogId, [FromBody] Catalog catalog)
        {
            // var dbCatalog = await data.Catalogs.FindAsync(request.Id);
            // if (dbCatalog is null)
            //     return BadRequest("Catalog not found.");

            // dbCatalog.CatalogName = request.CatalogName;
            // dbCatalog.Icon = request.Icon;
            // dbCatalog.OnCreated = request.OnCreated;

            // await data.SaveChangesAsync();

            // return Ok(await data.Catalogs.ToListAsync());

            /// TODO !!!!!!!!!!!!Do poprawy!!!!!!!!!!!
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (catalog is null) return BadRequest();
                Catalog? existing = await catalogRepository.GetCatalogAsync(catalogId);
                if (existing is null) return NotFound();

                await catalogRepository.UpdateCatalogAsync(catalogId, catalog);

                return new NoContentResult();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // if (catalog is null) return BadRequest();
            // // var result = await catalogRepository.GetCatalog(catalog);

            // var result = await catalogRepository.UpdateCatalog(catalog);
            // if (result is null) return NotFound();
            // return Ok(result);
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