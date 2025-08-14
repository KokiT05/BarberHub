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
        Task<BarbershopAllOffersViewModel?> GetAllOffersAsync(string? barbershopId);

        Task<IEnumerable<AllOffersViewModel>> GetAllSelectOffersAsync(IEnumerable<string> selectOfferIds);

        Task CreateOfferAsync(FormOfferViewModel inputOfferModel, string? barbershopId);

        Task<EditOfferViewModel?> GetEditDetailsOfferAsync(string? offerId);

        Task<bool> EditOfferAsync(EditOfferViewModel? offerModel);

        Task<bool> DeleteOfferAsync(string? offerId);
    }
}
