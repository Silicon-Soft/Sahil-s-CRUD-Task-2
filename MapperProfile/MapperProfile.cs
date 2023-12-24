using AutoMapper;
using Task2.Models;
using Task2.ViewModel;

namespace Task2.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, GetViewModel>();
            CreateMap<Employee, EditViewModel>();
            CreateMap<EditViewModel, Employee>();
            CreateMap<Employee, ReadViewModel>();
            CreateMap<Employee, CreateViewModel>();
            CreateMap<CreateViewModel, Employee>();
            CreateMap<Employee, DeleteViewModel>();
            CreateMap<DeleteViewModel, Employee>();


        }
    }
}
