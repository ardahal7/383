using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _383_Phase1_InventoryTracker.Entities
{
    //Seeding an admin to the database.
    public static class DbInitializer
    {
        public static void Initialize(InventoryTrackerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var user = new User[]
            {
            new User{FirstName="Administrator",LastName="Maestro",Role="Admin",UserName="admin",Password=Crypto.HashPassword("selu2017")},
                        };
            foreach (User u in user)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

        }
    }
}
