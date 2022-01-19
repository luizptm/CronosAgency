using AutoMapper;
using CronosAgency.Models;
using CronosAgency.ViewModels;

namespace CronosAgency.Profiles
{
    public class UserProfile : Profile
    {
        UserProfile() {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
