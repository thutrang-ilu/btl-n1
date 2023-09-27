using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLN1.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage ="ID không được bỏ trống")]
        public string AccountID{ get; set; }
        [Required(ErrorMessage ="Họ Và Tên không được bỏ trống")]
        [Display(Name = "Họ và tên")]
        public string AccountName { get; set; }
        [Required(ErrorMessage =" SĐT Không được bỏ trống")]
        [Display(Name = "SĐT")]
        public string AccountPhoneNumber{ get; set; }
        [Required(ErrorMessage =" Địa chỉ Không được bỏ trống")]
        [Display(Name = "Địa chỉ")]
        public string AccountAddress{ get; set; }
        [Display(Name = "Ngày Sinh")]
        public string AccountBirth{ get; set; }
        [Display(Name = "Giới tính")]
        public string AccountSex{ get; set; }
        [Required(ErrorMessage =" Tài khoản Ngân hàng Không được bỏ trống")]
        [Display(Name = "TK Ngân hàng BIDV")]
        public string AccountBank{ get; set; }
        [Required(ErrorMessage =" Số Căn Cước Không được bỏ trống")]
        [Display(Name ="Số Căn Cước")]
        public string AccountCCCD { get; set; }
        public string ViTriAccountID { get; set; }
        [ForeignKey("ViTriAccountID")]
        [Display(Name = "Vị Trí")]
        public AccountViTri? AccountViTri { get; set; }
        public string LuongID { get; set; }
        [ForeignKey("LuongID")]
        [Display(Name = "Lương")]
        public Luong? Luong { get; set; }
        public string HopDongID { get; set; }
        [ForeignKey("HopDongID")]
        [Display(Name = "Hợp đồng")]
        public HopDong? HopDong { get; set; }
        [Display(Name = "Ngày làm")]
        public string AccountStart{ get; set; }
        [Display(Name = "Ngày hết hợp đồng")]
        public string AccountEnd{ get; set; }
    }
}