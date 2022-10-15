using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using SchowekAPI.Models;

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

        private readonly ICatalogRepository catalogRepository;

        public CatalogController(ICatalogRepository catalogRepository)
        {
            this.catalogRepository = catalogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Catalog>>> Get()
        {
            // try
            // {
            //     if (!data.Catalogs.Any())
            //         return NotFound();
            //     return Ok(await data.Catalogs.ToListAsync());
            // }
            // catch (System.Exception)
            // {
            //     return StatusCode(StatusCodes.Status500InternalServerError);
            // }

            try
            {
                var catalogs = await this.catalogRepository.GetCatalogs();
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
            // var catalog = await data.Catalogs.FindAsync(id);
            // if (catalog is null)
            //     return BadRequest("Catalog not found.");
            // return Ok(catalog);

            try
            {
                var result = await this.catalogRepository.GetCatalog(id);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Catalog>>> AddCatalog(Catalog catalog)
        {
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            // data.Catalogs.Add(catalog);
            // await data.SaveChangesAsync();

            // return Ok(await data.Catalogs.ToListAsync());

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await this.catalogRepository.AddCatalog(catalog);
                if (catalog is null) return BadRequest();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // [HttpPut]
        // public async Task<ActionResult<List<Catalog>>> UpdateCatalog(Catalog request)
        // {
        //     // var dbCatalog = await data.Catalogs.FindAsync(request.Id);
        //     // if (dbCatalog is null)
        //     //     return BadRequest("Catalog not found.");

        //     // dbCatalog.CatalogName = request.CatalogName;
        //     // dbCatalog.Icon = request.Icon;
        //     // dbCatalog.OnCreated = request.OnCreated;

        //     // await data.SaveChangesAsync();

        //     // return Ok(await data.Catalogs.ToListAsync());
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<List<Catalog>>> Delete(int id)
        // {
        //     // var dbCatalog = await data.Catalogs.FindAsync(id);
        //     // if (dbCatalog is null)
        //     //     return BadRequest("Catalog not found.");

        //     // data.Catalogs.Remove(dbCatalog);
        //     // await data.SaveChangesAsync();

        //     // return Ok(await data.Catalogs.ToListAsync());
        // }
    }
}