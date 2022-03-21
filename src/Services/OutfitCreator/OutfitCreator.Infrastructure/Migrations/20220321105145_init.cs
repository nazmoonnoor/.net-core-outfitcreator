using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OutfitCreator.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CountryName = table.Column<string>(type: "TEXT", nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WebCategory = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", nullable: true),
                    Frame = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProductGroupId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProductTypeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProductImageId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductImages_ProductImageId",
                        column: x => x.ProductImageId,
                        principalTable: "ProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "Created", "CreatedBy" },
                values: new object[] { new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), "DE", "Germany", new DateTime(2022, 3, 21, 10, 51, 44, 628, DateTimeKind.Utc).AddTicks(5846), null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "Created", "CreatedBy" },
                values: new object[] { new Guid("86fe60fa-06e5-440d-8656-e8abcb56736e"), "FR", "France", new DateTime(2022, 3, 21, 10, 51, 44, 628, DateTimeKind.Utc).AddTicks(6381), null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "Created", "CreatedBy" },
                values: new object[] { new Guid("e77dde38-15a3-4c2a-a66c-6bf063a22d3f"), "UK", "United Kingdom", new DateTime(2022, 3, 21, 10, 51, 44, 628, DateTimeKind.Utc).AddTicks(6385), null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "Created", "CreatedBy" },
                values: new object[] { new Guid("e9132ddd-f121-47ec-8f6f-c92826c2b89b"), "NL", "Netherlands", new DateTime(2022, 3, 21, 10, 51, 44, 628, DateTimeKind.Utc).AddTicks(6387), null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryCode", "CountryName", "Created", "CreatedBy" },
                values: new object[] { new Guid("34c0435a-1473-4a3a-b2bb-3aebcd26b960"), "NO", "Norway", new DateTime(2022, 3, 21, 10, 51, 44, 628, DateTimeKind.Utc).AddTicks(6389), null });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("cd6017a8-33eb-421a-a642-e769d70ecf9f"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(353), null, "WCA02243" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("bcbd6491-3eeb-4069-be99-869600137c6c"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(351), null, "WCA02241" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("2a13b6aa-7fd4-4db9-a022-515938ab9071"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(349), null, "WCA02242" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("b32ed022-7194-4381-b9c4-609a0f202477"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(344), null, "WCA00173" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("c7035d03-111c-4071-a27a-64bbabc53d32"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(342), null, "WCA00172" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("adfa898e-c67a-4a49-a154-bab1bc250d03"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(340), null, "WCA00131" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("21cdad5e-56fb-4fcf-84bb-4c9d53fd4b46"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(338), null, "WCA00132" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("37423833-1ff7-407f-ac86-efbfc0bae2ab"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(296), null, "WCA00121" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("6f9e028c-e2d4-487a-9404-8abe0cd7b9b0"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(294), null, "WCA00122" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("f71a9dbd-8bfd-46a8-9316-1825f9684070"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(292), null, "WCA01153" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("09f0a1bd-77d9-4c76-a915-a49b93aefcbc"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(347), null, "WCA02246" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("060a878b-078d-479e-9d91-6d73b5c6d18b"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(288), null, "WCA01152" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("e688b9fe-0247-4167-90c1-ae5bbbbe2d9c"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(290), null, "WCA01158" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("fd698e16-dcc1-4891-b863-74904446e0d7"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(257), null, "Accessories" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("abb4ee60-2f39-4c07-a0fb-3c156f2159dd"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(274), null, "Sweatshirts" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("a3c7bfdb-23fc-487a-93a7-91f64f49c77c"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(276), null, "Pants" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("cfc310f3-a8da-4f32-972a-6f12bf84199e"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(271), null, "Blouses" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(281), null, "WCA01156" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("0e19d44e-217a-403a-88a5-349e6a7713a7"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(283), null, "WCA01159" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("9a545b7a-bd39-45e8-980e-14e9b51189c6"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(285), null, "WCA01155" });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Created", "CreatedBy", "WebCategory" },
                values: new object[] { new Guid("1cdd9999-0963-49ef-98c4-93d21a3b9d38"), new DateTime(2022, 3, 21, 10, 51, 44, 635, DateTimeKind.Utc).AddTicks(278), null, "Denim" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("72b0b605-e3e0-41ad-8cb5-1ea7ea72bbb4"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2867), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("f408ad8c-1740-439c-a61b-a2d5acd30022"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2811), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("c66d5f67-5f60-48d5-8d9d-9379fbb43460"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2865), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("d7d2e620-8dd8-4f28-a569-48c2130dd70c"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2863), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("af3a007b-8722-4f8c-bb4f-dfdc4e75671c"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2860), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("fa5267c1-d527-4a21-9647-df5bb088716a"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2858), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("1d18b480-765a-401f-8be7-0222e36f908e"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2814), null, "9_16", ".\\public\\images\\random_image.jpg", "higher" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("3ea4bd58-1e8b-4a51-817a-c1e1455110ae"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2808), null, "9_16", ".\\public\\images\\random_image.jpg", "high" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("03e4522c-f894-4f2f-b6be-8049c5961a35"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2796), null, "2_3", ".\\public\\images\\random_image.jpg", "mid" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("31327a0b-14ec-4966-85dd-ee6650cc4569"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2803), null, "9_16", ".\\public\\images\\random_image.jpg", "high" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("825d73b2-d986-49ac-8a51-4bb8d71ca6ce"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2801), null, "2_3", ".\\public\\images\\random_image.jpg", "high" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("bbed4ad2-dd5e-459a-933f-b09e3c5e662a"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2799), null, "2_3", ".\\public\\images\\random_image.jpg", "mid" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("383bce15-be2a-4a40-b288-5e67bd05d359"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2794), null, "2_3", ".\\public\\images\\random_image.jpg", "mid" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("535154ee-66f8-49fc-9d5b-c4f7c3146b29"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2791), null, "1_1", ".\\public\\images\\random_image.jpg", "low" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("d17e519c-99cb-4862-bdcf-3fe92cb457fa"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2788), null, "1_1", ".\\public\\images\\random_image.jpg", "low" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2774), null, "1_1", ".\\public\\images\\random_image.jpg", "low" });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Created", "CreatedBy", "Frame", "ImageUrl", "Resolution" },
                values: new object[] { new Guid("c7bff360-14d7-490e-b6e4-a3a81eccd334"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(2806), null, "9_16", ".\\public\\images\\random_image.jpg", "high" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "TypeName" },
                values: new object[] { new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(8584), null, "Underwear" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "TypeName" },
                values: new object[] { new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(8577), null, "Outerwear" });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "TypeName" },
                values: new object[] { new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"), new DateTime(2022, 3, 21, 10, 51, 44, 636, DateTimeKind.Utc).AddTicks(8586), null, "Accessories" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("c2fe22a1-fbe9-412a-b841-8c8d1debbcc5"), "06.04.101.1636", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(4975), null, "nunc viverra dapibus nulla", 1, true, null, 33.45f, new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"), new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("677f22be-84c8-4b82-b5cb-97b2d76e386d"), "64.04.151.1434", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6976), null, "nascetur ridiculus mus vivamus vestibulum", 2, true, null, 31.45f, new Guid("adfa898e-c67a-4a49-a154-bab1bc250d03"), new Guid("825d73b2-d986-49ac-8a51-4bb8d71ca6ce"), new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("afb7c30a-3ac7-44ad-adad-986961a3795d"), "32.04.101.1242", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6970), null, "vel pede morbi porttitor lorem", 1, true, null, 32.45f, new Guid("adfa898e-c67a-4a49-a154-bab1bc250d03"), new Guid("31327a0b-14ec-4966-85dd-ee6650cc4569"), new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("cbfd579d-67fb-4ea4-831c-50e904f4f7ac"), "88.04.551.5536", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6965), null, "sed sagittis nam congue risus", 2, true, null, 14.45f, new Guid("21cdad5e-56fb-4fcf-84bb-4c9d53fd4b46"), new Guid("c7bff360-14d7-490e-b6e4-a3a81eccd334"), new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("f27e1dcd-769e-415d-8394-920ccea16d23"), "46.04.101.4566", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6959), null, "erat tortor sollicitudin mi sit", 2, true, null, 11.45f, new Guid("21cdad5e-56fb-4fcf-84bb-4c9d53fd4b46"), new Guid("3ea4bd58-1e8b-4a51-817a-c1e1455110ae"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("ee48ebde-5d1b-4f96-9ef7-7e3cb3d18198"), "12.04.101.1786", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6949), null, "quam pede lobortis ligula sit", 2, true, null, 22.45f, new Guid("37423833-1ff7-407f-ac86-efbfc0bae2ab"), new Guid("f408ad8c-1740-439c-a61b-a2d5acd30022"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("8d908fff-bb3e-4409-9d34-0c273dbba978"), "66.04.101.8536", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6944), null, "lobortis est phasellus sit amet", 2, true, null, 51.45f, new Guid("37423833-1ff7-407f-ac86-efbfc0bae2ab"), new Guid("1d18b480-765a-401f-8be7-0222e36f908e"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("c27cab00-0a99-4499-9f46-75fc790a5d26"), "78.04.101.1854", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6936), null, "odio odio elementum eu", 2, true, null, 21.45f, new Guid("6f9e028c-e2d4-487a-9404-8abe0cd7b9b0"), new Guid("fa5267c1-d527-4a21-9647-df5bb088716a"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("f231250d-cb81-46f0-b165-45a73bf3986c"), "07.04.151.1652", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6123), null, "phasellus in felis donec", 2, true, null, 11.45f, new Guid("6f9e028c-e2d4-487a-9404-8abe0cd7b9b0"), new Guid("af3a007b-8722-4f8c-bb4f-dfdc4e75671c"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("ad2e0506-5767-44f3-836f-708b434cf4a9"), "07.04.101.1566", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6116), null, "quis justo maecenas rhoncus", 1, true, null, 51.45f, new Guid("9a545b7a-bd39-45e8-980e-14e9b51189c6"), new Guid("d7d2e620-8dd8-4f28-a569-48c2130dd70c"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("b1300036-5526-468f-8b41-058e061dca9e"), "08.08.101.1639", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6110), null, "habitasse platea dictumst etiam", 1, true, null, 39.45f, new Guid("9a545b7a-bd39-45e8-980e-14e9b51189c6"), new Guid("c66d5f67-5f60-48d5-8d9d-9379fbb43460"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("43c76c3d-f9f6-4495-ba43-630293e19632"), "19.04.101.1621", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6104), null, "at vulputate vitae nisl", 1, true, null, 43.45f, new Guid("0e19d44e-217a-403a-88a5-349e6a7713a7"), new Guid("72b0b605-e3e0-41ad-8cb5-1ea7ea72bbb4"), new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("48fcae22-2b4e-4e06-8095-77c8c37b67de"), "42.04.551.2556", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(7697), null, "at diam nam tristique", 2, true, null, 11.45f, new Guid("2a13b6aa-7fd4-4db9-a022-515938ab9071"), new Guid("d17e519c-99cb-4862-bdcf-3fe92cb457fa"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("a046d3f9-c358-4a14-9047-2e70c1deceb1"), "52.04.101.4535", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(7688), null, "facilisi cras non velit nec", 2, true, null, 21.45f, new Guid("09f0a1bd-77d9-4c76-a915-a49b93aefcbc"), new Guid("535154ee-66f8-49fc-9d5b-c4f7c3146b29"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("4eb05499-7eb0-4302-8f6a-eca03a071788"), "15.04.101.1543", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(7682), null, "orci luctus et ultrices posuere", 2, true, null, 22.45f, new Guid("09f0a1bd-77d9-4c76-a915-a49b93aefcbc"), new Guid("383bce15-be2a-4a40-b288-5e67bd05d359"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("c664f7f4-baff-4dd1-98c9-1f75194d99e6"), "01.04.101.1233", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6097), null, "platea dictumst aliquam augue quam", 1, true, null, 12.45f, new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"), new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("550051aa-6774-4035-ae1c-c4ed0986b687"), "03.04.101.1635", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6081), null, "volutpat convallis morbi odio", 1, true, null, 23.45f, new Guid("0e19d44e-217a-403a-88a5-349e6a7713a7"), new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("8b164803-8ab7-4dff-87af-01fbe9814dbd"), "06.04.101.1636", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6071), null, "Tunc viverra dapibus nulla", 2, true, null, 32.45f, new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"), new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"), new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("97c75f22-307f-459a-b2ae-86f1ce87a817"), "34.04.101.4242", new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6981), null, "adipiscing elit proin risus praesent", 2, true, null, 67.45f, new Guid("c7035d03-111c-4071-a27a-64bbabc53d32"), new Guid("bbed4ad2-dd5e-459a-933f-b09e3c5e662a"), new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CountryId", "Created", "CreatedBy", "Description", "Gender", "IsAvailable", "Name", "Price", "ProductGroupId", "ProductImageId", "ProductTypeId" },
                values: new object[] { new Guid("16adccd6-0667-4fbe-a478-27c0cf541363"), "52.04.122.8536", null, new DateTime(2022, 3, 21, 10, 51, 44, 633, DateTimeKind.Utc).AddTicks(6987), null, "aenean sit amet justo morbi", 2, true, null, 56.45f, new Guid("c7035d03-111c-4071-a27a-64bbabc53d32"), new Guid("03e4522c-f894-4f2f-b6be-8049c5961a35"), new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryId",
                table: "Products",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductImageId",
                table: "Products",
                column: "ProductImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
