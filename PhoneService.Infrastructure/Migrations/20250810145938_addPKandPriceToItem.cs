using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPKandPriceToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_phones_PhoneId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_items_services_ServiceId",
                table: "items");

            migrationBuilder.DropForeignKey(
                name: "FK_phones_phoneBrands_PhoneBrandId",
                table: "phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_services",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phones",
                table: "phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_phoneBrands",
                table: "phoneBrands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.RenameTable(
                name: "services",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "phones",
                newName: "Phones");

            migrationBuilder.RenameTable(
                name: "phoneBrands",
                newName: "PhoneBrands");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_phones_PhoneBrandId",
                table: "Phones",
                newName: "IX_Phones_PhoneBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_items_ServiceId",
                table: "Items",
                newName: "IX_Items_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_items_PhoneId",
                table: "Items",
                newName: "IX_Items_PhoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneBrands",
                table: "PhoneBrands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Phones_PhoneId",
                table: "Items",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Services_ServiceId",
                table: "Items",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_PhoneBrands_PhoneBrandId",
                table: "Phones",
                column: "PhoneBrandId",
                principalTable: "PhoneBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Phones_PhoneId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Services_ServiceId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_PhoneBrands_PhoneBrandId",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneBrands",
                table: "PhoneBrands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "services");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "phones");

            migrationBuilder.RenameTable(
                name: "PhoneBrands",
                newName: "phoneBrands");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "items");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_PhoneBrandId",
                table: "phones",
                newName: "IX_phones_PhoneBrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ServiceId",
                table: "items",
                newName: "IX_items_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_PhoneId",
                table: "items",
                newName: "IX_items_PhoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_services",
                table: "services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phones",
                table: "phones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_phoneBrands",
                table: "phoneBrands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_items_phones_PhoneId",
                table: "items",
                column: "PhoneId",
                principalTable: "phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_items_services_ServiceId",
                table: "items",
                column: "ServiceId",
                principalTable: "services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_phones_phoneBrands_PhoneBrandId",
                table: "phones",
                column: "PhoneBrandId",
                principalTable: "phoneBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
