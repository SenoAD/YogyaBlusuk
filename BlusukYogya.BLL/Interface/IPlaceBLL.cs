using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Data.Models;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL.Interface
{
    public interface IPlaceBLL 
    {
        Task<Task> Create(PlaceCreateDTO entity, String previewUrl);
        Task<PlaceDTO> Get(int id);
        Task<IEnumerable<PlaceDTO>> GetAll();
        Task<Task> Update(PlaceDTO entity);
        Task<Task> Delete(int id);
        Task<Task> AddTagToPlace(int placeId, int tagId);
        Task<IEnumerable<PlaceDTO>> GetPlacesByTags(IEnumerable<int> tagIds);
        Task<IEnumerable<PlaceDTO>> GetPlaceBySearch(string search);
        Task<IEnumerable<PlaceDTO>> GetPlaceByCategoryID(int categoryId);
        Task<IEnumerable<GetAllPlaceWithRatingDTO>> GetPlaceWithAvgRatings();
        Task<IEnumerable<GetAllPlaceWithRatingDTO>> GetTop5PlacesWithAvgRatings();
    }
}
