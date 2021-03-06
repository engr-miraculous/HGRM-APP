﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HGRM.Models;

namespace HGRM.Migrations
{
    [DbContext(typeof(HGRMHomePageContext))]
    [Migration("20170716130330_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HGRM.Data.HomePage", b =>
                {
                    b.Property<int>("homePageid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Febuary");

                    b.Property<string>("January");

                    b.Property<string>("april");

                    b.Property<string>("august");

                    b.Property<string>("december");

                    b.Property<string>("july");

                    b.Property<string>("june");

                    b.Property<string>("march");

                    b.Property<string>("may");

                    b.Property<string>("november");

                    b.Property<string>("october");

                    b.Property<string>("september");

                    b.Property<string>("welcomeBody");

                    b.Property<string>("welcomeTitle");

                    b.HasKey("homePageid");

                    b.ToTable("HomePage");
                });
        }
    }
}
