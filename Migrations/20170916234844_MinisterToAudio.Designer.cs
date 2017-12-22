using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HGRM.Models;

namespace HGRM.Migrations
{
    [DbContext(typeof(HGRMHomePageContext))]
    [Migration("20170916234844_MinisterToAudio")]
    partial class MinisterToAudio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HGRM.Models.HgrmData", b =>
                {
                    b.Property<int>("ID")
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

                    b.HasKey("ID");

                    b.ToTable("HgrmData");
                });

            modelBuilder.Entity("HGRM.Models.hgrmdata.hgrmAudioMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HgrmDataID");

                    b.Property<string>("Minister");

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.HasIndex("HgrmDataID");

                    b.ToTable("hgrmAudioMessage");
                });

            modelBuilder.Entity("HGRM.Models.hgrmdata.hgrmWrittenMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HgrmDataID");

                    b.Property<string>("Sermon");

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.HasIndex("HgrmDataID");

                    b.ToTable("hgrmWrittenMessage");
                });

            modelBuilder.Entity("HGRM.Models.hgrmdata.hgrmAudioMessage", b =>
                {
                    b.HasOne("HGRM.Models.HgrmData", "hgrmData")
                        .WithMany("hgrmAudioMessages")
                        .HasForeignKey("HgrmDataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HGRM.Models.hgrmdata.hgrmWrittenMessage", b =>
                {
                    b.HasOne("HGRM.Models.HgrmData", "hgrmData")
                        .WithMany("hgrmWrittenMessages")
                        .HasForeignKey("HgrmDataID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
