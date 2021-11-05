using MVCPratice.Common._Models;
using MVCPratice.Web.Service._Service;
using System.Collections.Generic;
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

        #region 新增
        public ActionResult CreatePage()
        {
            return View();
        }

        public ActionResult Create(EmployeeBase CreateMember)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                var taskResult = this._EmployeeBaseWebService.Create(CreateMember);

                if (!taskResult.IsFaulted)
                {
                    result = taskResult.Result;
                }
                else
                {
                    result = null;
                }


            }
            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 驗證帳號
        public JsonResult IsAllowAccountFromJS(string ID)
        {
            var result = new List<EmployeeBase>();
            var search = new SearchModel();
            search.Type = "equal";
            search.ID = ID;
            var taskResult = this._EmployeeBaseWebService.GetData(search);

            if (!taskResult.IsFaulted)
            {
                result = taskResult.Result;
            }
            //else
            //{
            //    result = ;
            //}
            //允許的話，回傳true
            if (result.Count == 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}