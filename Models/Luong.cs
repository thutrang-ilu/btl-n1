using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLN1.Models
{
    public class Luong
    {
        [Key]
        public string LuongID { get ; set ;}
        public string SoLuong { get; set; }

    }
}