using AutoMapper;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Dtos.FeatureDto;

namespace PetsProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
        }
    }
}
