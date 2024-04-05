using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Data.Models;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleCreateDTO, Role>();

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>();
            //CreateMap<UserUpdateDTO, User>();
            //CreateMap<LoginDTO, User>();

            CreateMap<Place, PlaceDTO>().ReverseMap();
            CreateMap<PlaceCreateDTO, Place>();

            CreateMap<PlaceReview, PlaceReviewDTO>().ReverseMap();
            CreateMap<CreatePlaceReviewDTO, PlaceReview>();

            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<TagCreateDTO, Tag>();

            CreateMap<VacationPlan, VacationPlanDTO>().ReverseMap();
            CreateMap<InsertVacationPlanDTO, VacationPlan>();

            CreateMap<PlanItem, PlanItemDTO>().ReverseMap();
            CreateMap<InsertPlanItemDTO, PlanItem>();

            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<ImageCreateDTO, Image>();

            CreateMap<GetAllPlaceWithRating, GetAllPlaceWithRatingDTO>().ReverseMap();
            CreateMap<GetPlaceReviewWithName, GetPlaceReviewWithNameDTO>().ReverseMap();
        }
    

    }
}
