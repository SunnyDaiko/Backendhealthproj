using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var promoCode = new PromoCode()
            {
                Id = 1,
                Title = "SUMMER2015",
                Description = "Our summer discount for the Q3 2015 campaign\r\n\r\n",
                Type = "flat",
                Rate = 10.00f,
            };

            modelBuilder.Entity<PromoCode>().HasData(promoCode);

            var userList = CreateUsers();
            modelBuilder.Entity<User>().HasData(userList);

            var patientFactory = new PatientFactory();
            var patients = patientFactory.GenerateRandomPatients(100);
            modelBuilder.Entity<Patient>().HasData(patients);

            var purchaseFactory = new PurchaseFactory();
            var purchases = purchaseFactory.GenerateRandomPurchases(10, userList);
            modelBuilder.Entity<Purchase>().HasData(purchases);

            var lineItemFactory = new LineItemFactory();
            var lineItems = lineItemFactory.GenerateLineItems(10);
            modelBuilder.Entity<LineItem>().HasData(lineItems);

            var reviewFactory = new ReviewFactory();
            var reviews = reviewFactory.GenerateReviewsForPurchases(10, purchases);
            modelBuilder.Entity<Review>().HasData(reviews);
        }


        public static List<User> CreateUsers()
        {
            var users = new List<User>();

            var userBiggie = new User()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "bigesmalls@echh.com",
                FirstName = "Biggie",
                LastName = "Smalls",
                Street = "East Coast Lane",
                Apt = "Apartment in the Sky",
                City = "Brooklyn",
                State = "New York",
                ZipCode = 11221
            };

            users.Add(userBiggie);

            var userTupac = new User()
            {
                Id = 2,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "tupacs@wchh.com",
                FirstName = "Tupac",
                LastName = "Shakur",
                Street = "West Coast Lane",
                Apt = "Apartment in the Sky",
                City = "Compton",
                State = "California",
                ZipCode = 90220
            };

            users.Add(userTupac);

            var userDaniel = new User()
            {
                Id = 3,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "dvoigt@catalyte.io",
                FirstName = "Daniel",
                LastName = "Voigt",
                Street = "Anywhere",
                Apt = "Dungeon Server Room",
                City = "Evergreen",
                State = "Colorado",
                ZipCode = 80439
            };

            users.Add(userDaniel);

            var userGabrielle = new User()
            {
                Id = 4,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "gnacario@catalyte.io",
                FirstName = "Gabrielle",
                LastName = "Nacario",
                Street = "Anywhere",
                Apt = "",
                City = "Big Town",
                State = "Maryland",
                ZipCode = 21401
            };

            users.Add(userGabrielle);

            var userRobert = new User()
            {
                Id = 5,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "rhighsmith@catalyte.io",
                FirstName = "Robert",
                LastName = "Highsmith",
                Street = "Anywhere",
                Apt = "Penthouse Suite",
                City = "Sorta Big Town",
                State = "Maryland",
                ZipCode = 21401
            };

            users.Add(userRobert);

            var userNicole = new User()
            {
                Id = 6,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "nschiewer@catalyte.io",
                FirstName = "Nicole",
                LastName = "Schiewer",
                Street = "Anywhere",
                Apt = "Building 9",
                City = "Springfield",
                State = "Illinois",
                ZipCode = 62701
            };

            users.Add(userNicole);

            var userHayes = new User()
            {
                Id = 7,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "hmccardell@catalyte.io",
                FirstName = "Hayes",
                LastName = "Mccardell",
                Street = "Anywhere",
                Apt = "Apartment 150",
                City = "Saint Louis",
                State = "Missouri",
                ZipCode = 63101
            };

            users.Add(userHayes);

            var userKathleen = new User()
            {
                Id = 8,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Email = "kgorman@catalyte.io",
                FirstName = "Kathleen",
                LastName = "Gorman",
                Street = "Anywhere",
                Apt = "Apartment 50",
                City = "Marietta",
                State = "Georgia",
                ZipCode = 30008
            };

            List<User> userList = new List<User>();

            users.Add(userKathleen);

            return users;
        }
    }
}
