using BarberHub.Data.Models;
using BarberHub.GlobalCommon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberHub.Data.Configuration
{
    using static Common.EntityConstants;
    using static Common.EntityConstants.BarbershopConstants;
    using static ApplicationConstants;
    public class BarbershopConfiguration : IEntityTypeConfiguration<Barbershop>
    {
        public void Configure(EntityTypeBuilder<Barbershop> model)
        {
            model.Property(b => b.Id);

            model.HasKey(b => b.Id);

            model.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            model.Property(b => b.Description)
                .HasMaxLength(DescriptionMaxLength);

            model.Property(b => b.PhoneNumber)
                .HasMaxLength(PhoneNumberMaxAndMinLength);

            model.Property(b => b.ImageUrl)
                .HasMaxLength(ImageUrlMaxLength);

            model.Property(b => b.City)
                .IsRequired()
                .HasMaxLength(CityMaxlength);

            model.Property(b => b.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            model.Property(b => b.OpenTime);
            model.Property(b => b.CloseTime);

            model.HasMany(b => b.Offers)
                .WithOne(o => o.Barbershop)
                .HasForeignKey(o => o.BarbershopId);

            model.HasMany(b => b.Appointments)
                .WithOne(a => a.Barbershop)
                .HasForeignKey(a => a.BarbershopId);

            model.Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);

            model.HasQueryFilter(b => b.IsDeleted == false);

            model.HasData(this.SeedBarbershops());
        }

        private List<Barbershop> SeedBarbershops()
        {
            List<Barbershop> barbershops = new List<Barbershop>()
            {
                new Barbershop()
                {
                    Id = Guid.Parse("9c31e450-0fd6-4aa6-8d05-cd79b87ce656"),
                    Name = "The Brothers",
                    Description = "Just a barbershop",
                    PhoneNumber = "0881234567",
                    ImageUrl = $"~/images/{NoImageUrl}",
                    City = "Sofia",
                    Address = "бул. Ломско шосе",
                    OpenTime = new TimeOnly(8, 30),
                    CloseTime = new TimeOnly(20, 30),
                    IsDeleted = false
                },
                new Barbershop()
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-567890abcdef"),
                    Name = "Barber's Den",
                    Description = "Традиционна бръснарница с модерен привкус.",
                    PhoneNumber = "0887654321",
                    ImageUrl = "https://example.com/barbersden.jpg",
                    City = "София",
                    Address = "ул. Витоша 15",
                    OpenTime = new TimeOnly(9, 0),
                    CloseTime = new TimeOnly(18, 0),
                    IsDeleted = false
                },
                new Barbershop()
                {
                    Id = Guid.Parse("f6e5d4c3-b2a1-0987-6543-210fedcba987"),
                    Name = "The Clip Joint",
                    Description = "Място, където стилът среща прецизността.",
                    PhoneNumber = "0885126287",
                    ImageUrl = "https://example.com/clipjoint.png",
                    City = "Пловдив",
                    Address = "бул. Свобода 10",
                    OpenTime = new TimeOnly(10, 0),
                    CloseTime = new TimeOnly(19, 0),
                    IsDeleted = false
                },
                 new Barbershop()
                 {
                     Id = Guid.Parse("1a2b3c4d-5e6f-7890-abcd-ef1234567890"),
                     Name = "Gentlemen's Quarters",
                     Description = "Ексклузивна бръснарница за истински господа.",
                     PhoneNumber = "0881233361",
                     ImageUrl = "https://example.com/gentlemensquarters.webp",
                     City = "Варна",
                     Address = "ул. Княз Борис I 25",
                     OpenTime = new TimeOnly(8, 30),
                     CloseTime = new TimeOnly(17, 30),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("e50edee5-a5b3-4533-a996-3aa73d1d6af2"),
                     Name = "Urban Fade",
                     Description = "Съвременна бръснарница с младежки стил.",
                     PhoneNumber = "0899123456",
                     ImageUrl = "https://example.com/urbanfade.jpg",
                     City = "София",
                     Address = "ул. Александър Стамболийски 78",
                     OpenTime = new TimeOnly(9, 0),
                     CloseTime = new TimeOnly(19, 30),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("90625b4c-37c5-45e0-b907-e6cb112546b9"),
                     Name = "King's Cuts",
                     Description = "Класика в мъжките подстрижки.",
                     PhoneNumber = "0899765432",
                     ImageUrl = "https://example.com/kingscuts.jpg",
                     City = "Пловдив",
                     Address = "ул. Христо Ботев 32",
                     OpenTime = new TimeOnly(8, 0),
                     CloseTime = new TimeOnly(18, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("5cc99a51-6dc3-4eae-8103-e5a11fceba0e"),//123
                     Name = "Sharp Look",
                     Description = "Точност и стил във всяка прическа.",
                     PhoneNumber = "0883456789",
                     ImageUrl = "https://example.com/sharplook.png",
                     City = "Бургас",
                     Address = "ул. Богориди 14",
                     OpenTime = new TimeOnly(10, 0),
                     CloseTime = new TimeOnly(20, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("60fdc286-fcb9-415c-b5b0-3ba7e89e25ce"),
                     Name = "Modern Gents",
                     Description = "Място за модерния джентълмен.",
                     PhoneNumber = "0886543210",
                     ImageUrl = "https://example.com/moderngents.jpg",
                     City = "Русе",
                     Address = "ул. Александровска 9",
                     OpenTime = new TimeOnly(9, 30),
                     CloseTime = new TimeOnly(19, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("6aa8e559-9f84-4e87-9351-28a2b0da612a"),
                     Name = "The Fade House",
                     Description = "Специалисти в fade стил подстрижките.",
                     PhoneNumber = "0897654123",
                     ImageUrl = "https://example.com/fadehouse.jpg",
                     City = "София",
                     Address = "ж.к. Младост 1, бл. 54",
                     OpenTime = new TimeOnly(8, 0),
                     CloseTime = new TimeOnly(20, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("acc57349-ea74-470b-b548-d9f485be8e2a"),
                     Name = "Classic Barber",
                     Description = "Традиционни подстрижки и бръснене.",
                     PhoneNumber = "0877123456",
                     ImageUrl = "https://example.com/classicbarber.jpg",
                     City = "Велико Търново",
                     Address = "ул. Независимост 17",
                     OpenTime = new TimeOnly(9, 0),
                     CloseTime = new TimeOnly(18, 30),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("73956d5e-5a39-4274-8c8a-1e59bef9a69b"),
                     Name = "Elite Barbers",
                     Description = "Премиум обслужване и уютна атмосфера.",
                     PhoneNumber = "0877456321",
                     ImageUrl = "https://example.com/elitebarbers.png",
                     City = "Стара Загора",
                     Address = "ул. Цар Симеон Велики 45",
                     OpenTime = new TimeOnly(8, 30),
                     CloseTime = new TimeOnly(19, 30),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("4dc134e6-6a16-4a6d-b685-b6066207c18f"),
                     Name = "Downtown Barber",
                     Description = "Бръснарница в сърцето на града.",
                     PhoneNumber = "0898989898",
                     ImageUrl = "https://example.com/downtownbarber.webp",
                     City = "София",
                     Address = "бул. Дондуков 66",
                     OpenTime = new TimeOnly(9, 0),
                     CloseTime = new TimeOnly(19, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("23f53a53-bf8b-4bba-bd00-e920d0953a8e"),
                     Name = "Steel & Style",
                     Description = "Метал, кожа и стилни подстрижки.",
                     PhoneNumber = "0889012345",
                     ImageUrl = "https://example.com/steelandstyle.jpg",
                     City = "Варна",
                     Address = "ул. Сливница 101",
                     OpenTime = new TimeOnly(10, 0),
                     CloseTime = new TimeOnly(20, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("9bbc6a4b-52fa-48e9-8bcf-eea7eb011720"),
                     Name = "Golden Razor",
                     Description = "Място за истинско златно обслужване.",
                     PhoneNumber = "0877011223",
                     ImageUrl = "https://example.com/goldenrazor.jpg",
                     City = "Бургас",
                     Address = "ул. Съединение 27",
                     OpenTime = new TimeOnly(9, 0),
                     CloseTime = new TimeOnly(18, 30),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("34d8bf59-88af-4d1b-b761-a65e2b67827c"),
                     Name = "Barber Republic",
                     Description = "Независим стил за свободни хора.",
                     PhoneNumber = "0885333444",
                     ImageUrl = "https://example.com/barberrepublic.jpg",
                     City = "Плевен",
                     Address = "ул. Данаил Попов 5",
                     OpenTime = new TimeOnly(8, 0),
                     CloseTime = new TimeOnly(19, 0),
                     IsDeleted = false
                 },
                 new Barbershop()
                 {
                     Id = Guid.Parse("0b345d63-4eeb-44a0-b61a-a3d19c9555c5"),
                     Name = "The Barber Spot",
                     Description = "Спокойна обстановка и професионализъм.",
                     PhoneNumber = "0884111222",
                     ImageUrl = "https://example.com/barberspot.png",
                     City = "Благоевград",
                     Address = "ул. Тодор Александров 12",
                     OpenTime = new TimeOnly(9, 30),
                     CloseTime = new TimeOnly(18, 0),
                     IsDeleted = false
                 },
            };

            return barbershops;
        }
    }
}
