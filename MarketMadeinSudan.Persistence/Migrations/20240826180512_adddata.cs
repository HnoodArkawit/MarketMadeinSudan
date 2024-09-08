using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketMadeinSudan.Persistence.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisementss",
                columns: table => new
                {
                    AdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PirceGo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PirceEnd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisementss", x => x.AdvertisementId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    AddressCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailss",
                columns: table => new
                {
                    OrderDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    AddressCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailss", x => x.OrderDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Publisherss",
                columns: table => new
                {
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    ImageCompany = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PdfFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FilePdf = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisherss", x => x.PublishersId);
                });

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    ShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameShipping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressShipping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailShipping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneShipping = table.Column<int>(type: "int", nullable: false),
                    DescriptionShipping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstNameCustoer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCustoer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCustoer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCustoer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCustomer = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.ShippingId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessoriess",
                columns: table => new
                {
                    AccessoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessoriesName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessoriess", x => x.AccessoriesId);
                    table.ForeignKey(
                        name: "FK_Accessoriess_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgriculturalCropss",
                columns: table => new
                {
                    AgriculturalCropsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgriculturalCropsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriculturalCropss", x => x.AgriculturalCropsId);
                    table.ForeignKey(
                        name: "FK_AgriculturalCropss_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aspires",
                columns: table => new
                {
                    AspiresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AspiresName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aspires", x => x.AspiresId);
                    table.ForeignKey(
                        name: "FK_Aspires_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalAndElctronics",
                columns: table => new
                {
                    ElectricalAndElctronicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectricalAndElctronicName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalAndElctronics", x => x.ElectricalAndElctronicId);
                    table.ForeignKey(
                        name: "FK_ElectricalAndElctronics_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fabricss",
                columns: table => new
                {
                    FabricsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricss", x => x.FabricsId);
                    table.ForeignKey(
                        name: "FK_Fabricss_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdProductss",
                columns: table => new
                {
                    HouseholdProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseholdProductsName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdProductss", x => x.HouseholdProductsId);
                    table.ForeignKey(
                        name: "FK_HouseholdProductss_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    OtherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OtherName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.OtherId);
                    table.ForeignKey(
                        name: "FK_Others_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SportAndEntertainments",
                columns: table => new
                {
                    SportAndEntertainmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SportAndEntertainmentName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportAndEntertainments", x => x.SportAndEntertainmentId);
                    table.ForeignKey(
                        name: "FK_SportAndEntertainments_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WatchesAndJewelrys",
                columns: table => new
                {
                    WatchesAndJewelryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WatchesAndJewelryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Pirce = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PictureProduct = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmailCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasruingUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCompany = table.Column<int>(type: "int", nullable: false),
                    NameCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FounderAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchesAndJewelrys", x => x.WatchesAndJewelryId);
                    table.ForeignKey(
                        name: "FK_WatchesAndJewelrys_Publisherss_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publisherss",
                        principalColumn: "PublishersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44c8065a-f4ab-4cdf-b0a7-bdb171c3ca49", "b19bd957-40de-48d3-af69-b109bf2492fc", "Accessories", "ACCESSORIES" },
                    { "5b318526-1716-4248-80de-4783fbe8c00f", "e18381f7-4a55-4813-a8c2-65ffde6982fd", "Shipping", "SHIPPING" },
                    { "62f20c02-61c4-4bca-a957-15f3754fa856", "c64ef773-2533-4e82-930a-c24fb76a33b1", "WatchesAndJewelry", "WATCHESANDJEWELRY" },
                    { "7d4c7664-dad3-4fcc-ba43-2489dbc852f9", "5152ba20-3a02-4d97-9106-9259d5baa908", "Other", "OTHER" },
                    { "a5365c24-5610-4038-b6a7-3ce0b29d0f37", "e694acaa-4afd-43b5-94c2-90526a78f57d", "SportAndEntertainment", "SPORTANDENTERTAINMENT" },
                    { "aa827fc7-9a4e-4d95-88ef-de6d85e3f47e", "c27f2b79-44f9-449d-8125-24a21ab41454", "ElectricalAndElctronic", "ELECTRICALANDELCTRONIC" },
                    { "ad9b70a4-153b-4e6c-b37b-08275a261bf7", "64019174-0437-427d-b750-77d1eb5d92cf", "Aspires", "ASPIRES" },
                    { "cac43a6e-f7bb-4448-baaf-1add431ccbbf", "d2dc6cd3-2c2d-4565-a175-929943eb328b", "User", "USER" },
                    { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "db760f15-bf74-4b24-adf7-a6d911a0393f", "Admin", "ADMIN" },
                    { "dff2d10b-a4c6-4199-8f1d-0ae1316c9129", "7c4d9ae1-d1de-4815-bb10-2468568a73d5", "AgriculturalCrops", "AGRICULTURALCROPS" },
                    { "e7d933cc-fbf0-4622-8a59-8455f8a18b97", "9ece87b8-12fd-4d89-b254-a857ac1e315b", "HouseholdProducts", "HOUSEHOLDPRODUCTS" },
                    { "f42b8ff8-10f4-44a8-ab6c-84a04acd8a76", "7777d7e8-b5de-49ab-ac80-16800da40a10", "Food", "FOOD" },
                    { "f55368f6-2421-4c30-af4a-1288a0e275c0", "a548b16e-4149-40d1-b6d2-ae574986820a", "Fabrics", "FABRICS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "cb7cc11b-5456-4a96-8fd5-6bba3de9a8ed", "sony@systemdotproject.com", true, "System", "Admin", false, null, "SONY@SYSTEMDOTPROJECT.COM", "Sony", "AQAAAAEAACcQAAAAEBV0GF7UzIqIOx7FqcCX1Ectzvvifmx+q8q/lVruwB5e3i/gm2looqnc1eyinbWv5Q==", null, false, "3aee9017-7d51-4cb4-bebc-badf68011ed0", false, "sony" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.CreateIndex(
                name: "IX_Accessoriess_PublishersId",
                table: "Accessoriess",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriculturalCropss_PublishersId",
                table: "AgriculturalCropss",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_Aspires_PublishersId",
                table: "Aspires",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalAndElctronics_PublishersId",
                table: "ElectricalAndElctronics",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabricss_PublishersId",
                table: "Fabricss",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PublishersId",
                table: "Foods",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdProductss_PublishersId",
                table: "HouseholdProductss",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_Others_PublishersId",
                table: "Others",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_SportAndEntertainments_PublishersId",
                table: "SportAndEntertainments",
                column: "PublishersId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchesAndJewelrys_PublishersId",
                table: "WatchesAndJewelrys",
                column: "PublishersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessoriess");

            migrationBuilder.DropTable(
                name: "Advertisementss");

            migrationBuilder.DropTable(
                name: "AgriculturalCropss");

            migrationBuilder.DropTable(
                name: "Aspires");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ElectricalAndElctronics");

            migrationBuilder.DropTable(
                name: "Fabricss");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "HouseholdProductss");

            migrationBuilder.DropTable(
                name: "OrderDetailss");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropTable(
                name: "SportAndEntertainments");

            migrationBuilder.DropTable(
                name: "WatchesAndJewelrys");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Publisherss");
        }
    }
}
