using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLN1.Models
{
    public class StaffViTri
    {
        [Key]
        public string ViTriStaffID { get; set; }
        public string VitriStaff { get; set; }
    }
}