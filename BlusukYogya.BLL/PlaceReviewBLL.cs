using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL
{
    public class PlaceReviewBLL : IPlaceReviewBLL
    {
        private readonly IPlaceReviewData _placeReview;
        private readonly IMapper _mapper;
        public PlaceReviewBLL(IPlaceReviewData placeReviewData, IMapper mapper)
        {
            _mapper = mapper;
            _placeReview = placeReviewData;
        }
        public async Task<Task> Create(CreatePlaceReviewDTO entity)
        {
            var data = _mapper.Map<PlaceReview>(entity);
            await _placeReview.Create(data);
            return Task.CompletedTask;
        }

        public async Task<Task> Delete(int id)
        {
            await _placeReview.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<PlaceReviewDTO> Get(int id)
        {
            var data = await _placeReview.Get(id);
            return _mapper.Map<PlaceReviewDTO>(data);
        }

        public async Task<IEnumerable<PlaceReviewDTO>> GetAll()
        {
            var data = await _placeReview.GetAll();
            return _mapper.Map<IEnumerable<PlaceReviewDTO>>(data);
        }

        public async Task<IEnumerable<GetPlaceReviewWithNameDTO>> getPlaceReviewWithNames(int placeId)
        {
            var data = await _placeReview.getPlaceReviewWithNames(placeId);
            return _mapper.Map<IEnumerable<GetPlaceReviewWithNameDTO>>(data);
        }

        public async Task<IEnumerable<PlaceReviewDTO>> GetReviewByPlaceID(int placeID)
        {
            var data = await _placeReview.GetReviewByPlaceID(placeID);
            return _mapper.Map<IEnumerable<PlaceReviewDTO>>(data);
        }

        public async Task<IEnumerable<PlaceReviewDTO>> GetReviewByUserID(int userID)
        {
            var data = await _placeReview.GetReviewByUserID(userID);
            return _mapper.Map<IEnumerable<PlaceReviewDTO>>(data);
        }

        public Task<Task> Update(CreatePlaceReviewDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
