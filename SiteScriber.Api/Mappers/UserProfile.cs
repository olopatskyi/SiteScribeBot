using AutoMapper;
using SiteScriber.Api.Models;
using SiteScriber.Data.Entities;

namespace SiteScriber.Api.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserGptKeyModel, UserGptKey>();
    }
}