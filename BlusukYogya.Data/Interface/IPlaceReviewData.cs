using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Models;
using BlusukYogya.Domain;

namespace BlusukYogya.Data.Interface
{
    public interface IPlaceReviewData : ICrudData<PlaceReview>
    {
        Task<IEnumerable<PlaceReview>> GetReviewByUserID (int userID);
        Task<IEnumerable<PlaceReview>> GetReviewByPlaceID(int placeID);
        Task<IEnumerable<GetPlaceReviewWithName>> getPlaceReviewWithNames (int placeId);
    }
}
