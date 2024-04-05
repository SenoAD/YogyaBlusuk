using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Interface;
using BlusukYogya.Data.Models;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Data
{
    public class PlaceData : IPlaceData
    {
        private readonly YogyaBlusukContext _context;
        public PlaceData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }

        public async Task<Task> AddTagToPlace(int placeId, int tagId)
        {
            try
            {
                var tag = await _context.Tags.SingleOrDefaultAsync(c => c.TagId == tagId);
                var place = await _context.Places.FindAsync(placeId);

          
                if (tag.CategoryId == place.CategoryType)
                {
                    place.Tags.Add(tag);
                    await _context.SaveChangesAsync();
                    return Task.CompletedTask;
                }else
                {
                    throw new ArgumentException("CategoryID tidak sama");
                }
                
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Penambahan tidak Berhasil");
            }
        }

        public async Task Create(Place entity)
        {
            await _context.Places.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var place = await _context.Places.FindAsync(id);
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
        }

        public async Task<Place> Get(int id)
        {
            var data = await _context.Places.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<Place>> GetAll()
        {
            List<Place> allData = await _context.Places.ToListAsync();
            return allData;
        }

        public async Task<IEnumerable<Place>> GetPlaceByCategoryID(int categoryId)
        {
            List<Place> allData = await _context.Places.Where(c => c.CategoryType == categoryId).ToListAsync();
            return allData;
        }

        public async Task<IEnumerable<Place>> GetPlaceBySearch(string search)
        {
            List<Place> allData = await _context.Places.Where(c=> c.Name.Contains(search)).ToListAsync();
            return allData; 
        }

        public async Task<IEnumerable<Place>> GetPlacesByTags(IEnumerable<int> tagIds )
        {
            List<Place> allData = await _context.Places
    .Where(place => tagIds.All(tagId => place.Tags.Any(tag => tag.TagId == tagId)))
    .ToListAsync();

            return allData;
        }

        public async Task<IEnumerable<GetAllPlaceWithRating>> GetPlaceWithAvgRatings()
        {
            var allPlaceWithRating = new List<GetAllPlaceWithRating>();
            var allPlace = await _context.Places.ToListAsync();
            var averageRatings = await _context.PlaceReviews
                                .GroupBy(pr => pr.PlaceId)
                                .Select(g => new
                                {
                                    PlaceId = g.Key,
                                    AverageRating = g.Average(pr => pr.Rating)
                                })
                                .ToListAsync();
            foreach ( var item in allPlace )
            {
                var averageRating = averageRatings.FirstOrDefault(ar => ar.PlaceId == item.PlaceId)?.AverageRating ?? 0;
                var placeReview = new GetAllPlaceWithRating
                {
                    PlaceID = item.PlaceId,
                    Name = item.Name,
                    AveragePrice = item.AveragePrice,
                    CategoryType = item.CategoryType,
                    Description = item.Description,
                    Location = item.Location,
                    AverageRating = averageRating,
                    Preview = item.Preview,
                };
                allPlaceWithRating.Add(placeReview);
            }
            return allPlaceWithRating;
        }

        public async Task<IEnumerable<GetAllPlaceWithRating>> GetTop5PlacesWithAvgRatings()
        {
            var top5PlacesWithRating = new List<GetAllPlaceWithRating>();

            var averageRatings = await _context.PlaceReviews
                .GroupBy(pr => pr.PlaceId)
                .Select(g => new
                {
                    PlaceId = g.Key,
                    AverageRating = g.Average(pr => pr.Rating)
                })
                .OrderByDescending(ar => ar.AverageRating)
                .Take(5)
                .ToListAsync();

            var top5PlaceIds = averageRatings.Select(ar => ar.PlaceId).ToList();

            var top5Places = await _context.Places
                .Where(p => top5PlaceIds.Contains(p.PlaceId))
                .ToListAsync();

            foreach (var item in top5Places)
            {
                var averageRating = averageRatings.FirstOrDefault(ar => ar.PlaceId == item.PlaceId)?.AverageRating ?? 0;

                var placeReview = new GetAllPlaceWithRating
                {
                    PlaceID = item.PlaceId,
                    Name = item.Name,
                    AveragePrice = item.AveragePrice,
                    CategoryType = item.CategoryType,
                    Description = item.Description,
                    Location = item.Location,
                    AverageRating = averageRating,
                    Preview = item.Preview,
                };

                top5PlacesWithRating.Add(placeReview);
            }

            return top5PlacesWithRating;
        }


        public async Task Update(Place entity)
        {
            var Place = await _context.Places.FindAsync(entity.PlaceId);
            Place.Name = entity.Name;
            Place.Description = entity.Description;
            Place.Location = entity.Location;
            Place.AveragePrice = entity.AveragePrice;
            await _context.SaveChangesAsync();
        }
    }
}
