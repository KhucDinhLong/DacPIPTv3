using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAC.DAL
{
    [Table("SecAuthorizations")]
    public class SecAuthorizations
    {
        [Key]
        public Guid AuthorizationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MethodFullName { get; set; }
        public int? ModuleID { get; set; }
    }
}
