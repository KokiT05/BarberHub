using BarberHub.Data.Models;
using BarberHub.Services.Core.Interfaces;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Offer;
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

		public async Task AddSelectOfferAsync(IEnumerable<string> inputModelIds, string barbershopId, string userId)
		{
            Offer? offer = null;
            UserOffer? userOffer = null;

			foreach (string id in inputModelIds)
            {
                if (Guid.TryParse(id, out Guid validOfferId))
                {
                    offer = await this.applicationDbContext
                                                .Offers
                                                .Where(o => o.Id == validOfferId)
                                                .SingleOrDefaultAsync();

                    if (offer != null)
                    {
						userOffer = new UserOffer()
                        {
                            UserId = userId,
                            OfferId = validOfferId,
							//SelectedOn = inputModel.SelectedOn
                        };

                        await this.applicationDbContext.UserOffers.AddAsync(userOffer);
                        await this.applicationDbContext.SaveChangesAsync();
                    }

				}
            }
		}

		public async Task<BarbershopSelectedOffersViewModel?> GetAllSelectOffersAsync(IEnumerable<string> selectedOffers , string barbershopId)
        {
			BarbershopSelectedOffersViewModel barbershopSelectedOffers = new BarbershopSelectedOffersViewModel();
			barbershopSelectedOffers.AllOffers = new List<AllOffersViewModel>();

			bool isOfferIdValid = false;
			foreach (string selectedOffer in selectedOffers)
			{
				isOfferIdValid = Guid.TryParse(selectedOffer, out Guid GuidId);
				if (!isOfferIdValid)
				{
					return barbershopSelectedOffers;
				}
			}
			barbershopSelectedOffers.BarbershopId = barbershopId;
			barbershopSelectedOffers.AllOffers = await this.applicationDbContext.Offers
								.AsNoTracking()
								.Where(o => selectedOffers.Contains(o.Id.ToString()))
								.Select(o => new AllOffersViewModel()
								{
									Id = o.Id.ToString(),
									Name = o.Name,
									Description = o.Description,
									Price = o.Price
								})
								.ToListAsync();

			return barbershopSelectedOffers;

		}
    }
}
