using BarberHub.Web.ViewModels.SelectOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Services.Core.Interfaces
{
    public interface ISelectOfferService
    {
        Task<BarbershopSelectedOffersViewModel?> GetAllSelectOffersAsync(IEnumerable<string> selectedOffers, string barbershopId);

        Task AddSelectOfferAsync(IEnumerable<string> inputModelIds, string barbershopId, string userId);
    }
}
