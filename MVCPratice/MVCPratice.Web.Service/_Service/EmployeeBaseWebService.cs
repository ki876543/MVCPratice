using MVCPratice.Common._Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVCPratice.Web.Service._Service
{
    public class EmployeeBaseWebService
    {
        #region 宣告API
        private HttpClient _EmployeeBase;
        public EmployeeBaseWebService()
        {
            this._EmployeeBase = new HttpClient() { BaseAddress = new Uri("https://localhost:44319/") };
        }
        #endregion

        #region 查詢
        public async Task<List<EmployeeBase>> GetData(SearchModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._EmployeeBase.PostAsync("EmployeeBase/GetData", stringContent).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<List<EmployeeBase>>().Result;

                return result;
            }

            return new List<EmployeeBase>();
        }
        #endregion

        #region 新增
        public async Task<string> Create(EmployeeBase model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this._EmployeeBase.PostAsync("EmployeeBase/Create", stringContent).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<string>().Result;

                return result;
            }
            return "";
        }
        #endregion

        #region 刪除
        public async Task<string> Delete(SearchModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await this._EmployeeBase.PostAsync("EmployeeBase/Delete", stringContent).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<string>().Result;

                return result;
            }

            return "";
        }
        #endregion
    }
}
