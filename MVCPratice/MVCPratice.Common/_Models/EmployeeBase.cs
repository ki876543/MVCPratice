using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCPratice.Common._Models
{
    public class EmployeeBase
    {
        [DisplayName("員工編號")]
        [Required(ErrorMessage = "請輸入{0}")]
        [StringLength(10, ErrorMessage = "{0}不可超過10字元")]
        public string ID { get; set; }

        [DisplayName("員工姓名")]
        [Required(ErrorMessage = "請輸入{0}")]
        [StringLength(10, ErrorMessage = "{0}不可超過10字元")]
        public string Name { get; set; }

        [DisplayName("員工性別")]
        [Required(ErrorMessage = "請輸入{0}")]
        public string Sex { get; set; }

        [DisplayName("員工住址")]
        [Required(ErrorMessage = "請輸入{0}")]
        [StringLength(50, ErrorMessage = "{0}不可超過50字元")]
        public string Address { get; set; }
    }
}
