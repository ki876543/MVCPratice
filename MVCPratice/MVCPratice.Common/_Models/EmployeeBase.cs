using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPratice.Common._Models
{
    /// <summary>
    /// 表格EmployeeBase的DataModel
    /// </summary>
    public partial class EmployeeBase
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 員工性別
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 員工住址
        /// </summary>
        public string Address { get; set; }
    }
}
