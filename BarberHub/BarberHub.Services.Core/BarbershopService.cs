using BarberHub.Data.Models.Interfaces;
using BarberHub.Web.Data;
using BarberHub.Web.ViewModels.Barbershop;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<AllBarbershopsIndexViewModel>> GetAllBarbershops()
        {
            List<AllBarbershopsIndexViewModel> allBarbershops =
                                            await this.applicationDbContext.Barbershops
                                            .AsNoTracking()
                                            .Select(b => new AllBarbershopsIndexViewModel()
                                            {
                                                Id = b.Id.ToString(),
                                                Name = b.Name,
                                                Description = b.Description,
                                                // TODO: Make this work with my no-image.jpg
                                                ImageUrl = b.ImageUrl ?? $"https://as1.ftcdn.net/v2/jpg/02/05/49/82/1000_F_205498258_AfQmtyR5kO5llwKd6fWRRxcc4xRUbQcb.jpg",
                                                OpenTime = b.OpenTime.Value.ToString("HH:mm") ?? NoWorkTime,
                                                CloseTime = b.CloseTime.Value.ToString("HH:mm") ?? NoWorkTime,
                                            })
                                            .ToListAsync();

            return allBarbershops;

        }
    }
}
