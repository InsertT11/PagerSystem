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
    public class PapersLib
    {
        public DataTable GetPapers(int papersId)
        {
            string sql = "select PapersId,UserId,Text,Title,Keyword,Flow,State,Code from Papers where PapersId=@papersId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@papersId",papersId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select PapersId,UserId,Text,Title,Keyword,Flow,State,StateCode from Papers where StateCode=1";    //-----------
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(int userId, string text, string title, string keyword, int flow, int state, int stateCode)
        {
            string sql = "insert into Users(UserId,Text,Title,Keyword,Flow,State,StateCode) values(@userId,@text,@title,@keyword,@flow,@state,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@userId",userId),
                new SqlParameter("@text",text),
                new SqlParameter("@title",title),
                new SqlParameter("@keyword",keyword),
                new SqlParameter("@flow",flow),
                new SqlParameter("@state",state)
                //new SqlParameter("@stateCode",stateCode)  ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int papersId)
        {
            string sql = "Update Papers Set StateCode = 2 where papersId=@papersId";    //-----------
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@papersId",papersId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
