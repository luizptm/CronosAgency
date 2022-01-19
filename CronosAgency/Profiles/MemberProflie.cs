using AutoMapper;
using CronosAgency.Models;
using CronosAgency.ViewModels;

namespace CronosAgency.Profiles
{
    public class MemberProflie : Profile
    {
        MemberProflie()
        {
            CreateMap<Member, MemberViewModel>();
            CreateMap<MemberViewModel, Member>();
        }
    }
}
