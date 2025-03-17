﻿// <auto-generated />
using System;
using ExperienceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExperienceAPI.Models.Discount", b =>
                {
                    b.Property<int>("ExperienceID_FK")
                        .HasColumnType("int");

                    b.Property<int>("GroupSize")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceAfterDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExperienceID_FK", "GroupSize");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceID"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProviderID")
                        .HasColumnType("int");

                    b.Property<int>("ProviderID_FK")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienceID");

                    b.HasIndex("ProviderID");

                    b.HasIndex("ProviderID_FK");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Guest", b =>
                {
                    b.Property<int>("GuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuestID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestID");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("ExperienceAPI.Models.GuestSharedExperience", b =>
                {
                    b.Property<int>("ShareExperienceID")
                        .HasColumnType("int");

                    b.Property<int>("GuestID")
                        .HasColumnType("int");

                    b.HasKey("ShareExperienceID", "GuestID");

                    b.HasIndex("GuestID");

                    b.ToTable("GuestSharedExperiences");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Provider", b =>
                {
                    b.Property<int>("ProviderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderID"));

                    b.Property<string>("BusinessPhysicalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TouristicPermit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderID");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("ExperienceID_FK")
                        .HasColumnType("int");

                    b.Property<int>("GroupSize_FK")
                        .HasColumnType("int");

                    b.Property<int>("GuestID")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceAfterDiscount_PK")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationID");

                    b.HasIndex("GuestID");

                    b.HasIndex("ExperienceID_FK", "GroupSize_FK");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("ExperienceAPI.Models.SharedExperience", b =>
                {
                    b.Property<int>("ShareExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShareExperienceID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExperienceID_FK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShareExperienceID");

                    b.HasIndex("ExperienceID_FK");

                    b.ToTable("SharedExperiences");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Discount", b =>
                {
                    b.HasOne("ExperienceAPI.Models.Experience", "Experience")
                        .WithMany("Discounts")
                        .HasForeignKey("ExperienceID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Experience", b =>
                {
                    b.HasOne("ExperienceAPI.Models.Provider", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ProviderID");

                    b.HasOne("ExperienceAPI.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ExperienceAPI.Models.GuestSharedExperience", b =>
                {
                    b.HasOne("ExperienceAPI.Models.Guest", "Guest")
                        .WithMany("GuestSharedExperiences")
                        .HasForeignKey("GuestID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExperienceAPI.Models.SharedExperience", "SharedExperience")
                        .WithMany("GuestSharedExperiences")
                        .HasForeignKey("ShareExperienceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("SharedExperience");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Reservation", b =>
                {
                    b.HasOne("ExperienceAPI.Models.Experience", "Experience")
                        .WithMany("Reservations")
                        .HasForeignKey("ExperienceID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExperienceAPI.Models.Guest", "Guest")
                        .WithMany("Reservations")
                        .HasForeignKey("GuestID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ExperienceAPI.Models.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("ExperienceID_FK", "GroupSize_FK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Experience");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("ExperienceAPI.Models.SharedExperience", b =>
                {
                    b.HasOne("ExperienceAPI.Models.Experience", "Experience")
                        .WithMany("SharedExperiences")
                        .HasForeignKey("ExperienceID_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experience");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Experience", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Reservations");

                    b.Navigation("SharedExperiences");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Guest", b =>
                {
                    b.Navigation("GuestSharedExperiences");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ExperienceAPI.Models.Provider", b =>
                {
                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("ExperienceAPI.Models.SharedExperience", b =>
                {
                    b.Navigation("GuestSharedExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
