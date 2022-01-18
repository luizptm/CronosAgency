using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CronosAgency.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_RoleId1",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_RoleId2",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RoleId2",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Membro",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "João", "" },
                    { 2, "Maria", "" },
                    { 3, "José", "" }
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "Administrador", "Administrador" },
                    { 2, "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF", "Post 1", "POST 1" },
                    { 2, "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF", "Post 2", "POST 2" },
                    { 3, "SDLJFSDJKFSJKFSFJK KJFSDJKF SAKJFSKJF JKDSF JKDSFKJDSF", "Post 3", "POST 3" }
                });

            migrationBuilder.InsertData(
                table: "Servico",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Desenvolvimento", "Desenvolvimento" },
                    { 2, "Design", "Design" },
                    { 3, "Consultoria", "Consultoria" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CreateDate", "Email", "LastTimePasswordChanged", "Name", "Password", "RoleId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admim@cronosagency.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "admin", 1 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CreateDate", "Email", "LastTimePasswordChanged", "Name", "Password", "RoleId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@cronosagency.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "user", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_RoleId",
                table: "Usuario",
                column: "RoleId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_RoleId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DeleteData(
                table: "Membro",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Membro",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Membro",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Servico",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Servico",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Servico",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perfil",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId2",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_RoleId1",
                table: "Usuario",
                column: "RoleId1",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_RoleId2",
                table: "Usuario",
                column: "RoleId2",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
