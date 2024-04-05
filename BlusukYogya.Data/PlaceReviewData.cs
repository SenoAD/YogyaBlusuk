using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Interface;
using BlusukYogya.Data.Models;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Data
{
    public class PlaceReviewData : IPlaceReviewData
    {
        private readonly YogyaBlusukContext _context;
        public PlaceReviewData(YogyaBlusukContext yogyaBlusukContext)
        {
             _context = yogyaBlusukContext;
        }
        public async Task Create(PlaceReview entity)
        {
          _context.PlaceReviews.Add(entity);
          await _context.SaveChangesAsync();    
        }

        public async Task Delete(int id)
        {
            var data = await _context.PlaceReviews.FindAsync(id);
            _context.PlaceReviews.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<PlaceReview> Get(int id)
        {
            var data = await _context.PlaceReviews.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<PlaceReview>> GetAll()
        {
            var allData = await _context.PlaceReviews.ToListAsync();
            return allData;
        }

        public async Task<IEnumerable<GetPlaceReviewWithName>> getPlaceReviewWithNames(int placeId)
        {
            var allQueryData = await(from review in _context.PlaceReviews
                                join user in _context.Users on review.UserId equals user.UserId
                                where review.PlaceId == placeId
                                select new
                                {
                                    ReviewId = review.ReviewId,
                                    PlaceId = placeId,
                                    UserId = user.UserId,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                    ReviewText = review.ReviewText,
                                    Rating = review.Rating,
                                    Date = review.Date,
                                    
                                    // Add more properties from the User table as needed
                                }).ToListAsync();
            List<GetPlaceReviewWithName> allData = new List<GetPlaceReviewWithName>();
            foreach (var review in allQueryData)
            {
                GetPlaceReviewWithName data = new GetPlaceReviewWithName 
                { 
                    Date = review.Date,
                    ReviewId = review.ReviewId,
                    PlaceId = review.PlaceId,
                    FirstName = review.FirstName,
                    LastName = review.LastName,
                    ReviewText = review.ReviewText,
                    Rating= review.Rating,
                    UserId= review.UserId,
                };
                allData.Add(data);
            }
            return allData;

        }

        public async Task<IEnumerable<PlaceReview>> GetReviewByPlaceID(int placeID)
        {
            var allData = await _context.PlaceReviews.Where(c=>c.PlaceId == placeID).ToListAsync();
            return allData;
        }

        public async Task<IEnumerable<PlaceReview>> GetReviewByUserID(int userID)
        {
            var allData = await _context.PlaceReviews.Where(c => c.UserId == userID).ToListAsync();
            return allData;
        }

        public Task Update(PlaceReview entity)
        {
            throw new NotImplementedException();
        }
    }
}
