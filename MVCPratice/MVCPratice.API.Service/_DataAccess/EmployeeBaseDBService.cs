using Dapper;
using MVCPratice.Common._Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

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
                                    ID LIKE '%' + @ID + '%'";

                    parameters.Add("@ID", searchModel.ID);
                }

                var result = conn.Query<EmployeeBase>(strSql, parameters).ToList();

                return result;
            }
        }
        #endregion

        #region 新增
        public string Create(EmployeeBase CreateMember)
        {
            try
            {
                using (var conn = new SqlConnection(cnstr))
                {
                    conn.Open();
                    string strSql = @"  INSERT INTO
                                            EmployeeBase (
                                                ID,
                                                Name,
                                                Sex,
                                                Address
                                            )
                                        VALUES
                                            (
                                                @ID,
                                                @Name,
                                                @Sex,
                                                @Address
                                            )";

                    var result = conn.Execute(strSql, CreateMember);

                    return "新增成功";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        #endregion

        #region 刪除
        public string Delete(string ID)
        {
            try
            {
                using (var conn = new SqlConnection(cnstr))
                {
                    conn.Open();
                    string strSql = @"  DELETE FROM
                                            EmployeeBase
                                        WHERE
                                            ID = @ID";

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ID", ID);

                    var result = conn.Execute(strSql, parameters);

                    return "刪除成功";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
                throw;
            }
        }
        #endregion
    }
}
