using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CustomerApp.Models;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerContext(
                serviceProvider.GetRequiredService<DbContextOptions<CustomerContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;   // DB has been seeded
                }

                context.Customers.AddRange(
                    new Customer()
                    {
                        Name = "Rocky",
                        Surname = "Balboa",
                        PhoneNumber = "+888888888"
                    },

                    new Customer()
                    {
                        Name = "Apollo ",
                        Surname = "Creed",
                    },

                    new Customer()
                    {
                        Name = "Ivan",
                        Surname = "Drago",
                        Address = "Mother Russia"
                    },

                    new Customer()
                    {
                        Name = "Adrian",
                        Surname = "Pennino",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}