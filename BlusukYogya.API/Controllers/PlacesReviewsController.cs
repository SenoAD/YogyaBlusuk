using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesReviewsController : ControllerBase
    {
        private readonly IPlaceReviewBLL _placeReview;
        public PlacesReviewsController(IPlaceReviewBLL placeReviewBLL)
        {
            _placeReview = placeReviewBLL;
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewPlaceReview(CreatePlaceReviewDTO createPlaceReviewDTO)
        {
            {
                var result = await _placeReview.Create(createPlaceReviewDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            {
                var result = await _placeReview.GetAll();
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
                var result = await _placeReview.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            {
                var result = await _placeReview.GetReviewByUserID(id);
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
                var result = await _placeReview.GetReviewByPlaceID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetWithNameByPlaceId")]
        public async Task<IActionResult> GetWithNameByPlaceId(int id)
        {
            {
                var result = await _placeReview.getPlaceReviewWithNames(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
