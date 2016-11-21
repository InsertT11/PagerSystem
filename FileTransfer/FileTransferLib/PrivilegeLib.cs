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
    public class PrivilegeLib
    {
        public DataTable GetPrivilege(int privilegeId)
        {
            string sql = "select PrivilegeId,Name,Point,PrivilegeCode,RoleId,StateCode from Privilege where PrivilegeId=@privilegeId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@privilegeId",privilegeId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select PrivilegeId,Name,Point,PrivilegeCode,RoleId,StateCode from Privilege where StateCode=1";   //----- where StateCode=1
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(string name, int point, int privilegeCode, int roleId, int stateCode)
        {
            string sql = "insert into Privilege(Name,Point,PrivilegeCode,RoleId) values(@name,@point,@privilegeCode,@roleId,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@name",name),
                new SqlParameter("@point",point),
                new SqlParameter("@privilegeCode",privilegeCode),
                new SqlParameter("@roleId",roleId)
                //new SqlParameter("@stateCode",stateCode)  ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int privilegeId)
        {
            string sql = "Update Privilege Set StateCode = 2 where PrivilegeId=@privilegeId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@privilegeId",privilegeId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
