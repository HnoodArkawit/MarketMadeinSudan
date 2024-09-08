using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketMadeinSudan.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },

                new IdentityRole
                { 
                    Id = "44c8065a-f4ab-4cdf-b0a7-bdb171c3ca49",
                    Name = "Accessories",
                    NormalizedName = "ACCESSORIES"
                },
                new IdentityRole
                {
                    Id = "dff2d10b-a4c6-4199-8f1d-0ae1316c9129",
                    Name = "AgriculturalCrops",
                    NormalizedName = "AGRICULTURALCROPS"
                },
                new IdentityRole
                {
                    Id = "ad9b70a4-153b-4e6c-b37b-08275a261bf7",
                    Name = "Aspires",
                    NormalizedName = "ASPIRES"
                },
                new IdentityRole
                {
                    Id = "aa827fc7-9a4e-4d95-88ef-de6d85e3f47e",
                    Name = "ElectricalAndElctronic",
                    NormalizedName = "ELECTRICALANDELCTRONIC"
                },
                new IdentityRole
                {
                    Id = "f55368f6-2421-4c30-af4a-1288a0e275c0",
                    Name = "Fabrics",
                    NormalizedName = "FABRICS"
                },
                new IdentityRole
                {
                    Id = "f42b8ff8-10f4-44a8-ab6c-84a04acd8a76",
                    Name = "Food",
                    NormalizedName = "FOOD"
                },
                new IdentityRole
                {
                    Id = "e7d933cc-fbf0-4622-8a59-8455f8a18b97",
                    Name = "HouseholdProducts",
                    NormalizedName = "HOUSEHOLDPRODUCTS"
                },
                new IdentityRole
                {
                    Id = "7d4c7664-dad3-4fcc-ba43-2489dbc852f9",
                    Name = "Other",
                    NormalizedName = "OTHER"
                },
                new IdentityRole
                {
                    Id = "a5365c24-5610-4038-b6a7-3ce0b29d0f37",
                    Name = "SportAndEntertainment",
                    NormalizedName = "SPORTANDENTERTAINMENT"
                },
                new IdentityRole
                {
                    Id = "62f20c02-61c4-4bca-a957-15f3754fa856",
                    Name = "WatchesAndJewelry",
                    NormalizedName = "WATCHESANDJEWELRY"
                },
                new IdentityRole
                {
                    Id = "5b318526-1716-4248-80de-4783fbe8c00f",
                    Name = "Shipping",
                    NormalizedName = "SHIPPING"
                }
            );
        }
    }
}
