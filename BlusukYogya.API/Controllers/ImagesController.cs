using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageBLL _image;
        public ImagesController(IImageBLL imageBLL)
        {
            _image = imageBLL;
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

        [HttpGet("GetImageByName")]
        public IActionResult GetImage(string filename)
        {
            // Combine the wwwroot path with the requested filename
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", filename);

            // Check if the file exists
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound(); // Return 404 if file not found
            }

            // Return the image file
            return PhysicalFile(imagePath, "image/jpeg"); // Adjust content type according to your image type
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageCreateDTO imageCreateDTO)
        {
            if (imageCreateDTO.ImageFilePost == null || imageCreateDTO.ImageFilePost.Length == 0)
                return BadRequest("File is empty");

            if (!IsImage(imageCreateDTO.ImageFilePost))
                return BadRequest("Uploaded file is not an image");

            try
            {
                // Generate a unique identifier for the file
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageCreateDTO.ImageFilePost.FileName);

                // You can save the file to a folder on the server with the unique filename
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageCreateDTO.ImageFilePost.CopyToAsync(fileStream);
                }

                var result = await _image.Create(imageCreateDTO, uniqueFileName);

                // Now you have the unique file name, you can save it to the database or perform any other processing
                // For demonstration purposes, I'm just returning the unique file name
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllImage()
        {
            {
                var result = await _image.GetAll();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetByPlaceId")]
        public async Task<IActionResult> GetByPlaceId(int placeId)
        {
            {
                var result = await _image.GetImagesByPlaceId(placeId);
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
                var result = await _image.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
