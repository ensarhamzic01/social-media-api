﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaAPI.Migrations
{
    public partial class SeenAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 50, 156, 61, 75, 148, 71, 156, 59, 162, 91, 91, 37, 239, 50, 54, 227, 98, 232, 29, 235, 189, 143, 23, 250, 230, 158, 61, 28, 11, 219, 246, 18, 70, 251, 151, 137, 129, 229, 233, 88, 235, 49, 46, 234, 182, 188, 155, 59, 111, 11, 147, 107, 113, 145, 157, 179, 84, 33, 15, 44, 242, 71, 172, 245 }, new byte[] { 141, 84, 73, 18, 127, 152, 229, 70, 85, 40, 255, 84, 10, 232, 101, 136, 137, 48, 86, 172, 36, 10, 57, 59, 85, 94, 6, 144, 219, 152, 48, 78, 207, 129, 128, 87, 182, 242, 159, 242, 52, 34, 55, 191, 211, 47, 130, 238, 233, 46, 63, 73, 251, 51, 176, 242, 135, 138, 151, 220, 34, 100, 92, 53, 140, 109, 215, 149, 152, 169, 64, 93, 174, 243, 190, 153, 202, 95, 203, 223, 220, 144, 155, 179, 220, 153, 23, 61, 109, 109, 51, 60, 246, 28, 14, 226, 195, 152, 152, 139, 106, 64, 230, 253, 225, 188, 130, 226, 3, 99, 21, 203, 102, 223, 163, 171, 144, 255, 253, 252, 184, 42, 238, 204, 211, 202, 221, 174 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 76, 135, 58, 71, 102, 104, 216, 215, 53, 108, 107, 8, 93, 100, 223, 190, 250, 202, 70, 255, 192, 246, 175, 171, 211, 191, 210, 185, 199, 167, 95, 66, 219, 147, 56, 169, 196, 70, 208, 69, 201, 179, 12, 133, 55, 60, 112, 47, 215, 35, 79, 139, 66, 5, 234, 165, 216, 179, 139, 150, 150, 28, 98, 105 }, new byte[] { 211, 175, 48, 106, 28, 157, 14, 61, 23, 58, 140, 62, 101, 114, 255, 173, 61, 230, 24, 203, 190, 198, 234, 151, 38, 253, 217, 225, 219, 31, 207, 47, 139, 91, 78, 213, 74, 188, 53, 26, 50, 204, 213, 26, 99, 248, 29, 154, 192, 28, 35, 126, 167, 50, 127, 187, 35, 188, 156, 82, 165, 205, 121, 19, 80, 54, 24, 209, 179, 61, 57, 21, 85, 195, 134, 35, 210, 38, 92, 176, 84, 24, 176, 52, 134, 161, 67, 3, 141, 174, 156, 13, 52, 15, 98, 17, 23, 199, 18, 50, 24, 113, 186, 101, 61, 160, 173, 44, 245, 149, 251, 140, 245, 234, 189, 63, 205, 84, 79, 232, 89, 91, 166, 1, 78, 77, 34, 187 } });
        }
    }
}
