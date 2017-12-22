using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HGRM.Models;

namespace HGRM.Migrations
{
    [DbContext(typeof(HGRMHomePageContext))]
    [Migration("20170920150639_obadiahAdded")]
    partial class obadiahAdded
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

            modelBuilder.Entity("HGRM.Models.MNB.MbnAudioMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Minister");

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("MbnAudioMessages");
                });

            modelBuilder.Entity("HGRM.Models.MNB.MbnPdfMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("MbnPdfMessages");
                });

            modelBuilder.Entity("HGRM.Models.OBADIAH.ObadiahAudioMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Minister");

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("ObadiahAudioMessages");
                });

            modelBuilder.Entity("HGRM.Models.OBADIAH.ObadiahPdfMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("ObadiahPdfMessages");
                });

            modelBuilder.Entity("HGRM.Models.tts.TtsAudioMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Minister");

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("TtsAudioMessages");
                });

            modelBuilder.Entity("HGRM.Models.tts.TtsPdfMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("TtsPdfMessages");
                });

            modelBuilder.Entity("HGRM.Models.ywavi.YwaviAudioMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Minister");

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("YwaviAudioMessages");
                });

            modelBuilder.Entity("HGRM.Models.ywavi.YwaviPdfMessages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.Property<string>("url");

                    b.HasKey("ID");

                    b.ToTable("YwaviPdfMessages");
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
