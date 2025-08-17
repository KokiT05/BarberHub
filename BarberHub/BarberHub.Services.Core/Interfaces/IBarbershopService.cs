using BarberHub.Web.ViewModels.Barbershop;

namespace BarberHub.Data.Models.Interfaces
{
    public interface IBarbershopService
    {
        Task<BarbershopPeginationViewModel> GetAllBarbershopsAsync(int page = 1, int pageSize = 6);

        Task<DetailsBarbershopViewModel?> GetDetailsBarbershopAsync(string? id);

        Task<EditBarbershopViewModel?> GetEditDetailsBarbershopAsync(string? id);

        Task<bool> EditBarbershopAsync(EditBarbershopViewModel editBarbershopViewModel);

        Task CreateBarbershopAsync(FormBarbershopViewModel inputBarbershopModel);

        Task<DeleteBarbershopViewModel?> GetDeleteBarbershopAsync(string? id);

        Task<bool> SoftDeleteAsync(string? id);

        Task<bool> HardDeleteAsync(string? id);

        Task<BarbershopSearchViewModel> SearchBarbershopAsync(string? searchName, string? searchCity);


    }
}
