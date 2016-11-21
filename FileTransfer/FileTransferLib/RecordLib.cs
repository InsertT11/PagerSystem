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
    public class RecordLib
    {
        public DataTable GetRecord(int recordId)
        {
            string sql = "select RecordId,PapersId,SignIn,Attachment,SentMappingId,StateCode from Record where RecordId=@recordId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@recordId",recordId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select RecordId,PapersId,SignIn,Attachment,SentMappingId,StateCode from Record where StateCode=1";  
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(int papersId, int signIn, string attachment, int sentMappingId, int stateCode)
        {
            string sql = "insert into Users(PapersId,SignIn,Attachment,SentMappingId,StateCode) values(@papersId,@signIn,@attachment,@sentMappingId,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@papersId",papersId),
                new SqlParameter("@signIn",signIn),
                new SqlParameter("@attachment",attachment),
                new SqlParameter("@sentMappingId",sentMappingId)
                //new SqlParameter("@stateCode",stateCode)  ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int recordId)
        {
            string sql = "Update Record Set StateCode = 2 where RecordId=@recordId";   
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@recordId",recordId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
