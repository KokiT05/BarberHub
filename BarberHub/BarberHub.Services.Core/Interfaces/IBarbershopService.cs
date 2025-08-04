using BarberHub.Web.ViewModels.Barbershop;

namespace BarberHub.Data.Models.Interfaces
{
    public interface IBarbershopService
    {
        Task<IEnumerable<AllBarbershopsIndexViewModel>> GetAllBarbershopsAsync();

        Task<DetailsBarbershopViewModel?> GetDetailsBarbershopAsync(string? id);

        Task<EditBarbershopViewModel?> GetEditDetailsBarbershopAsync(string? id);

        Task<bool> EditBarbershopAsync(EditBarbershopViewModel editBarbershopViewModel);

        Task CreateBarbershopAsync(FormBarbershopViewModel inputBarbershopModel);


    }
}
