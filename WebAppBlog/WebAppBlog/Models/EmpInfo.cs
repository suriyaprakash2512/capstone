using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBlog.Models
{
    [Table("EmpInfo")]
    public class EmpInfo
    {
        [Key]
        public int EmpId { get; set; }
        public string? EmailId { get; set; }

        public string? Name { get; set; }

        public DateTime DOJ { get; set; }

        public int PassCode { get; set; }

    }
}
