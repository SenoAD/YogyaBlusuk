using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Data
{
    public class ImageData : IImageData
    {
        private readonly YogyaBlusukContext _context;
        public ImageData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }
        public async Task Create(Image entity)
        {
            _context.Images.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = _context.Images.FindAsync(id);
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Image> Get(int id)
        {
            return await _context.Images.FindAsync(id);
           
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesByPlaceId(int placeId)
        {
            return await _context.Images.Where(c=>c.PlaceId == placeId).ToListAsync();
        }

        public Task Update(Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
