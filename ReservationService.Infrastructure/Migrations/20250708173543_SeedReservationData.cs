﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationService.Infrastructure.Migrations
{
    public partial class SeedReservationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "reservation",
                table: "Reservations",
                columns: new[]
                {
                    "Id", "CustomerId", "StartDate", "EndDate", "RoomNumber", "Status",
                    "CreatedAt", "ModifiedAt", "NumberOfGuests", "Price", "DiscountId"
                },
                values: new object[]
                {
                    new Guid("0bc77d8c-3742-4635-90fc-ee13ff5f899e"),
                    new Guid("092F82A3-2C44-4CDB-863E-A9C3722310E5"),
                    new DateTime(2025, 7, 10),
                    new DateTime(2025, 7, 15),
                    101,
                    "Pending",
                    new DateTime(2025, 7, 7, 21, 0, 0),
                    null,
                    2,
                    1500.00m,
                    new Guid("a7382d56-48e1-449b-b59e-087867243daa") // FAMILY15
                });

            migrationBuilder.InsertData(
                schema: "reservation",
                table: "Reservations",
                columns: new[]
                {
                    "Id", "CustomerId", "StartDate", "EndDate", "RoomNumber", "Status",
                    "CreatedAt", "ModifiedAt", "NumberOfGuests", "Price", "DiscountId"
                },
                values: new object[]
                {
                    new Guid("6e4a3e35-16e2-4a83-9e95-f0f8707d3c75"),
                    new Guid("F0FCCB05-6277-4DE5-993F-B2ED3D0E6B7E"),
                    new DateTime(2025, 8, 5),
                    new DateTime(2025, 8, 12),
                    203,
                    "Confirmed",
                    new DateTime(2025, 7, 7, 21, 0, 0),
                    null,
                    1,
                    2100.00m,
                    new Guid("a7958029-27af-435f-95fb-8be1b6ac175c") // VIP20
                });

            migrationBuilder.InsertData(
                schema: "reservation",
                table: "Reservations",
                columns: new[]
                {
                    "Id", "CustomerId", "StartDate", "EndDate", "RoomNumber", "Status",
                    "CreatedAt", "ModifiedAt", "NumberOfGuests", "Price", "DiscountId"
                },
                values: new object[]
                {
                    new Guid("3c23f905-8dc5-4ece-81d0-72a3dfe8eba6"),
                    new Guid("17C8F9E7-EDD0-469F-AF77-E66E3AE06A97"),
                    new DateTime(2025, 9, 1),
                    new DateTime(2025, 9, 3),
                    305,
                    "Cancelled",
                    new DateTime(2025, 7, 7, 21, 0, 0),
                    null,
                    3,
                    850.00m,
                    new Guid("32ee00b4-fd42-424d-aff2-a8f9bd50811e") // SUMMER10
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "reservation",
                table: "Reservations",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    new Guid("0bc77d8c-3742-4635-90fc-ee13ff5f899e"),
                    new Guid("6e4a3e35-16e2-4a83-9e95-f0f8707d3c75"),
                    new Guid("3c23f905-8dc5-4ece-81d0-72a3dfe8eba6")
                });
        }
    }
}
