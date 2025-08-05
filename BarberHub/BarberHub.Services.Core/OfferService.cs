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
        public async Task<IEnumerable<AllOffersViewModel>> GetAllOffersAsync()
        {
            IEnumerable<AllOffersViewModel> allOffers =
                                        await this.applicationDbContext.Offers
                                        .AsNoTracking()
                                        .Select(o => new AllOffersViewModel()
                                        {
                                            Id = o.Id.ToString(),
                                            Name = o.Name,
                                            Description = o.Description,
                                            Price = o.Price
                                        })
                                        .ToListAsync();

            return allOffers;
        }
    }
}
