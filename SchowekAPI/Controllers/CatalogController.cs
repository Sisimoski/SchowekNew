using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SchowekAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly DataContext data;

        public CatalogController(DataContext data)
        {
            this.data = data;
        }

        [HttpGet]
        public async Task<ActionResult<List<Catalog>>> Get()
        {
            return Ok(await data.Catalogs.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Catalog>>> AddCatalog(Catalog catalog)
        {
            data.Catalogs.Add(catalog);
            await data.SaveChangesAsync();

            return Ok(await data.Catalogs.ToListAsync());
        }
    }
}