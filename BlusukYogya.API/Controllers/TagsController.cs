using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagBLL _tag;
        public TagsController(ITagBLL tagBLL)
        {
            _tag = tagBLL;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTag()
        {
            {
                var result = await _tag.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            {
                var result = await _tag.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryId(int id)
        {
            {
                var result = await _tag.GetTagsByCategoryID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetByPlaceId")]
        public async Task<IActionResult> GetByPlaceId(int id)
        {
            {
                var result = await _tag.GetTagsByPlaceID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TagCreateDTO TagDTO)
        {
            {
                var result = await _tag.Update(TagDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewTag(TagCreateDTO TagCreateDTO)
        {
            {
                var result = await _tag.Create(TagCreateDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                var result = await _tag.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
