using BarberHub.Web.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Services.Core.Interfaces
{
    public interface IOfferService
    {
        Task<IEnumerable<AllOffersViewModel>> GetAllOffersAsync(string? barbershopId);

        Task CreateOfferAsync(FormOfferViewModel inputOfferModel, string? barbershopId);

        Task<EditOfferViewModel?> GetEditDetailsOfferAsync(string? offerId);

        Task<bool> EditOfferAsync(EditOfferViewModel? offerModel);
    }
}
