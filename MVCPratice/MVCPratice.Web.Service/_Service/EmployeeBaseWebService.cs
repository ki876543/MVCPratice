using MVCPratice.Common._Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //EmployeeBase EmployeeBase= null;
            HttpResponseMessage Response = await this._EmployeeBase.PostAsync("EmployeeBase/GetData", stringContent).ConfigureAwait(false);

            if (Response.IsSuccessStatusCode)
            {
                string responsestream = await Response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<EmployeeBase>>(responsestream);

                return result;
            }

            return new List<EmployeeBase>();
        }
        #endregion
    }
}
