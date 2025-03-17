using ExperienceAPI.Models;
using ExperienceAPI.Data;

namespace ExperienceAPI.Data;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Providers.Any())
        {
            Console.WriteLine("Database already has data. Skipping seeding...");
            return;
        }

        Console.WriteLine("Seeding database...");

        //  1. Insert Provider
        var provider = new Provider 
        {
            TouristicPermit = "11111114",  // ændret fra  cvr til TouristicPermit ift opgaave E 1. migration    
            BusinessPhysicalAddress = "Findlandsgade 17, 8200 Aarhus N",
            PhoneNumber = "45 7155080",
            Experiences = new List<Experience>()
        };

        context.Providers.Add(provider);
        context.SaveChanges();
        Console.WriteLine($" Added Provider: {provider.ProviderID}");

        //  2. Insert Experiences
        var experience1 = new Experience { Type = "Night at Noah's Hotel Single room", Price = 730, ProviderID_FK = provider.ProviderID };
        var experience2 = new Experience { Type = "Night at Noah's Hotel Double room", Price = 910, ProviderID_FK = provider.ProviderID };
        var experience3 = new Experience { Type = "Flight AAR - VIE", Price = 1000, ProviderID_FK = provider.ProviderID };
        var experience4 = new Experience { Type = "Vienna Historic Center Walking Tour", Price = 100, ProviderID_FK = provider.ProviderID };

        context.Experiences.AddRange(experience1, experience2, experience3, experience4);
        context.SaveChanges();
        Console.WriteLine(" Added Experiences");

        //  3. Insert Discounts (to prevent FK errors)
        var discount1 = new Discount { ExperienceID_FK = experience1.ExperienceID, GroupSize = 4, PriceAfterDiscount = 730.50m, DiscountAmount = 0 };
        var discount2 = new Discount { ExperienceID_FK = experience3.ExperienceID, GroupSize = 4, PriceAfterDiscount = 910.99m, DiscountAmount = 0 };
        var discount3 = new Discount { ExperienceID_FK = experience4.ExperienceID, GroupSize = 2, PriceAfterDiscount = 100, DiscountAmount = 0 };

        context.Discounts.AddRange(discount1, discount2, discount3);
        context.SaveChanges();
        Console.WriteLine(" Added Discounts");

        //  4. Insert Shared Experiences
        var sharedExperience1 = new SharedExperience { Name = "Trip to Austria", Date = DateTime.Now.AddDays(10), ExperienceID_FK = experience4.ExperienceID };
        var sharedExperience2 = new SharedExperience { Name = "Trip to Austria", Date = DateTime.Now.AddDays(10), ExperienceID_FK = experience1.ExperienceID };

        context.SharedExperiences.AddRange(sharedExperience1, sharedExperience2);
        context.SaveChanges();
        Console.WriteLine(" Added Shared Experiences");

        //  5. Insert Guests
        var guest1 = new Guest { Name = "Joan", Age = 28, PhoneNumber = "87654321" };
        var guest2 = new Guest { Name = "Suzzane", Age = 83, PhoneNumber = "86754341" };
        var guest3 = new Guest { Name = "Patrick", Age = 44, PhoneNumber = "23122312" };
        var guest4 = new Guest { Name = "Anne", Age = 48, PhoneNumber = "44553322" };

        context.Guests.AddRange(guest1, guest2, guest3, guest4);
        context.SaveChanges();
        Console.WriteLine(" Added Guests");

        //  6. Register guests in shared experiences
        var guestSharedExperiences = new List<GuestSharedExperience>
        {
            new GuestSharedExperience { GuestID = guest1.GuestID, ShareExperienceID = sharedExperience1.ShareExperienceID },
            new GuestSharedExperience { GuestID = guest2.GuestID, ShareExperienceID = sharedExperience1.ShareExperienceID },
            new GuestSharedExperience { GuestID = guest1.GuestID, ShareExperienceID = sharedExperience2.ShareExperienceID },
            new GuestSharedExperience { GuestID = guest2.GuestID, ShareExperienceID = sharedExperience2.ShareExperienceID },
            new GuestSharedExperience { GuestID = guest3.GuestID, ShareExperienceID = sharedExperience2.ShareExperienceID },
            new GuestSharedExperience { GuestID = guest4.GuestID, ShareExperienceID = sharedExperience2.ShareExperienceID }
        };

        context.GuestSharedExperiences.AddRange(guestSharedExperiences);
        context.SaveChanges();
        Console.WriteLine(" Registered guests in shared experiences");

        //  7. Register guests in experiences (from Table 8)
        var reservations = new List<Reservation>
        {
            // Night at Noah's Hotel Single Room (4 guests)
            new Reservation { GuestID = guest1.GuestID, ExperienceID_FK = experience1.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 730.50m },
            new Reservation { GuestID = guest2.GuestID, ExperienceID_FK = experience1.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 730.50m },
            new Reservation { GuestID = guest3.GuestID, ExperienceID_FK = experience1.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 730.50m },
            new Reservation { GuestID = guest4.GuestID, ExperienceID_FK = experience1.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 730.50m },

            // Night at Noah's Hotel Double Room (0 guests) ingen guester added.

            // Flight AAR - VIE (4 guests)
            new Reservation { GuestID = guest1.GuestID, ExperienceID_FK = experience3.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 1000.70m },
            new Reservation { GuestID = guest2.GuestID, ExperienceID_FK = experience3.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 1000.70m },
            new Reservation { GuestID = guest3.GuestID, ExperienceID_FK = experience3.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 1000.70m },
            new Reservation { GuestID = guest4.GuestID, ExperienceID_FK = experience3.ExperienceID, GroupSize_FK = 4, PriceAfterDiscount_PK = 1000.70m },

            // Vienna Historic Center Walking Tour (2 guests)
            new Reservation { GuestID = guest1.GuestID, ExperienceID_FK = experience4.ExperienceID, GroupSize_FK = 2, PriceAfterDiscount_PK = 100m },
            new Reservation { GuestID = guest2.GuestID, ExperienceID_FK = experience4.ExperienceID, GroupSize_FK = 2, PriceAfterDiscount_PK = 100m }
        };

        context.Reservations.AddRange(reservations);
        context.SaveChanges();
        Console.WriteLine(" Registered guests in experiences");

        Console.WriteLine(" Seeding Completed Successfully!");
    }
}
