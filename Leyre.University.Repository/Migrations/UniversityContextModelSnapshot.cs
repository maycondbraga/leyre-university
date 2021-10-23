﻿// <auto-generated />
using System;
using Leyre.University.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leyre.University.Repository.Migrations
{
    [DbContext(typeof(UniversityContext))]
    partial class UniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leyre.University.Model.Entities.CourseModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID_COURSE");

                    b.Property<int>("Credits")
                        .HasColumnType("int")
                        .HasColumnName("NR_CREDITS");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DS_TITLE");

                    b.HasKey("Id");

                    b.ToTable("TB_COURSE");
                });

            modelBuilder.Entity("Leyre.University.Model.Entities.EnrollmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_ENROLLMENT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("ID_COURSE");

                    b.Property<string>("Grade")
                        .HasColumnType("char")
                        .HasColumnName("DS_GRADE");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("ID_STUDENT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("TB_ENROLLMENT");
                });

            modelBuilder.Entity("Leyre.University.Model.Entities.StudentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_STUDENT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_ENROLLMENT");

                    b.Property<string>("FirstMidName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DS_FIRST_MID_NAME");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DS_LAST_NAME");

                    b.HasKey("Id");

                    b.ToTable("TB_STUDENT");
                });

            modelBuilder.Entity("Leyre.University.Model.Entities.EnrollmentModel", b =>
                {
                    b.HasOne("Leyre.University.Model.Entities.CourseModel", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leyre.University.Model.Entities.StudentModel", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Leyre.University.Model.Entities.CourseModel", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Leyre.University.Model.Entities.StudentModel", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
