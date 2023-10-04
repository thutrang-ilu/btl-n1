using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BTLN1.Models
{
    public class AccountViTri
    {
        [Key]
        public string ViTriAccountID { get; set; }
        public string VitriAccount { get; set; }
    }
}