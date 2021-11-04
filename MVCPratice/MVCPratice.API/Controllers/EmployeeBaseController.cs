using MVCPratice.API.Service._DataAccess;
using MVCPratice.Common._Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCPratice.API.Controllers
{
    [RoutePrefix("EmployeeBase")]
    public class EmployeeBaseController : Controller
    {
        #region 宣告DBService
        private readonly EmployeeBaseDBService ES = new EmployeeBaseDBService();
        #endregion

        #region 查詢
        [Route("GetData")]
        [HttpPost]
        public string GetData(SearchModel searchModel)
        {
            List<EmployeeBase> result = new List<EmployeeBase>();
            result = ES.GetData(searchModel);

            return JsonConvert.SerializeObject(result);
        }
        #endregion

    }
}