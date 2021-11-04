using MVCPratice.Common._Models;
using MVCPratice.Web.Service._Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPratice.Web.Controllers
{
    public class EmployeeBaseController : Controller
    {
        #region 宣告WebService
        private EmployeeBaseWebService _EmployeeBaseWebService;
        public EmployeeBaseController()
        {
            this._EmployeeBaseWebService = new EmployeeBaseWebService();
        }
        #endregion


        #region 初始畫面，查詢
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetData(SearchModel searchModel = null)
        {
            var result = new List<EmployeeBase>();
            var taskResult = this._EmployeeBaseWebService.GetData(searchModel);
            if (!taskResult.IsFaulted)
            {
                result = taskResult.Result;
            }
            else
            {
                result = new List<EmployeeBase>();
            }

            return PartialView("_DataTable", result);
        }
        #endregion
    }
}