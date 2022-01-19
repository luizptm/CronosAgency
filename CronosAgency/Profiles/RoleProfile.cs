using AutoMapper;
using CronosAgency.Models;
using CronosAgency.ViewModels;

namespace CronosAgency.Profiles
{
    public class RoleProfile : Profile
    {
        RoleProfile()
        {
            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();
        }
       
    }
}
