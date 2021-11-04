using Dapper;
using MVCPratice.Common._Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPratice.API.Service._DataAccess
{
    public class EmployeeBaseDBService
    {
        #region 建立與資料庫的連線字串
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["EmployeeBase"].ConnectionString;
        #endregion

        #region 查詢
        public List<EmployeeBase> GetData(SearchModel searchModel)
        {
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();

                string strSql;
                DynamicParameters parameters = new DynamicParameters();

                if (string.IsNullOrEmpty(searchModel.ID))
                {
                    strSql = @" SELECT
                                    *
                                FROM
                                    EmployeeBase";
                }
                else if (searchModel.Type == "equal")
                {
                    strSql = @" SELECT
                                    *
                                FROM
                                    EmployeeBase
                                WHERE
                                    ID = @ID";

                    parameters.Add("@ID", searchModel.ID);
                }
                else
                {
                    strSql = @" SELECT
                                    *
                                FROM
                                    EmployeeBase
                                WHERE
                                    ID LIKE '%' + @ID % '%'";

                    parameters.Add("@ID", searchModel.ID);
                }

                var result = conn.Query<EmployeeBase>(strSql, parameters).ToList();

                return result;
            }
        }
        #endregion
    }
}
