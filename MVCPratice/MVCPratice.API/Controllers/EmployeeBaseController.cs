using MVCPratice.API.Service._DataAccess;
using MVCPratice.Common._Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace MVCPratice.API.Controllers
{
    [RoutePrefix("EmployeeBase")]
    public class EmployeeBaseController : ApiController
    {
        #region 宣告DBService
        private readonly EmployeeBaseDBService ES = new EmployeeBaseDBService();
        #endregion

        #region 查詢
        [Route("GetData")]
        [HttpPost]
        public List<EmployeeBase> GetData(SearchModel searchModel)
        {
            var result = ES.GetData(searchModel);

            return result;
        }
        #endregion

        #region 新增
        [Route("Create")]
        public string Create([FromBody] EmployeeBase employeeBase)
        {
            var result = ES.Create(employeeBase);

            return result;
        }
        #endregion

        #region 刪除
        [Route("Delete")]
        [HttpPost]
        public string Delete([FromBody] SearchModel searchModel)
        {
            var result = ES.Delete(searchModel.ID);

            return result;
        }
        #endregion
    }
}