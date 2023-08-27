﻿// <auto-generated />
using APIService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIService.Migrations
{
    [DbContext(typeof(APIServiceContext))]
    partial class APIServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIService.Models.APIDefinition", b =>
                {
                    b.Property<string>("Ksuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ksuid");

                    b.ToTable("APIDefinitions");
                });

            modelBuilder.Entity("APIService.Models.APIField", b =>
                {
                    b.Property<string>("Ksuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("APIDefinitionKsuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ksuid");

                    b.HasIndex("APIDefinitionKsuid");

                    b.ToTable("APIFields");
                });

            modelBuilder.Entity("APIService.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIService.Models.APIField", b =>
                {
                    b.HasOne("APIService.Models.APIDefinition", "APIDefinition")
                        .WithMany("APIFields")
                        .HasForeignKey("APIDefinitionKsuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("APIDefinition");
                });

            modelBuilder.Entity("APIService.Models.APIDefinition", b =>
                {
                    b.Navigation("APIFields");
                });
#pragma warning restore 612, 618
        }
    }
}
