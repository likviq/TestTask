﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.Domain;

#nullable disable

namespace TestTask.Migrations
{
    [DbContext(typeof(testsDBContext))]
    partial class testsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("IdAnswer");

                    b.HasIndex("QuestionId");

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

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("IdQuestion");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TestTask.Domain.Models.Test", b =>
                {
                    b.Property<int>("IdTest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("IdTest");

                    b.ToTable("Tests");
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

            modelBuilder.Entity("TestUser", b =>
                {
                    b.Property<int>("TestsIdTest")
                        .HasColumnType("int");

                    b.Property<int>("UsersIdUser")
                        .HasColumnType("int");

                    b.HasKey("TestsIdTest", "UsersIdUser");

                    b.HasIndex("UsersIdUser");

                    b.ToTable("TestUser");
                });

            modelBuilder.Entity("TestTask.Domain.Models.Answer", b =>
                {
                    b.HasOne("TestTask.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("TestTask.Domain.Models.Question", b =>
                {
                    b.HasOne("TestTask.Domain.Models.Test", "Tests")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("TestUser", b =>
                {
                    b.HasOne("TestTask.Domain.Models.Test", null)
                        .WithMany()
                        .HasForeignKey("TestsIdTest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestTask.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersIdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestTask.Domain.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("TestTask.Domain.Models.Test", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
