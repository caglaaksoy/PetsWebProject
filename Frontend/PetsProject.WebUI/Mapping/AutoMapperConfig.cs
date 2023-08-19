using AutoMapper;
using PetsProject.EntityLayer.Concrete;
using PetsProject.WebUI.Dtos.BlogDto;
using PetsProject.WebUI.Dtos.ClientLogoDto;
using PetsProject.WebUI.Dtos.ContactDto;
using PetsProject.WebUI.Dtos.FeatureDto;
using PetsProject.WebUI.Dtos.FooterDto;
using PetsProject.WebUI.Dtos.OwnerDto;
using PetsProject.WebUI.Dtos.PetsDto;
using PetsProject.WebUI.Dtos.ProductDto;
using PetsProject.WebUI.Dtos.ServiceDto;
using PetsProject.WebUI.Dtos.ShopProcessDto;
using PetsProject.WebUI.Dtos.TeamDto;

namespace PetsProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {

            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();

            CreateMap<ResultFeatureDto, Feature>().ReverseMap();
            CreateMap<CreateFeatureDto, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDto, Feature>().ReverseMap();

            CreateMap<ResultProductDto, Product>().ReverseMap();

            CreateMap<ResultOwnerDto, Owner>().ReverseMap();


            CreateMap<ResultShopProcessDto, ShopProcess>().ReverseMap();

            CreateMap<ResultBlogDto, Blog>().ReverseMap();
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();

            CreateMap<ResultClientLogoDto, ClientLogo>().ReverseMap();
            CreateMap<CreateClientLogoDto, ClientLogo>().ReverseMap();
            CreateMap<UpdateClientLogoDto, ClientLogo>().ReverseMap();

            CreateMap<ResultFooterDto, Footer>().ReverseMap();
            CreateMap<UpdateFooterDto, Footer>().ReverseMap();

            CreateMap<ResultTeamDto, Team>().ReverseMap();
            CreateMap<CreateTeamDto, Team>().ReverseMap();
            CreateMap<UpdateTeamDto, Team>().ReverseMap();

            CreateMap<CreatePetDto, Pets>().ReverseMap();
            CreateMap<UpdatePetDto, Pets>().ReverseMap();

            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<InboxContactDto, Contact>().ReverseMap();


        }
    }
}
