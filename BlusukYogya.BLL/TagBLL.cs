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
    public class TagBLL : ITagBLL
    {
        private readonly ITagData _tag;
        private readonly IMapper _mapper;
        public TagBLL(ITagData tag, IMapper mapper)
        {
            _tag = tag;
            _mapper = mapper;
        }
        public async Task<Task> Create(TagCreateDTO entity)
        {
            var dataDTO = _mapper.Map<Tag>(entity);
            await _tag.Create(dataDTO);
            return Task.CompletedTask;
        }

        public async Task<Task> Delete(int id)
        {
            await _tag.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<TagDTO> Get(int id)
        {
            var data = await _tag.Get(id);
            return _mapper.Map<TagDTO>(data);
        }

        public async Task<IEnumerable<TagDTO>> GetAll()
        {
            var allData = await _tag.GetAll();
            return _mapper.Map<IEnumerable<TagDTO>>(allData);
        }

        public async Task<IEnumerable<TagDTO>> GetTagsByCategoryID(int categoryID)
        {
            var allData = await _tag.GetTagsByCategoryID(categoryID);
            return _mapper.Map<IEnumerable<TagDTO>>(allData);
        }

        public async Task<IEnumerable<TagDTO>> GetTagsByPlaceID(int placeID)
        {
            var allData = await _tag.GetTagsByPlaceID(placeID);
            return _mapper.Map<IEnumerable<TagDTO>>(allData) ;
        }

        public async Task<Task> Update(TagCreateDTO entity)
        {
            var dataDTO = _mapper.Map<Tag>(entity);
            await _tag.Update(dataDTO);
            return Task.CompletedTask;
        }
    }
}
