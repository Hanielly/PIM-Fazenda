﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechFarmSystem.Data;

#nullable disable

namespace TechFarmSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241017194600_AjusteTabelaProducao")]
    partial class AjusteTabelaProducao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("TechFarmSystem.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelAcesso")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("TechFarmSystem.Models.Producao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataProducao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomedoProduto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantidadeProduzida")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Producao");
                });
#pragma warning restore 612, 618
        }
    }
}
