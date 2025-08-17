using BarberHub.Data.Models;
using BarberHub.Data.Models.Interfaces;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Barbershop;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberHub.Services.Core
{
    using static BarberHub.GlobalCommon.ApplicationConstants;
    public class BarbershopService : IBarbershopService
    {
        private readonly ApplicationDbContext applicationDbContext;
        public BarbershopService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<BarbershopPeginationViewModel> GetAllBarbershopsAsync(int page = 1, int pageSize = 6)
        {
            BarbershopPeginationViewModel barbershopPegination = new BarbershopPeginationViewModel();

            barbershopPegination.TotalPages = await this.applicationDbContext.Barbershops.CountAsync();

            barbershopPegination.Barbershops =
                                            await this.applicationDbContext.Barbershops
                                            .AsNoTracking()
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize)
                                            .Select(b => new AllBarbershopsIndexViewModel()
                                            {
                                                Id = b.Id.ToString(),
                                                Name = b.Name,
                                                Description = b.Description.Substring(0, 25),
                                                PhoneNumber = b.PhoneNumber,
                                                // TODO: Make this work with my no-image.jpg
                                                ImageUrl = b.ImageUrl ?? $"https://as1.ftcdn.net/v2/jpg/02/05/49/82/1000_F_205498258_AfQmtyR5kO5llwKd6fWRRxcc4xRUbQcb.jpg",
                                                City = b.City,
                                                Address = b.Address,
                                                OpenTime = b.OpenTime.Value.ToString("HH:mm") ?? NoWorkTime,
                                                CloseTime = b.CloseTime.Value.ToString("HH:mm") ?? NoWorkTime,
                                            })
                                            .ToListAsync();



            return barbershopPegination;

        }

        public async Task<DetailsBarbershopViewModel?> GetDetailsBarbershopAsync(string? id)
        {
            DetailsBarbershopViewModel? barbershop = null;

            bool isValidId = Guid.TryParse(id, out Guid barbershopId);
            if (isValidId)
            {
                barbershop = await this.applicationDbContext
                                        .Barbershops
                                        .Where(b => b.Id.ToString() == id)
                                        .Select(b => new DetailsBarbershopViewModel()
                                        {
                                            Id = b.Id.ToString(),
                                            Name = b.Name,
                                            Description = b.Description,
                                            PhoneNumber = b.PhoneNumber,
                                            ImageUrl = b.ImageUrl ?? "https://as1.ftcdn.net/v2/jpg/02/05/49/82/1000_F_205498258_AfQmtyR5kO5llwKd6fWRRxcc4xRUbQcb.jpg",
                                            City = b.City,
                                            Address = b.Address,
                                            OpenTime = b.OpenTime.Value.ToString(WorkTimeFormat) ?? NoWorkTime,
                                            CloseTime = b.CloseTime.Value.ToString(WorkTimeFormat) ?? NoWorkTime
                                        })
                                        .SingleOrDefaultAsync();
            }

            return barbershop;
        }

        public async Task<EditBarbershopViewModel?> GetEditDetailsBarbershopAsync(string? id)
        {
            EditBarbershopViewModel? editBarbershopViewModel = null;

            bool isValidGuid = Guid.TryParse(id, out Guid validId);
            if (isValidGuid)
            {
                editBarbershopViewModel = await this.applicationDbContext.Barbershops
                                                .AsNoTracking()
                                                .Where(b => b.Id.ToString() == id)
                                                .Select(b => new EditBarbershopViewModel()
                                                {
                                                    Id = id,
                                                    Name = b.Name,
                                                    Description = b.Description,
                                                    PhoneNumber = b.PhoneNumber,
                                                    ImageUrl = b.ImageUrl,
                                                    City = b.City,
                                                    Address = b.Address,
                                                    OpenTime = b.OpenTime.Value.ToString(WorkTimeFormat) ?? NoWorkTime,
                                                    CloseTime = b.CloseTime.Value.ToString(WorkTimeFormat) ?? NoWorkTime,

                                                })
                                                .SingleOrDefaultAsync();
            }

            return editBarbershopViewModel;
        }

        public async Task CreateBarbershopAsync(FormBarbershopViewModel inputBarbershopModel)
        {
            Barbershop barbershop = new Barbershop()
            {
                Name = inputBarbershopModel.Name,
                Description = inputBarbershopModel.Description,
                PhoneNumber = inputBarbershopModel.PhoneNumber,
                ImageUrl = inputBarbershopModel.ImageUrl,
                City = inputBarbershopModel.City,
                Address = inputBarbershopModel.Address,
                OpenTime = TimeOnly.ParseExact(inputBarbershopModel.OpenTime, WorkTimeFormat),
                CloseTime = TimeOnly.ParseExact(inputBarbershopModel.CloseTime, WorkTimeFormat)
            };

            await this.applicationDbContext.Barbershops.AddAsync(barbershop);
            await this.applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> EditBarbershopAsync(EditBarbershopViewModel editBarbershopViewModel)
        {

            Barbershop? barbershop =
                    await this.FindBarbershopByStringIdAsync(editBarbershopViewModel.Id);

            if (barbershop == null)
            {
                return false;
            }

            barbershop.Name = editBarbershopViewModel.Name;
            barbershop.Description = editBarbershopViewModel.Description;
            barbershop.PhoneNumber = editBarbershopViewModel.PhoneNumber;
            barbershop.ImageUrl = editBarbershopViewModel.ImageUrl;
            barbershop.City = editBarbershopViewModel.City;
            barbershop.Address = editBarbershopViewModel.Address;
            barbershop.OpenTime = TimeOnly.ParseExact(editBarbershopViewModel.OpenTime, WorkTimeFormat);
            barbershop.CloseTime = TimeOnly.ParseExact(editBarbershopViewModel.CloseTime, WorkTimeFormat);

            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteBarbershopViewModel?> GetDeleteBarbershopAsync(string? id)
        {
            DeleteBarbershopViewModel? deleteBarbershop = null;

            Barbershop? barbershop = await this.FindBarbershopByStringIdAsync(id);

            if (barbershop != null)
            {
                deleteBarbershop = new DeleteBarbershopViewModel()
                {
                    Id = barbershop.Id.ToString(),
                    Name = barbershop.Name,
                    ImageUrl = barbershop.ImageUrl,
                };
            }

            return deleteBarbershop;
        }

        public async Task<bool> SoftDeleteAsync(string? id)
        {
            Barbershop? barbershop = await this.FindBarbershopByStringIdAsync(id);

            if (barbershop == null)
            {
                return false;
            }

            barbershop.IsDeleted = true;
            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HardDeleteAsync(string? id)
        {
            Barbershop? barbershop = await this.FindBarbershopByStringIdAsync(id);

            if (barbershop == null)
            {
                return false;
            }

            this.applicationDbContext.Barbershops.Remove(barbershop);
            await this.applicationDbContext.SaveChangesAsync();

            return true;
        }

        private async Task<Barbershop?> FindBarbershopByStringIdAsync(string? id)
        {
            Barbershop? barbershop = null;

            if (!string.IsNullOrWhiteSpace(id))
            {
                bool isValidGuid = Guid.TryParse(id, out Guid validId);
                if (isValidGuid)
                {
                    barbershop = await this.applicationDbContext.Barbershops.FindAsync(validId);
                }
            }

            return barbershop;
        }

        public async Task<BarbershopSearchViewModel> SearchBarbershopAsync(string? searchName, string? searchCity)
        {
            BarbershopSearchViewModel matchBarbershops = new BarbershopSearchViewModel();
            matchBarbershops.SearchName = searchName;
            matchBarbershops.City = searchCity;

            bool isNameEmpty = string.IsNullOrEmpty(searchName);
            bool isCityEmpty = string.IsNullOrEmpty(searchCity);

            if (isNameEmpty && isCityEmpty)
            {
                return matchBarbershops;
            }

            IEnumerable<Barbershop> allBarbershops = await this.applicationDbContext
                                                    .Barbershops
                                                    .AsNoTracking()
                                                    .ToListAsync();

            if (!isNameEmpty && !isCityEmpty)
            {
                allBarbershops = allBarbershops.Where(b => b.Name.Contains(searchName) && b.City.Contains(searchCity));
            }
            if (!isNameEmpty)
            {
                allBarbershops = allBarbershops.Where(b => b.Name.Contains(searchName));
            }
            else if (!isCityEmpty)
            {
                allBarbershops = allBarbershops.Where(b => b.City.Contains(searchCity));
            }

            matchBarbershops.Barbershops = allBarbershops.Select(b => new AllBarbershopsIndexViewModel()
                                                        {
                                                            Id = b.Id.ToString(),
                                                            Name = b.Name,
                                                            Description = b.Description,
                                                            ImageUrl = b.ImageUrl,
                                                            City = b.City,
                                                            Address = b.Address,
                                                            OpenTime = b.OpenTime.Value.ToString("HH:mm") ?? NoWorkTime,
                                                            CloseTime = b.CloseTime.Value.ToString("HH:mm") ?? NoWorkTime

                                                        });


            return matchBarbershops;
        }
    }
}
