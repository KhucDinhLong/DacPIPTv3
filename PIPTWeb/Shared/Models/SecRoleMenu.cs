using System.ComponentModel.DataAnnotations;

namespace PIPTWeb.Shared.Models
{
    public class SecRoleMenu
    {
        [Key]
        public int ID { get; set; }
        public string RoleID { get; set; }
        public int MenuID { get; set; }
    }
}
