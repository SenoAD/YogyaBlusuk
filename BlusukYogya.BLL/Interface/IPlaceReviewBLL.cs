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
    public interface IPlaceReviewBLL
    {
        Task<Task> Create(CreatePlaceReviewDTO entity);
        Task<PlaceReviewDTO> Get(int id);
        Task<IEnumerable<PlaceReviewDTO>> GetAll();
        Task<Task> Update(CreatePlaceReviewDTO entity);
        Task<Task> Delete(int id);
        Task<IEnumerable<PlaceReviewDTO>> GetReviewByUserID(int userID);
        Task<IEnumerable<PlaceReviewDTO>> GetReviewByPlaceID(int placeID);
        Task<IEnumerable<GetPlaceReviewWithNameDTO>> getPlaceReviewWithNames(int placeId);

    }
}
