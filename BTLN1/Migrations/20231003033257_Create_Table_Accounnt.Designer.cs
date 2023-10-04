﻿// <auto-generated />
using BTLN1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTLN1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231003033257_Create_Table_Accounnt")]
    partial class Create_Table_Accounnt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("BTLN1.Models.Account", b =>
                {
                    b.Property<string>("AccountID")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountBank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountCCCD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountEnd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountSex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountStart")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HopDongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LuongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ViTriAccountID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccountID");

                    b.HasIndex("HopDongID");

                    b.HasIndex("LuongID");

                    b.HasIndex("ViTriAccountID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("BTLN1.Models.AccountViTri", b =>
                {
                    b.Property<string>("ViTriAccountID")
                        .HasColumnType("TEXT");

                    b.Property<string>("VitriAccount")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ViTriAccountID");

                    b.ToTable("AccountViTri");
                });

            modelBuilder.Entity("BTLN1.Models.Ceo", b =>
                {
                    b.Property<string>("CeoID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoBank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoCCCD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoEnd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoSex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CeoStart")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HopDongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LuongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ViTriCeoID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CeoID");

                    b.HasIndex("HopDongID");

                    b.HasIndex("LuongID");

                    b.HasIndex("ViTriCeoID");

                    b.ToTable("Ceo");
                });

            modelBuilder.Entity("BTLN1.Models.CeoViTri", b =>
                {
                    b.Property<string>("ViTriCeoID")
                        .HasColumnType("TEXT");

                    b.Property<string>("VitriCeo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ViTriCeoID");

                    b.ToTable("CeoViTri");
                });

            modelBuilder.Entity("BTLN1.Models.CongNhan", b =>
                {
                    b.Property<string>("MaCongNhan")
                        .HasColumnType("TEXT");

                    b.Property<string>("Luong")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhongBan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ViTri")
                        .HasColumnType("TEXT");

                    b.HasKey("MaCongNhan");

                    b.ToTable("CongNhan");
                });

            modelBuilder.Entity("BTLN1.Models.HopDong", b =>
                {
                    b.Property<string>("HopDongID")
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeHopDong")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("HopDongID");

                    b.ToTable("HopDong");
                });

            modelBuilder.Entity("BTLN1.Models.Luong", b =>
                {
                    b.Property<string>("LuongID")
                        .HasColumnType("TEXT");

                    b.Property<string>("SoLuong")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LuongID");

                    b.ToTable("Luong");
                });

            modelBuilder.Entity("BTLN1.Models.Sale", b =>
                {
                    b.Property<string>("SaleID")
                        .HasColumnType("TEXT");

                    b.Property<string>("HopDongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LuongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleBank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleCCCD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleEnd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SalePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleSex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SaleStart")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ViTriSaleID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SaleID");

                    b.HasIndex("HopDongID");

                    b.HasIndex("LuongID");

                    b.HasIndex("ViTriSaleID");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("BTLN1.Models.SaleViTri", b =>
                {
                    b.Property<string>("ViTriSaleID")
                        .HasColumnType("TEXT");

                    b.Property<string>("VitriSale")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ViTriSaleID");

                    b.ToTable("SaleViTri");
                });

            modelBuilder.Entity("BTLN1.Models.Staff", b =>
                {
                    b.Property<string>("StaffID")
                        .HasColumnType("TEXT");

                    b.Property<string>("HopDongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LuongID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffBank")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffCCCD")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffEnd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffSex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffStart")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ViTriStaffID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StaffID");

                    b.HasIndex("HopDongID");

                    b.HasIndex("LuongID");

                    b.HasIndex("ViTriStaffID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("BTLN1.Models.StaffViTri", b =>
                {
                    b.Property<string>("ViTriStaffID")
                        .HasColumnType("TEXT");

                    b.Property<string>("VitriStaff")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ViTriStaffID");

                    b.ToTable("StaffViTri");
                });

            modelBuilder.Entity("BTLN1.Models.Account", b =>
                {
                    b.HasOne("BTLN1.Models.HopDong", "HopDong")
                        .WithMany()
                        .HasForeignKey("HopDongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.Luong", "Luong")
                        .WithMany()
                        .HasForeignKey("LuongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.AccountViTri", "AccountViTri")
                        .WithMany()
                        .HasForeignKey("ViTriAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountViTri");

                    b.Navigation("HopDong");

                    b.Navigation("Luong");
                });

            modelBuilder.Entity("BTLN1.Models.Ceo", b =>
                {
                    b.HasOne("BTLN1.Models.HopDong", "HopDong")
                        .WithMany()
                        .HasForeignKey("HopDongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.Luong", "Luong")
                        .WithMany()
                        .HasForeignKey("LuongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.CeoViTri", "CeoViTri")
                        .WithMany()
                        .HasForeignKey("ViTriCeoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CeoViTri");

                    b.Navigation("HopDong");

                    b.Navigation("Luong");
                });

            modelBuilder.Entity("BTLN1.Models.Sale", b =>
                {
                    b.HasOne("BTLN1.Models.HopDong", "HopDong")
                        .WithMany()
                        .HasForeignKey("HopDongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.Luong", "Luong")
                        .WithMany()
                        .HasForeignKey("LuongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.SaleViTri", "SaleViTri")
                        .WithMany()
                        .HasForeignKey("ViTriSaleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HopDong");

                    b.Navigation("Luong");

                    b.Navigation("SaleViTri");
                });

            modelBuilder.Entity("BTLN1.Models.Staff", b =>
                {
                    b.HasOne("BTLN1.Models.HopDong", "HopDong")
                        .WithMany()
                        .HasForeignKey("HopDongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.Luong", "Luong")
                        .WithMany()
                        .HasForeignKey("LuongID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTLN1.Models.StaffViTri", "StaffViTri")
                        .WithMany()
                        .HasForeignKey("ViTriStaffID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HopDong");

                    b.Navigation("Luong");

                    b.Navigation("StaffViTri");
                });
#pragma warning restore 612, 618
        }
    }
}
