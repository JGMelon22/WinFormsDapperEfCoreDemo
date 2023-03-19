﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Infrastructure;
using WinFormsDapperDemo.Data;

#nullable disable

namespace WinFormsDapperDemo.Migrations;

[DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PessoaTelefone", b =>
                {
                    b.Property<int>("PessoasPessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TelefonesTelefoneId")
                        .HasColumnType("int");

                    b.HasKey("PessoasPessoaId", "TelefonesTelefoneId");

                    b.HasIndex("TelefonesTelefoneId");

                    b.ToTable("PessoaTelefone");
                });

            modelBuilder.Entity("WinFormsDapperDemo.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PessoaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("PessoaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WinFormsDapperDemo.Models.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TelefoneId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TelefoneId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("TelefoneTexto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TelefoneTexto");

                    b.HasKey("TelefoneId");

                    b.HasIndex("TelefoneId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("PessoaTelefone", b =>
                {
                    b.HasOne("WinFormsDapperDemo.Models.Pessoa", null)
                        .WithMany()
                        .HasForeignKey("PessoasPessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WinFormsDapperDemo.Models.Telefone", null)
                        .WithMany()
                        .HasForeignKey("TelefonesTelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
