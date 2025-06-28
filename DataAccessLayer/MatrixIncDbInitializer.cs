using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using static System.Net.WebRequestMethods;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Hier moet ik nog wat namen verzinnen die betrekking hebben op de matrix.
            // - Denk aan de m3 boutjes, moertjes en ringetjes.
            // - Denk aan namen van schepen
            // - Denk aan namen van vliegtuigen            
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product { Name = "Nebuchadnezzar", Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen", Price = 10000.00m, ImgUrl = "https://f4.bcbits.com/img/a3803724682_10.jpg" },
                new Product { Name = "Jack-in Chair", Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort", Price = 500.50m, ImgUrl="https://media.tenor.com/enoxxJtm0yMAAAAe/neo-plugging-to-matrix.png" },
                new Product { Name = "EMP (Electro-Magnetic Pulse) Device", Description = "Wapentuig op de schepen van Zion (negeer het feit dat dit een icoontje is uit een game waar ik 3000 uur in heb zitten)", Price = 129.99m, ImgUrl = "https://static0.gamerantimages.com/wordpress/wp-content/uploads/2023/08/dead-by-daylight-emp-special-item.jpg" }
            };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen", Price=0.50m, ImgUrl = "https://static.vecteezy.com/system/resources/thumbnails/049/665/428/small/rusty-gear-wheel-with-transparent-background-isolated-cog-wheel-with-a-steampunk-aesthetic-png.png"},
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules", Price = 0.25m, ImgUrl = "https://www.cimex.us/wp-content/uploads/2016/10/45.jpg"},
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen", Price = 3.56m, ImgUrl = "https://media.rs-online.com/F2638613-01.jpg"},
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen.", Price=85.34m, ImgUrl = "https://www.hogetex.com/media/catalog/product/cache/abe8e32530358e970f9de6550ae2191b/H/G/HGTC2545_28717_1_3.jpg"}
            };
            context.Parts.AddRange(parts);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
