using Edward.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferLib
{
    public class BusinessUnitLib
    {
        public DataTable GetBusinessUnit(int businessUnitId)
        {
            string sql = "select BusinessUnitId,Name,Description,StateCode from BusinessUnit where BusinessUnitId=@businessUnitId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@businessUnitId",businessUnitId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select BusinessUnitId,,Name,Description,StateCode from BusinessUnit where StateCode=1";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(string name, string description, int statecode)
        {
            string sql = "insert into BusinessUnit(Name,Description,StateCode) values(@Name,@Description,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@Name",name),
                new SqlParameter("@Description",description)
                //new SqlParameter("@StateCode",statecode)  ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int businessUnitId)
        {
            string sql = "Update BusinessUnit Set StateCode = 2 where BusinessUnitId=@businessUnitId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@BusinessUnitId",businessUnitId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
