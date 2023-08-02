using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupTracker.Migrations
{
    public partial class DatabaseRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Campaigns_CampaignId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CampaignId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CampaignId",
                table: "Players",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Campaigns_CampaignId",
                table: "Players",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "CampaignId");
        }
    }
}
