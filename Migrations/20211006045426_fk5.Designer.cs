﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorBuddy_MCsoft.Data;

namespace TutorBuddy_MCsoft.Migrations
{
    [DbContext(typeof(TutorBuddy_MCsoftContext))]
    [Migration("20211006045426_fk5")]
    partial class fk5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.GroupBooking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("SessionID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("SessionID");

                    b.ToTable("GroupBooking");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.IndividualBooking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("SessionID")
                        .HasColumnType("int");

                    b.Property<int?>("StudentNumber")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("SessionID");

                    b.HasIndex("StudentNumber");

                    b.ToTable("IndividualBookings");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Module", b =>
                {
                    b.Property<int>("ModuleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ModuleCode")
                        .HasColumnType("longtext");

                    b.Property<string>("ModuleName")
                        .HasColumnType("longtext");

                    b.HasKey("ModuleID");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.ModulesTutored", b =>
                {
                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int>("ModuleID")
                        .HasColumnType("int");

                    b.HasKey("StudentNumber", "ModuleID");

                    b.HasIndex("ModuleID");

                    b.ToTable("ModulesTutored");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Resource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<int?>("ModuleID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ModuleID");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<int?>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TutorStudentNumber")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("StudentNumber");

                    b.HasIndex("TutorStudentNumber");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Session", b =>
                {
                    b.Property<int>("SessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AmountOfPeople")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ModuleTutorModuleID")
                        .HasColumnType("int");

                    b.Property<int?>("ModuleTutorStudentNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SessionID");

                    b.HasIndex("ModuleTutorStudentNumber", "ModuleTutorModuleID");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Student", b =>
                {
                    b.Property<int>("StudentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("LevelOfStudy")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("StudentNumber");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.StudentGroupBooking", b =>
                {
                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int>("BookingID")
                        .HasColumnType("int");

                    b.HasKey("StudentNumber", "BookingID");

                    b.HasIndex("BookingID");

                    b.ToTable("StudentGroupBooking");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Tutor", b =>
                {
                    b.Property<int>("StudentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("AvgRating")
                        .HasColumnType("double");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<double>("Fee")
                        .HasColumnType("double");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("StudentNumber");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.GroupBooking", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.IndividualBooking", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID");

                    b.HasOne("TutorBuddy_MCsoft.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentNumber");

                    b.Navigation("Session");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.ModulesTutored", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.Module", "Module")
                        .WithMany("ModulesTutored")
                        .HasForeignKey("ModuleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorBuddy_MCsoft.Models.Tutor", "Tutor")
                        .WithMany("ModulesTutored")
                        .HasForeignKey("StudentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Resource", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleID");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Review", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentNumber");

                    b.HasOne("TutorBuddy_MCsoft.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorStudentNumber");

                    b.Navigation("Student");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Session", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.ModulesTutored", "ModuleTutor")
                        .WithMany()
                        .HasForeignKey("ModuleTutorStudentNumber", "ModuleTutorModuleID");

                    b.Navigation("ModuleTutor");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.StudentGroupBooking", b =>
                {
                    b.HasOne("TutorBuddy_MCsoft.Models.GroupBooking", "Booking")
                        .WithMany("Students")
                        .HasForeignKey("BookingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TutorBuddy_MCsoft.Models.Student", "Student")
                        .WithMany("Bookings")
                        .HasForeignKey("StudentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.GroupBooking", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Module", b =>
                {
                    b.Navigation("ModulesTutored");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Student", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("TutorBuddy_MCsoft.Models.Tutor", b =>
                {
                    b.Navigation("ModulesTutored");
                });
#pragma warning restore 612, 618
        }
    }
}
