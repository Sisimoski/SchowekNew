using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schowek.Library.DTOs;
using Schowek.Library.Interfaces;
using Schowek.Library.Models;

namespace SchowekAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public ItemController(IMapper mapper, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> Get()
        {
            try
            {
                var items = await this.itemRepository.GetItemsAsync();
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
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> Get(int id)
        {
            try
            {
                var item = await this.itemRepository.GetItemAsync(id);
                var result = mapper.Map<ItemDTO>(item);

                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (System.Exception)
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
                var result = await this.itemRepository.AddItemAsync(item);
                if (result is null) return BadRequest();
                return Created($"/api/item/{item.Id}", result);
            }
            catch (System.Exception)
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
                Item? existing = await itemRepository.GetItemAsync(id);
                if (existing is null) return NotFound();

                var item = mapper.Map<CreateItemDTO, Item>(body, existing);
                await itemRepository.UpdateItemAsync(id, item);

                return new NoContentResult();
            }
            catch (System.Exception)
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

                var result = await itemRepository.GetItemAsync(id);
                if (result is null) return NotFound();
                await itemRepository.DeleteItemAsync(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}