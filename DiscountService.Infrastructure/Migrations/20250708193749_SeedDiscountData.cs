using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiscountData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
       schema: "discount",
       table: "Discounts",
       columns: new[]
       {
            "Id", "Code", "Percentage", "IsActive", "ValidFrom", "ValidTo",
            "Description", "CreatedAt", "ModifiedAt"
       },
       values: new object[,]
       {
            {
                new Guid("32ee00b4-fd42-424d-aff2-a8f9bd50811e"),
                "SUMMER10", 10m, true,
                new DateTime(2025, 7, 1), new DateTime(2025, 7, 31),
                "10% zniżki na lato", DateTime.UtcNow, null
            },
            {
                new Guid("b63ac34e-95b2-4a18-9d04-453391522a70"),
                "WELCOME5", 5m, true,
                new DateTime(2025, 6, 1), new DateTime(2025, 12, 31),
                "5% zniżki dla nowych klientów", DateTime.UtcNow, null
            },
            {
                new Guid("a7958029-27af-435f-95fb-8be1b6ac175c"),
                "VIP20", 20m, false,
                new DateTime(2025, 1, 1), new DateTime(2025, 1, 31),
                "Ekskluzywna oferta VIP", DateTime.UtcNow, null
            }
       });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
       schema: "discount",
       table: "Discounts",
       keyColumn: "Id",
       keyValues: new object[]
       {
            new Guid("32ee00b4-fd42-424d-aff2-a8f9bd50811e"),
            new Guid("b63ac34e-95b2-4a18-9d04-453391522a70"),
            new Guid("a7958029-27af-435f-95fb-8be1b6ac175c")
       });
        }
    }
}
