using Core.Dto;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoDto newItemDto)
        {
            try
            {
                var itemDto = await _service.Create(newItemDto);
                return Created("", itemDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocorrred while creating item: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _service.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocorrred while catching items: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TodoDto itemDto)
        {
            try
            {
                var item = await _service.Update(itemDto);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocorrred while updating item: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _service.Delete(id);
                return Ok("Deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error ocorrred while deleting item: {ex.Message}");
            }
        }
    }
}