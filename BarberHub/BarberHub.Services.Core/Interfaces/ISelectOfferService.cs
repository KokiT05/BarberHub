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
        Task GetAllSelectOffersAsync(SelectedOffersViewModel inputSelectOfferModel, string userId);

        Task AddSelectOfferAsync(SelectedOffersViewModel inputSelectOfferModel, string userId);
    }
}
