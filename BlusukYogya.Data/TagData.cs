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
    public class TagData : ITagData
    {
        private readonly YogyaBlusukContext _context;
        public TagData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }

        public async Task Create(Tag entity)
        {
            await _context.Tags.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
        }

        public async Task<Tag> Get(int id)
        {
            var data = await _context.Tags.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            List<Tag> allData = await _context.Tags.ToListAsync();
            return allData;
        }

        public async Task<IEnumerable<Tag>> GetTagsByCategoryID(int categoryID)
        {
            List<Tag> tags = await _context.Tags.Where(c=>c.CategoryId == categoryID).ToListAsync(); 
            return tags;
        }

        public async Task<IEnumerable<Tag>> GetTagsByPlaceID(int placeID)
        {
            List<Tag> tags = await _context.Tags.Include(a => a.Places)
                                    .Where(a => a.Places.Any(b => b.PlaceId == placeID))
                                    .ToListAsync(); ;
            return tags;
        }

        public async Task Update(Tag entity)
        {
            var Tag = await _context.Tags.FindAsync(entity.TagId);
            Tag.TagName = entity.TagName;
            Tag.CategoryId = entity.CategoryId;
            await _context.SaveChangesAsync();
        }
    }
}
