using AutoMapper;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Dtos.BlogDto;
using PetsProject.WebUI.Dtos.ClientLogoDto;
using PetsProject.WebUI.Dtos.FeatureDto;
using PetsProject.WebUI.Dtos.ProductDto;
using PetsProject.WebUI.Dtos.ServiceDto;
using PetsProject.WebUI.Dtos.ShopProcessDto;

namespace PetsProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ResultFeatureDto, Feature>().ReverseMap();

            CreateMap<ResultServiceDto, Feature>().ReverseMap();
            CreateMap<CreateServiceDto, Feature>().ReverseMap();
            CreateMap<UpdateServiceDto, Feature>().ReverseMap();

            CreateMap<ResultProductDto, Feature>().ReverseMap();
            //CreateMap<CreateProductDto, Feature>().ReverseMap();
            //CreateMap<UpdateProductDto, Feature>().ReverseMap();

            CreateMap<ResultShopProcessDto, ShopProcess>().ReverseMap();
            //CreateMap<CreateShopProcessDto, ShopProcess>().ReverseMap();
            //CreateMap<UpdateShopProcessDto, ShopProcess>().ReverseMap();

            CreateMap<ResultBlogDto, Feature>().ReverseMap();
            CreateMap<CreateBlogDto, Feature>().ReverseMap();
            CreateMap<UpdateBlogDto, Feature>().ReverseMap();

            CreateMap<ResultClientLogoDto, Feature>().ReverseMap();
            CreateMap<CreateClientLogoDto, Feature>().ReverseMap();
            CreateMap<UpdateClientLogoDto, Feature>().ReverseMap();
        }
    }
}
