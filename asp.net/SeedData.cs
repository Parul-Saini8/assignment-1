// Models/SeedData.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartphoneManagement.Models;
using System;
using System.Linq;

namespace SmartphoneManagement.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YourDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<YourDbContext>>()))
            {
                // Check if there is existing data
                if (context.Smartphones.Any())
                {
                    return; // Database has been seeded
                }

                // Add seed data
                context.Smartphones.AddRange(
                    new Smartphone
                    {
                        Name = "Phone A",
                        Brand = "Brand X",
                        Price = 499.99
                    },
                    // Add more seed data as needed
                );

                context.SaveChanges();
            }
        }
    }
}
