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
    public class RoleLib
    {
        public DataTable GetRole(int roleId)
        {
            string sql = "select RoleId,Name,Description,StateCode from Role where RoleId=@roleId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@roleId",roleId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select RoleId,Name,Description,StateCode from Role where StateCode=1";    
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(string name, string description, int stateCode)
        {
            string sql = "insert into Role(Name,Description,StateCode) values(@name,@description,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@name",name),
                new SqlParameter("@description",description),
                //new SqlParameter("1",stateCode)
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int roleId)
        {
            string sql = "Update Role Set StateCode = 2 where RoleId=@roleId";   
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@roleId",roleId)
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
