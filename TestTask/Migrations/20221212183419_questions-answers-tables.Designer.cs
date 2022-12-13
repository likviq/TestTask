﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.Domain;

#nullable disable

namespace TestTask.Migrations
{
    [DbContext(typeof(testsDBContext))]
    [Migration("20221212183419_questions-answers-tables")]
    partial class questionsanswerstables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TestTask.Domain.Models.Answer", b =>
                {
                    b.Property<int>("IdAnswer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdQuestion")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("QuestionIdQuestion")
                        .HasColumnType("int");

                    b.HasKey("IdAnswer");

                    b.HasIndex("QuestionIdQuestion");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("TestTask.Domain.Models.Question", b =>
                {
                    b.Property<int>("IdQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.HasKey("IdQuestion");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TestTask.Domain.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(37)
                        .HasColumnType("varchar(37)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            Password = "password123",
                            Username = "user1"
                        },
                        new
                        {
                            IdUser = 2,
                            Password = "password123",
                            Username = "user2"
                        });
                });

            modelBuilder.Entity("TestTask.Domain.Models.Answer", b =>
                {
                    b.HasOne("TestTask.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionIdQuestion");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestTask.Domain.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
