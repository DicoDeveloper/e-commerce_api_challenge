using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WAP.E_commerce.Api.Challenge.WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    PostCode = table.Column<string>(maxLength: 15, nullable: true),
                    Street = table.Column<string>(maxLength: 255, nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 255, nullable: false),
                    Complement = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 255, nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERY_TEAMS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 155, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    VehicleLicensePlate = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERY_TEAMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    Number = table.Column<long>(nullable: false),
                    Deliverydate = table.Column<DateTime>(nullable: true),
                    TotalValue = table.Column<string>(nullable: false),
                    DeliveryAddressId = table.Column<long>(nullable: true),
                    DeliveryTeamId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_ADDRESS_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "ADDRESS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERS_DELIVERY_TEAMS_DeliveryTeamId",
                        column: x => x.DeliveryTeamId,
                        principalTable: "DELIVERY_TEAMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS_ITEMS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Active = table.Column<bool>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 155, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_ITEMS_ORDERS_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_DeliveryAddressId",
                table: "ORDERS",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_DeliveryTeamId",
                table: "ORDERS",
                column: "DeliveryTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_ITEMS_OrderId",
                table: "ORDERS_ITEMS",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDERS_ITEMS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "DELIVERY_TEAMS");
        }
    }
}
