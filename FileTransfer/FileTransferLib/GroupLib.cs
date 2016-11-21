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
    public class GroupLib
    {
        public DataTable GetGroup(int groupId)
        {
            string sql = "select GroupId,Name,StateCode from Groups where GroupId=@groupId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@groupId",groupId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select GroupId,Name from Groups where StateCode=1";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(string name, int stateCode)
        {
            string sql = "insert into Groups values(@name,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@name",name)
                //new SqlParameter("@stateCode",stateCode)  ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int groupId)
        {
            string sql = "Update Groups Set StateCode = 2 where GroupId=@groupId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@groupId",groupId)
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
