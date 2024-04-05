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
    public class ImageBLL : IImageBLL
    {
        private readonly IImageData _image;
        private readonly IMapper _mapper;
        public ImageBLL(IImageData imageData, IMapper mapper)
        {
            _image = imageData;
            _mapper = mapper;
        }
        public async Task<Task> Create(ImageCreateDTO entity, string imageUrl)
        {
            var data = _mapper.Map<Image>(entity);
            data.ImageUrl = imageUrl;
            await _image.Create(data);
            return Task.CompletedTask;
        }

        public async Task<Task> Delete(int id)
        {
            await _image.Delete(id);
            return Task.CompletedTask;
        }

        public async Task<ImageDTO> Get(int id)
        {
            var data =await _image.Get(id);
            return _mapper.Map<ImageDTO>(data);
        }

        public async Task<IEnumerable<ImageDTO>> GetAll()
        {
            var data = await _image.GetAll();
            return _mapper.Map<IEnumerable<ImageDTO>>(data);
        }

        public async Task<IEnumerable<ImageDTO>> GetImagesByPlaceId(int placeId)
        {
            var data = await _image.GetImagesByPlaceId(placeId);
            return _mapper.Map<IEnumerable<ImageDTO>>(data);
        }

        public Task<Task> Update(ImageCreateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
