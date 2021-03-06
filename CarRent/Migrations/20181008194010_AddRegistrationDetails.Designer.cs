﻿// <auto-generated />
using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRent.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181008194010_AddRegistrationDetails")]
    partial class AddRegistrationDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRent.Models.Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MakeName");

                    b.Property<string>("ModelName");

                    b.Property<string>("ModelSeries");

                    b.Property<string>("RegistrationCountry");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int>("RegistrationYear");

                    b.HasKey("ID");

                    b.ToTable("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
