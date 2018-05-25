using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EventCloud.Migrations
{
    public partial class Added_EventId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "AppSupports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "AppSpeakers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "AppMaps",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "AppAbouts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppSupports_EventId",
                table: "AppSupports",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSpeakers_EventId",
                table: "AppSpeakers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMaps_EventId",
                table: "AppMaps",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAbouts_EventId",
                table: "AppAbouts",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAbouts_AppEvents_EventId",
                table: "AppAbouts",
                column: "EventId",
                principalTable: "AppEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppMaps_AppEvents_EventId",
                table: "AppMaps",
                column: "EventId",
                principalTable: "AppEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSpeakers_AppEvents_EventId",
                table: "AppSpeakers",
                column: "EventId",
                principalTable: "AppEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppSupports_AppEvents_EventId",
                table: "AppSupports",
                column: "EventId",
                principalTable: "AppEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAbouts_AppEvents_EventId",
                table: "AppAbouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMaps_AppEvents_EventId",
                table: "AppMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSpeakers_AppEvents_EventId",
                table: "AppSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppSupports_AppEvents_EventId",
                table: "AppSupports");

            migrationBuilder.DropIndex(
                name: "IX_AppSupports_EventId",
                table: "AppSupports");

            migrationBuilder.DropIndex(
                name: "IX_AppSpeakers_EventId",
                table: "AppSpeakers");

            migrationBuilder.DropIndex(
                name: "IX_AppMaps_EventId",
                table: "AppMaps");

            migrationBuilder.DropIndex(
                name: "IX_AppAbouts_EventId",
                table: "AppAbouts");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AppSupports");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AppSpeakers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AppMaps");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AppAbouts");
        }
    }
}
