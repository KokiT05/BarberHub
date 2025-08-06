using BarberHub.Data.Models;
using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Offer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Services.Core
{
    public class OfferService : IOfferService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public OfferService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<AllOffersViewModel>> GetAllOffersAsync(string? barbershopId)
        {
            IEnumerable<AllOffersViewModel> allOffers = new List<AllOffersViewModel>();

            bool isValidId = Guid.TryParse(barbershopId, out Guid validId);
            if (isValidId)
            {
                allOffers = await this.applicationDbContext.Offers
                            .AsNoTracking()
                            .Where(o => o.BarbershopId == validId)
                            .Select(o => new AllOffersViewModel()
                            {
                                Id = o.Id.ToString(),
                                Name = o.Name,
                                Description = o.Description,
                                Price = o.Price
                            })
                            .ToListAsync();
            }

            return allOffers;
        }

        public async Task<EditOfferViewModel?> GetEditDetailsOfferAsync(string? offerId)
        {
            EditOfferViewModel? editOfferViewModel = null;

            bool isValidId = Guid.TryParse(offerId, out Guid validId);
            if (isValidId)
            {
                editOfferViewModel = await this.applicationDbContext.Offers
                                            .AsNoTracking()
                                            .Where(o => o.Id == validId)
                                            .Select(o => new EditOfferViewModel()
                                            {
                                                Id = validId.ToString(),
                                                Name = o.Name,
                                                Description = o.Description,
                                                Price = o.Price
                                            })
                                            .SingleOrDefaultAsync();
            }

            return editOfferViewModel;
        }

        public async Task<bool> EditOfferAsync(EditOfferViewModel? offerModel)
        {
            Offer? offer = await this.applicationDbContext.Offers
                                        .SingleOrDefaultAsync(o => o.Id.ToString() == offerModel.Id);

            if (offer == null)
            {
                return false;
            }

            offer.Name = offerModel.Name;
            offer.Description = offerModel.Description;
            offer.Price = offerModel.Price;

            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }

        public async Task CreateOfferAsync(FormOfferViewModel inputOfferModel, string? barbershopId)
        {
            bool isValidBarbershopId =
                Guid.TryParse(barbershopId, out Guid validBarbershopId);
            if (isValidBarbershopId)
            {
                Offer offer = new Offer()
                {
                    Name = inputOfferModel.Name,
                    Description = inputOfferModel.Description,
                    Price = inputOfferModel.Price,
                    BarbershopId = validBarbershopId,
                };

                await this.applicationDbContext.Offers.AddAsync(offer);
                await this.applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteOfferAsync(string? offerId)
        {
            //bool isValidBarbershopId = Guid.TryParse(barbershopId, out Guid validBarbershopId);
            bool isValidOfferId = Guid.TryParse(offerId, out Guid validOfferId);

            if (/*isValidBarbershopId &&*/ !isValidOfferId)
            {
                return false;
            }

            //Barbershop? barbershop = await this.applicationDbContext
            //                            .Barbershops.SingleOrDefaultAsync(b => b.Id == validBarbershopId);

            Offer? offer = await this.applicationDbContext
                                .Offers.SingleOrDefaultAsync(o => o.Id == validOfferId);

            if (/*barbershop == null &&*/ offer == null)
            {
                return false;
            }

            //barbershop.Offers.Remove(offer);

            this.applicationDbContext.Offers.Remove(offer);
            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }
    }
}
