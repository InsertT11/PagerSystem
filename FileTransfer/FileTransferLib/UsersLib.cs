using System.Data;
using Edward.DAL;
using System.Data.SqlClient;
namespace FileTransferLib
{
    public class Users
    {
        public DataTable GetUser(int userId)
        {
            string sql = "select UserId,Occupation,Name,Username,Password,BusinessUnitId,SeatingOrder,StateCode from where UserId=@userId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@userId",userId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql,para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select UserId,Occupation,Name,Username,Password,BusinessUnitId,SeatingOrder,StateCode from Users where StateCode=1";
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(string occipation,string name,string username,string password,string businessUnitId,string seatingorder)
        {
            string sql = "insert into Users(Occupation,Name,Username,Password,BusinessUnitId,SeatingOrder,StateCode) values(@occupation,@name,@username,@password,@businessUnitId,@seatingOrder,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@occupation",occipation),
                new SqlParameter("@name",name),
                new SqlParameter("@username",username),
                new SqlParameter("@password",password),
                new SqlParameter("@businessUnitId",businessUnitId),
                new SqlParameter("@seatingOrder",seatingorder)
                //new SqlParameter("@BusinessUnitId",businessUnitId)    ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int userId)
        {
            string sql = "Update Users Set StateCode = 2 where UserId=@userId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@userId",userId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
