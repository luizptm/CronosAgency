using AutoMapper;
using CronosAgency.Models;
using CronosAgency.ViewModels;

namespace CronosAgency.Profiles
{
    public class ServiceProfile : Profile
    {
        ServiceProfile()
        {
            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceViewModel, Service>();
        }
   
    }
}
