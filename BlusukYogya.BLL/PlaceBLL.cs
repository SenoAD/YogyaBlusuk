using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.BLL.Profiles;
using BlusukYogya.Data;
using AutoMapper;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL
{
    public class PlaceBLL : IPlaceBLL
    {
        private readonly IPlaceData _place;
        private readonly IMapper _mapper;
        public PlaceBLL(IPlaceData Place, IMapper mapper)
        {
            _place = Place;
            _mapper = mapper;
        }

        public async Task<Task> AddTagToPlace(int placeId, int tagId)
        {
            await _place.AddTagToPlace(placeId, tagId);
            return Task.CompletedTask;
        }

        public async Task<Task> Create(PlaceCreateDTO entity, string previewUrl)
        {
            var dataDTO = _mapper.Map<Place>(entity);
            dataDTO.Preview = previewUrl;
            await _place.Create(dataDTO);
            return Task.CompletedTask;
        }

        public async Task<Task> Delete(int id)
        {
            await _place.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<PlaceDTO> Get(int id)
        {
            var data = await _place.Get(id);
            return _mapper.Map<PlaceDTO>(data);
        }

        public async Task<IEnumerable<PlaceDTO>> GetAll()
        {
            var allData = await _place.GetAll();
            return _mapper.Map<IEnumerable<PlaceDTO>>(allData);
        }

        public async Task<IEnumerable<PlaceDTO>> GetPlaceByCategoryID(int categoryId)
        {
            var allData = await _place.GetPlaceByCategoryID(categoryId);
            return _mapper.Map<IEnumerable<PlaceDTO>>(allData);
        }

        public async Task<IEnumerable<PlaceDTO>> GetPlaceBySearch(string search)
        {
            var allData = await _place.GetPlaceBySearch(search);
            return _mapper.Map<IEnumerable<PlaceDTO>>(allData); 
        }

        public async Task<IEnumerable<PlaceDTO>> GetPlacesByTags(IEnumerable<int> tagIds)
        {
            var allData = await _place.GetPlacesByTags(tagIds);
            return _mapper.Map<IEnumerable<PlaceDTO>>(allData);
        }

        public async Task<IEnumerable<GetAllPlaceWithRatingDTO>> GetPlaceWithAvgRatings()
        {
            var allData = await _place.GetPlaceWithAvgRatings();
            return _mapper.Map<IEnumerable<GetAllPlaceWithRatingDTO>>(allData);
        }

        public async Task<IEnumerable<GetAllPlaceWithRatingDTO>> GetTop5PlacesWithAvgRatings()
        {
            var allData = await _place.GetTop5PlacesWithAvgRatings();
            return _mapper.Map<IEnumerable<GetAllPlaceWithRatingDTO>>(allData);
        }

        public async Task<Task> Update(PlaceDTO entity)
        {
            var dataDTO = _mapper.Map<Place>(entity);
            await _place.Update(dataDTO);
            return Task.CompletedTask;
        }
    }
}
