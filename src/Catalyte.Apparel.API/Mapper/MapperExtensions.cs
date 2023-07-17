using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.Encounter;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.DTOs.PromoCodes;
using Catalyte.Apparel.DTOs.Purchases;

namespace Catalyte.Apparel.API.DTOMappings
{
    public static class MapperExtensions
    {
        public static void ConfigureMappings(this IMapperConfigurationExpression config)
        {
            config.CreateMap<PromoCodeDTO, PromoCode>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        }
        public static IEnumerable<PurchaseResponseDTO> MapPurchasesToPurchaseResponseDTOs(this IMapper mapper, IEnumerable<Purchase> purchases)
        {
            return purchases
                .Select(x => mapper.MapPurchaseToPurchaseResponseDTO(x))
                .ToList();
        }

        /// <summary>
        /// Helper method to build a PurchaseResponseDTO from a Purchase Model.
        /// </summary>
        /// <param name="purchase">The purchase to be persisted.</param>
        /// <returns>A purchase DTO.</returns>
        public static PurchaseResponseDTO MapPurchaseToPurchaseResponseDTO(this IMapper mapper, Purchase purchase)
        {
            return new PurchaseResponseDTO()
            {
                Id = purchase.Id,
                OrderDate = purchase.OrderDate,
                LineItems = mapper.Map<List<LineItemDTO>>(purchase.LineItems),
                DeliveryAddress = mapper.Map<DeliveryAddressDTO>(purchase),
                BillingAddress = mapper.Map<BillingAddressDTO>(purchase),
                CreditCard = mapper.Map<CreditCardDTO>(purchase)
            };
        }

        public static Purchase MapCreatePurchaseDTOToPurchase(this IMapper mapper, PurchaseRequestDTO purchaseDTO)
        {
            var purchase = new Purchase
            {
                OrderDate = DateTime.UtcNow,
            };
            purchase = mapper.Map(purchaseDTO.DeliveryAddress, purchase);
            purchase = mapper.Map(purchaseDTO.BillingAddress, purchase);
            purchase = mapper.Map(purchaseDTO.CreditCard, purchase);
            purchase.LineItems = mapper.Map(purchaseDTO.LineItems, purchase.LineItems);

            return purchase;
        }

        public static PromoCode MapCreatePromoCodeDTOToPromoCode(this IMapper mapper, PromoCodeDTO promoCodeDTO)
        {
            return mapper.Map<PromoCodeDTO, PromoCode>(promoCodeDTO);
        }

        public static Patient MapCreatePatientDTOToPatient(this IMapper mapper, PatientDTO patientDTO)
        {
            return mapper.Map<PatientDTO, Patient>(patientDTO);
        }

        public static Encounter MapCreateEncounterDTOToEncounter(this IMapper mapper, EncounterDTO encounterDTO)
        {
            return mapper.Map<EncounterDTO, Encounter>(encounterDTO);
        }
    }
}
