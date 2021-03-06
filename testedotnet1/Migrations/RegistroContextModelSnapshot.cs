﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testedotnet1.Data;

namespace testedotnet1.Migrations
{
    [DbContext(typeof(RegistroContext))]
    partial class RegistroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("testedotnet1.Models.Desenvolvedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Desenvolvedores");
                });

            modelBuilder.Entity("testedotnet1.Models.Hora_trabalhada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datafim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datainicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("desenvolvedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("desenvolvedorId");

                    b.ToTable("Horas_Trabalhadas");
                });

            modelBuilder.Entity("testedotnet1.Models.Hora_trabalhada", b =>
                {
                    b.HasOne("testedotnet1.Models.Desenvolvedor", "desenvolvedor")
                        .WithMany()
                        .HasForeignKey("desenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("desenvolvedor");
                });
#pragma warning restore 612, 618
        }
    }
}
