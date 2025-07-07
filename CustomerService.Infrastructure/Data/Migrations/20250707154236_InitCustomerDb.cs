using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerService.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitCustomerDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              schema: "customer",
              table: "Customers",
              columns: new[]
              {
                    "Id", "FirstName", "LastName", "Email", "PhoneNumber",
                    "IDCardNumber", "DateOfBirth", "CreatedAt", "ModifiedAt"
              },
              values: new object[,]
              {
                    {
                        Guid.Parse("f0fccb05-6277-4de5-993f-b2ed3d0e6b7e"),
                        "Jan", "Kowalski", "jan.kowalski@example.com", "123456789",
                        "ABC123456", new DateTime(1990, 5, 20), DateTime.UtcNow, null
                    },
                    {
                        Guid.Parse("092f82a3-2c44-4cdb-863e-a9c3722310e5"),
                        "Anna", "Nowak", "anna.nowak@example.com", "987654321",
                        "XYZ987654", new DateTime(1988, 11, 3), DateTime.UtcNow, null
                    },
                    {
                        Guid.Parse("17c8f9e7-edd0-469f-af77-e66e3ae06a97"),
                        "Tomasz", "Zieliński", "tomasz.zielinski@example.com", "666123789",
                        "LMN456123", new DateTime(1985, 7, 15), DateTime.UtcNow, null
                    }
              });

            migrationBuilder.InsertData(
                schema: "customer",
                table: "Addresses",
                columns: new[]
                {
                    "Id", "Street", "City", "PostalCode", "Country",
                    "CustomerId", "CreatedAt", "ModifiedAt"
                },
                values: new object[,]
                {
                    {
                        Guid.Parse("dd41cbad-cdd8-4158-9d4e-eee4b53deb47"),
                        "ul. Długa 1", "Warszawa", "00-001", "Polska",
                        Guid.Parse("f0fccb05-6277-4de5-993f-b2ed3d0e6b7e"), DateTime.UtcNow, null
                    },
                    {
                        Guid.Parse("a9a7e6d3-0afd-4845-b681-b9109b9d1229"),
                        "ul. Krótka 5", "Kraków", "30-002", "Polska",
                        Guid.Parse("092f82a3-2c44-4cdb-863e-a9c3722310e5"), DateTime.UtcNow, null
                    },
                    {
                        Guid.Parse("c9a81180-b322-4f51-a602-cf0b204bf7e6"),
                        "ul. Spacerowa 10", "Gdańsk", "80-100", "Polska",
                        Guid.Parse("17c8f9e7-edd0-469f-af77-e66e3ae06a97"), DateTime.UtcNow, null
                    }
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "customer",
                table: "Addresses",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    Guid.Parse("dd41cbad-cdd8-4158-9d4e-eee4b53deb47"),
                    Guid.Parse("a9a7e6d3-0afd-4845-b681-b9109b9d1229"),
                    Guid.Parse("c9a81180-b322-4f51-a602-cf0b204bf7e6")
                });

            migrationBuilder.DeleteData(
                schema: "customer",
                table: "Customers",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    Guid.Parse("f0fccb05-6277-4de5-993f-b2ed3d0e6b7e"),
                    Guid.Parse("092f82a3-2c44-4cdb-863e-a9c3722310e5"),
                    Guid.Parse("17c8f9e7-edd0-469f-af77-e66e3ae06a97")
                });
        }
    }
}
