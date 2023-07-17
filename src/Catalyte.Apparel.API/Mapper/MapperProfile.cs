using AutoMapper;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.DTOs.Encounter;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.DTOs.PromoCodes;
using Catalyte.Apparel.DTOs.Purchases;

namespace Catalyte.Apparel.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<PurchaseRequestDTO, Purchase>();

            CreateMap<Purchase, PurchaseResponseDTO>();
            CreateMap<Purchase, DeliveryAddressDTO>().ReverseMap();
            CreateMap<Purchase, CreditCardDTO>().ReverseMap();
            CreateMap<Purchase, BillingAddressDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.BillingEmail))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.BillingPhone))
                .ReverseMap();

            CreateMap<LineItem, LineItemDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<PromoCode, PromoCodeDTO>().ReverseMap();

            CreateMap<Review, ReviewDTO>().ReverseMap();

            CreateMap<Encounter, EncounterDTO>().ReverseMap();
        }

    }
}
