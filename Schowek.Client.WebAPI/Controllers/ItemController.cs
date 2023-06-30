using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schowek.Shared.Core.DTOs;
using Schowek.Shared.Core.Interfaces;
using Schowek.Shared.Domain.Models;

namespace Schowek.Client.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IItemService itemService;

        public ItemController(IMapper mapper, IItemService itemService)
        {
            this.mapper = mapper;
            this.itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {
            try
            {
                var items = await itemService.GetItemsAsync();
                var result = mapper.Map<IEnumerable<ItemDTO>>(items);

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
        public async Task<ActionResult<ItemDTO>> Get(int id)
        {
            try
            {
                var item = await itemService.GetItemAsync(id);
                var result = mapper.Map<ItemDTO>(item);

                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Item>> Post([FromBody] CreateItemDTO body)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var item = mapper.Map<Item>(body);
                var result = await itemService.AddItemAsync(item);
                if (result is null) return BadRequest();
                return Created($"/api/item/{item.Id}", result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> Put(int id, [FromBody] CreateItemDTO body)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (body is null) return BadRequest();
                Item? existing = await itemService.GetItemAsync(id);
                if (existing is null) return NotFound();

                var item = mapper.Map<CreateItemDTO, Item>(body, existing);
                await itemService.UpdateItemAsync(id, item);

                return new NoContentResult();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await itemService.GetItemAsync(id);
                if (result is null) return NotFound();
                await itemService.DeleteItemAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}