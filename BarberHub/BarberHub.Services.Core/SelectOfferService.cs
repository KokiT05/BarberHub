using BarberHub.Data.Models;
using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.SelectOffer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Services.Core
{
    public class SelectOfferService : ISelectOfferService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public SelectOfferService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

		public async Task AddSelectOfferAsync(SelectedOffersViewModel inputSelectOfferModel, string userId)
		{

            Offer? offer = null;
            UserOffer? userOffer = null;

            StringBuilder stringBuilder = new StringBuilder();

            string offerTitle = string.Empty;
            string offerDescription = string.Empty;
            decimal offerPrice = 0;

			foreach (string id in inputSelectOfferModel.SelectedOfferIds)
            {
                if (Guid.TryParse(id, out Guid validOfferId))
                {
                    offer = await this.applicationDbContext
                                                .Offers
                                                .Where(o => o.Id == validOfferId)
                                                .SingleOrDefaultAsync();

                    if (offer != null)
                    {
						offerTitle = await this.applicationDbContext
						                        .Offers
						                        .Select(o => o.Name)
						                        .FirstAsync();

                        offerDescription = await this.applicationDbContext
                                                .Offers
                                                .Select(o => o.Description)
                                                .FirstAsync();

                        offerPrice = await this.applicationDbContext
                                                .Offers
                                                .Select(o => o.Price)
                                                .FirstAsync();

                        stringBuilder
                        .AppendLine
                        ($"Name: {offerTitle}, Description: {offerDescription}, Price: {offerPrice}");

						userOffer = new UserOffer()
                        {
                            UserId = userId,
                            OfferId = validOfferId,
                            Description = stringBuilder.ToString(),
                        };

                        await this.applicationDbContext.UserOffers.AddAsync(userOffer);
                        await this.applicationDbContext.SaveChangesAsync();
                    }

				}
            }
		}

		public async Task GetAllSelectOffersAsync(SelectedOffersViewModel inputSelectOffer, string userId)
        {


            //UserOffer selectOffer = new UserOffer();

            //StringBuilder stringBuilder = new StringBuilder();

            //foreach (string id in inputSelectOffer.SelectedOfferIds)
            //{

            //    Offer offer = await this.applicationDbContext.Offers
            //                            .Where(o => o.Id.ToString() == id)
            //                            .SingleAsync();

            //    if (inputSelectOffer.BarbershopId == null)
            //    {
            //        inputSelectOffer.BarbershopId = offer.BarbershopId.ToString();
            //    }

            //    stringBuilder.Append($"{offer.Name}: {offer.Description}, цена: {offer.Price}");
            //    stringBuilder.AppendLine();

            //    selectOffer.TotalPrice += offer.Price;
            //}

            //string result = stringBuilder.ToString().TrimEnd();

            //selectOffer.Description = result;
            //selectOffer.UserId = userId;

            //await this.applicationDbContext.SelectOffer.AddAsync(selectOffer);
            //await this.applicationDbContext.SaveChangesAsync();
        }
    }
}
