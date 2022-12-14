﻿// <auto-generated />
using FLAMOM_SeniorProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FLAMOM_SeniorProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.DentalOfficesVisited", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("DentalOfficesVisited");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.HeardAbout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HeardAboutHow")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("HeardAbouts");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.KindOfHealthcare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("KindOfHealthcare");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.OtherReasonsForVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OtherReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("OtherReasonsForVisit");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AttendBefore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emrgncy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodStamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoToOffice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hispanic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseIncome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insurance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobSituation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastSixMnths")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastVisit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LengthOfPain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LevelOfSchool")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainRsn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainRsnLstVst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MouthPain")
                        .HasColumnType("bit");

                    b.Property<string>("OtherAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherAnswer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverallHealth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeopleAtHome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServedInMil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeethGums")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeToTravel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsualCare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsualJobs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WicProg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.PatientRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientRace");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.ReasonForVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("ReasonsForVisit");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.Tobacco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Tobacco");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.DentalOfficesVisited", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("DentalOfficesVisited")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.HeardAbout", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("HeardAbouts")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.KindOfHealthcare", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("KindOfHealthcare")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.OtherReasonsForVisit", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("OtherReasonsForVisit")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.PatientRace", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("PatientRace")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.ReasonForVisit", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("ReasonsForVisit")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.Tobacco", b =>
                {
                    b.HasOne("FLAMOM_SeniorProject.Data.Patient", "Patient")
                        .WithMany("Tobaccos")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("FLAMOM_SeniorProject.Data.Patient", b =>
                {
                    b.Navigation("DentalOfficesVisited");

                    b.Navigation("HeardAbouts");

                    b.Navigation("KindOfHealthcare");

                    b.Navigation("OtherReasonsForVisit");

                    b.Navigation("PatientRace");

                    b.Navigation("ReasonsForVisit");

                    b.Navigation("Tobaccos");
                });
#pragma warning restore 612, 618
        }
    }
}
