﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace stable.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("stable.Models.Departments.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("stable.Models.Groups.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupNumber");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("stable.Models.Scores.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Percent");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("stable.Models.StudentScores.StudentScore", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ScoreId");

                    b.Property<int>("StudentId");

                    b.HasKey("id");

                    b.HasIndex("ScoreId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentScores");
                });

            modelBuilder.Entity("stable.Models.Students.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int?>("GroupId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("stable.Models.Subjects.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("SyllabusId");

                    b.HasKey("Id");

                    b.HasIndex("SyllabusId")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("stable.Models.Syllabuses.Syllabus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Semester");

                    b.HasKey("Id");

                    b.ToTable("Syllabuss");
                });

            modelBuilder.Entity("stable.Models.Teachers.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("stable.Models.StudentScores.StudentScore", b =>
                {
                    b.HasOne("stable.Models.Scores.Score", "Score")
                        .WithMany("StudentScores")
                        .HasForeignKey("ScoreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("stable.Models.Students.Student", "Student")
                        .WithMany("StudentScores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stable.Models.Students.Student", b =>
                {
                    b.HasOne("stable.Models.Groups.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("stable.Models.Subjects.Subject", b =>
                {
                    b.HasOne("stable.Models.Syllabuses.Syllabus", "Syllabus")
                        .WithOne("Subject")
                        .HasForeignKey("stable.Models.Subjects.Subject", "SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stable.Models.Teachers.Teacher", b =>
                {
                    b.HasOne("stable.Models.Departments.Department", "Department")
                        .WithMany("Teachers")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}