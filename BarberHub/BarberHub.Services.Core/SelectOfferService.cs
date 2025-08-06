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
        public async Task GetAllOffersAsync(SelectedOffersViewModel inputSelectOffer, string userId)
        {
            SelectOffer selectOffer = new SelectOffer();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string id in inputSelectOffer.SelectedOfferIds)
            {

                Offer offer = await this.applicationDbContext.Offers
                                        .Where(o => o.Id.ToString() == id)
                                        .SingleAsync();

                if (inputSelectOffer.BarbershopId == null)
                {
                    inputSelectOffer.BarbershopId = offer.BarbershopId.ToString();
                }

                stringBuilder.Append($"{offer.Name}: {offer.Description}, цена: {offer.Price}");
                stringBuilder.AppendLine();

                selectOffer.TotalPrice += offer.Price;
            }

            string result = stringBuilder.ToString().TrimEnd();

            selectOffer.SelectOfferDescription = result;
            selectOffer.UserId = userId;

            await this.applicationDbContext.SelectOffer.AddAsync(selectOffer);
            await this.applicationDbContext.SaveChangesAsync();
        }
    }
}
