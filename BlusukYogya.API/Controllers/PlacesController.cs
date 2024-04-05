using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceBLL _place;
        public PlacesController(IPlaceBLL placeBLL)
        {
            _place = placeBLL;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPlace()
        {
            {
                var result = await _place.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetAllWithRating")]
        public async Task<IActionResult> GetAllPlaceWithRating()
        {
            {
                var result = await _place.GetPlaceWithAvgRatings();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetTop5WithRating")]
        public async Task<IActionResult> GetTop5PlaceWithRating()
        {
            {
                var result = await _place.GetTop5PlacesWithAvgRatings();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("GetByTags")]
        public async Task<IActionResult> GetByTags([FromBody] IEnumerable<int> tagIds)
        {
            if (tagIds == null || !tagIds.Any())
            {
                return BadRequest("Tags cannot be null or empty");
            }

            var result = await _place.GetPlacesByTags(tagIds);
            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            {
                var result = await _place.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            {
                var result = await _place.GetPlaceByCategoryID(categoryId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetBySearch")]
        public async Task<IActionResult> GetBySearch(string search)
        {
            {
                var result = await _place.GetPlaceBySearch(search);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PlaceDTO placeDTO)
        {
            {
                var result = await _place.Update(placeDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        private bool IsImage(IFormFile file)
        {
            // Check if the file content type belongs to common image formats
            if (file.ContentType.ToLower() != "image/jpg" &&
                file.ContentType.ToLower() != "image/jpeg" &&
                file.ContentType.ToLower() != "image/pjpeg" &&
                file.ContentType.ToLower() != "image/gif" &&
                file.ContentType.ToLower() != "image/x-png" &&
                file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            return true;
        }
        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewPlace([FromForm] PlaceCreateDTO placeCreateDTO)
        {
            if (placeCreateDTO.ImageFilePost == null || placeCreateDTO.ImageFilePost.Length == 0)
                return BadRequest("File is empty");

            if (!IsImage(placeCreateDTO.ImageFilePost))
                return BadRequest("Uploaded file is not an image");
            {
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(placeCreateDTO.ImageFilePost.FileName);

                // You can save the file to a folder on the server with the unique filename
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "previews");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await placeCreateDTO.ImageFilePost.CopyToAsync(fileStream);
                }

                var result = await _place.Create(placeCreateDTO, uniqueFileName);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetImageByName")]
        public IActionResult GetImage(string filename)
        {
            // Combine the wwwroot path with the requested filename
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "previews", filename);

            // Check if the file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Return 404 if file not found
            }

            // Return the image file
            return PhysicalFile(imagePath, "image/jpeg"); // Adjust content type according to your image type
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                var result = await _place.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPost("InsertPlaceTag")]
        public async Task<IActionResult> InsertPlaceTag(int placeid, int tagid)
        {
            {
                var result = await _place.AddTagToPlace(placeid,tagid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
