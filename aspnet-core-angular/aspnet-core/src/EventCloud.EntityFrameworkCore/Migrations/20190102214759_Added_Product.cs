using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventCloud.Migrations
{
    public partial class Added_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionalMessage = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CostPrice = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CubicWeight = table.Column<double>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 2048, nullable: true),
                    DescriptionEmall = table.Column<string>(maxLength: 300, nullable: true),
                    EAN = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    IncludedItems = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    MinimumStock = table.Column<int>(nullable: false),
                    MinimumStockAlert = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    NCM = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Shortcut = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Warranty = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProduct", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppProduct");
        }
    }
}
