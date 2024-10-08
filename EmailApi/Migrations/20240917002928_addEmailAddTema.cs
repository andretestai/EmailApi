﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailApi.Migrations
{
    /// <inheritdoc />
    public partial class addEmailAddTema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Assunto = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email_Rementente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email_Destinatario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Remetente = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    Data_Envio = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    Favorito = table.Column<int>(type: "NUMBER(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Email", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Tema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", maxLength: 1, nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tema = table.Column<int>(type: "NUMBER(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Tema", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Email");

            migrationBuilder.DropTable(
                name: "TB_Tema");
        }
    }
}
