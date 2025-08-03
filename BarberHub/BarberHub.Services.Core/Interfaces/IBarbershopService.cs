using BarberHub.Web.ViewModels.Barbershop;

namespace BarberHub.Data.Models.Interfaces
{
    public interface IBarbershopService
    {
        Task<IEnumerable<AllBarbershopsIndexViewModel>> GetAllBarbershopsAsync();

        Task<DetailsBarbershopViewModel?> GetDetailsBarbershopAsync(string? id);
    }
}
