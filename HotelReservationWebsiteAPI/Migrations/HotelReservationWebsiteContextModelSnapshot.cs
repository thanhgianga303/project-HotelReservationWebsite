﻿// <auto-generated />
using HotelReservationWebsiteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelReservationWebsiteAPI.Migrations
{
    [DbContext(typeof(HotelReservationWebsiteContext))]
    partial class HotelReservationWebsiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("HotelReservationWebsiteAPI.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("HotelReservationWebsiteAPI.Models.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("CityID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HotelName")
                        .HasColumnType("TEXT");

                    b.Property<int>("HotelStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberofReservation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("HotelID");

                    b.HasIndex("CityID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("HotelReservationWebsiteAPI.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HotelID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumberOfBeds")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomArea")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomStatus")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomID");

                    b.HasIndex("HotelID");

                    b.HasIndex("RoomCategoryID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HotelReservationWebsiteAPI.Models.RoomCategory", b =>
                {
                    b.Property<int>("RoomCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("RoomCategoryID");

                    b.ToTable("RoomCategories");
                });

            modelBuilder.Entity("HotelReservationWebsiteAPI.Models.Hotel", b =>
                {
                    b.HasOne("HotelReservationWebsiteAPI.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelReservationWebsiteAPI.Models.Room", b =>
                {
                    b.HasOne("HotelReservationWebsiteAPI.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelReservationWebsiteAPI.Models.RoomCategory", "RoomCategory")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
