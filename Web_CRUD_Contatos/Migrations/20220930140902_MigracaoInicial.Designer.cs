﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_CRUD_Contatos.Models;

#nullable disable

namespace Web_CRUD_Contatos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220930140902_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);
                       
            modelBuilder.Entity("Web_CRUD_Contatos.Models.Curso", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cpf");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("datanascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("id");

                    b.ToTable("Curso");
                });
#pragma warning restore 612, 618
        }
    }
}
