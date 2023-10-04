using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLN1.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountViTri",
                columns: table => new
                {
                    ViTriAccountID = table.Column<string>(type: "TEXT", nullable: false),
                    VitriAccount = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountViTri", x => x.ViTriAccountID);
                });

            migrationBuilder.CreateTable(
                name: "CeoViTri",
                columns: table => new
                {
                    ViTriCeoID = table.Column<string>(type: "TEXT", nullable: false),
                    VitriCeo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeoViTri", x => x.ViTriCeoID);
                });

            migrationBuilder.CreateTable(
                name: "CongNhan",
                columns: table => new
                {
                    MaCongNhan = table.Column<string>(type: "TEXT", nullable: false),
                    PhongBan = table.Column<string>(type: "TEXT", nullable: false),
                    ViTri = table.Column<string>(type: "TEXT", nullable: true),
                    Luong = table.Column<string>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongNhan", x => x.MaCongNhan);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    HopDongID = table.Column<string>(type: "TEXT", nullable: false),
                    TimeHopDong = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.HopDongID);
                });

            migrationBuilder.CreateTable(
                name: "Luong",
                columns: table => new
                {
                    LuongID = table.Column<string>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luong", x => x.LuongID);
                });

            migrationBuilder.CreateTable(
                name: "SaleViTri",
                columns: table => new
                {
                    ViTriSaleID = table.Column<string>(type: "TEXT", nullable: false),
                    VitriSale = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleViTri", x => x.ViTriSaleID);
                });

            migrationBuilder.CreateTable(
                name: "StaffViTri",
                columns: table => new
                {
                    ViTriStaffID = table.Column<string>(type: "TEXT", nullable: false),
                    VitriStaff = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffViTri", x => x.ViTriStaffID);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "TEXT", nullable: false),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    AccountPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AccountAddress = table.Column<string>(type: "TEXT", nullable: false),
                    AccountBirth = table.Column<string>(type: "TEXT", nullable: false),
                    AccountSex = table.Column<string>(type: "TEXT", nullable: false),
                    AccountBank = table.Column<string>(type: "TEXT", nullable: false),
                    AccountCCCD = table.Column<string>(type: "TEXT", nullable: false),
                    ViTriAccountID = table.Column<string>(type: "TEXT", nullable: false),
                    LuongID = table.Column<string>(type: "TEXT", nullable: false),
                    HopDongID = table.Column<string>(type: "TEXT", nullable: false),
                    AccountStart = table.Column<string>(type: "TEXT", nullable: false),
                    AccountEnd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_AccountViTri_ViTriAccountID",
                        column: x => x.ViTriAccountID,
                        principalTable: "AccountViTri",
                        principalColumn: "ViTriAccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_HopDong_HopDongID",
                        column: x => x.HopDongID,
                        principalTable: "HopDong",
                        principalColumn: "HopDongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Account_Luong_LuongID",
                        column: x => x.LuongID,
                        principalTable: "Luong",
                        principalColumn: "LuongID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ceo",
                columns: table => new
                {
                    CeoID = table.Column<string>(type: "TEXT", nullable: false),
                    CeoName = table.Column<string>(type: "TEXT", nullable: false),
                    CeoPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CeoAddress = table.Column<string>(type: "TEXT", nullable: false),
                    CeoBirth = table.Column<string>(type: "TEXT", nullable: false),
                    CeoSex = table.Column<string>(type: "TEXT", nullable: false),
                    CeoBank = table.Column<string>(type: "TEXT", nullable: false),
                    CeoCCCD = table.Column<string>(type: "TEXT", nullable: false),
                    ViTriCeoID = table.Column<string>(type: "TEXT", nullable: false),
                    LuongID = table.Column<string>(type: "TEXT", nullable: false),
                    HopDongID = table.Column<string>(type: "TEXT", nullable: false),
                    CeoStart = table.Column<string>(type: "TEXT", nullable: false),
                    CeoEnd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceo", x => x.CeoID);
                    table.ForeignKey(
                        name: "FK_Ceo_CeoViTri_ViTriCeoID",
                        column: x => x.ViTriCeoID,
                        principalTable: "CeoViTri",
                        principalColumn: "ViTriCeoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ceo_HopDong_HopDongID",
                        column: x => x.HopDongID,
                        principalTable: "HopDong",
                        principalColumn: "HopDongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ceo_Luong_LuongID",
                        column: x => x.LuongID,
                        principalTable: "Luong",
                        principalColumn: "LuongID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleID = table.Column<string>(type: "TEXT", nullable: false),
                    SaleName = table.Column<string>(type: "TEXT", nullable: false),
                    SalePhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SaleAddress = table.Column<string>(type: "TEXT", nullable: false),
                    SaleBirth = table.Column<string>(type: "TEXT", nullable: false),
                    SaleSex = table.Column<string>(type: "TEXT", nullable: false),
                    SaleBank = table.Column<string>(type: "TEXT", nullable: false),
                    SaleCCCD = table.Column<string>(type: "TEXT", nullable: false),
                    ViTriSaleID = table.Column<string>(type: "TEXT", nullable: false),
                    LuongID = table.Column<string>(type: "TEXT", nullable: false),
                    HopDongID = table.Column<string>(type: "TEXT", nullable: false),
                    SaleStart = table.Column<string>(type: "TEXT", nullable: false),
                    SaleEnd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sale_HopDong_HopDongID",
                        column: x => x.HopDongID,
                        principalTable: "HopDong",
                        principalColumn: "HopDongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Luong_LuongID",
                        column: x => x.LuongID,
                        principalTable: "Luong",
                        principalColumn: "LuongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_SaleViTri_ViTriSaleID",
                        column: x => x.ViTriSaleID,
                        principalTable: "SaleViTri",
                        principalColumn: "ViTriSaleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<string>(type: "TEXT", nullable: false),
                    StaffName = table.Column<string>(type: "TEXT", nullable: false),
                    StaffPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    StaffAddress = table.Column<string>(type: "TEXT", nullable: false),
                    StaffBirth = table.Column<string>(type: "TEXT", nullable: false),
                    StaffSex = table.Column<string>(type: "TEXT", nullable: false),
                    StaffBank = table.Column<string>(type: "TEXT", nullable: false),
                    StaffCCCD = table.Column<string>(type: "TEXT", nullable: false),
                    ViTriStaffID = table.Column<string>(type: "TEXT", nullable: false),
                    LuongID = table.Column<string>(type: "TEXT", nullable: false),
                    HopDongID = table.Column<string>(type: "TEXT", nullable: false),
                    StaffStart = table.Column<string>(type: "TEXT", nullable: false),
                    StaffEnd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_HopDong_HopDongID",
                        column: x => x.HopDongID,
                        principalTable: "HopDong",
                        principalColumn: "HopDongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_Luong_LuongID",
                        column: x => x.LuongID,
                        principalTable: "Luong",
                        principalColumn: "LuongID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staff_StaffViTri_ViTriStaffID",
                        column: x => x.ViTriStaffID,
                        principalTable: "StaffViTri",
                        principalColumn: "ViTriStaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_HopDongID",
                table: "Account",
                column: "HopDongID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_LuongID",
                table: "Account",
                column: "LuongID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ViTriAccountID",
                table: "Account",
                column: "ViTriAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Ceo_HopDongID",
                table: "Ceo",
                column: "HopDongID");

            migrationBuilder.CreateIndex(
                name: "IX_Ceo_LuongID",
                table: "Ceo",
                column: "LuongID");

            migrationBuilder.CreateIndex(
                name: "IX_Ceo_ViTriCeoID",
                table: "Ceo",
                column: "ViTriCeoID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_HopDongID",
                table: "Sale",
                column: "HopDongID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_LuongID",
                table: "Sale",
                column: "LuongID");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ViTriSaleID",
                table: "Sale",
                column: "ViTriSaleID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_HopDongID",
                table: "Staff",
                column: "HopDongID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_LuongID",
                table: "Staff",
                column: "LuongID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ViTriStaffID",
                table: "Staff",
                column: "ViTriStaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Ceo");

            migrationBuilder.DropTable(
                name: "CongNhan");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "AccountViTri");

            migrationBuilder.DropTable(
                name: "CeoViTri");

            migrationBuilder.DropTable(
                name: "SaleViTri");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "Luong");

            migrationBuilder.DropTable(
                name: "StaffViTri");
        }
    }
}
