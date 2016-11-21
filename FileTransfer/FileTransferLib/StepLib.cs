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
    public class StepLib
    {
        public DataTable GetStep(int stepId)
        {
            string sql = "select StepId,PapersId,Description,StepType,CheckBusinessUnitId,Flow,StateCode from Step where StepId=@stepId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@stepId",stepId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            return dt;
        }
        public DataTable GetList()
        {
            string sql = "select StepId,PapersId,Description,StepType,CheckBusinessUnitId,Flow,StateCode from Step where StateCode=1"; //------
            DataTable dt = BaseDAL.DBHelper.GetList(sql);
            return dt;
        }
        public bool Insert(int papersId, string description, int stepType, int checkBusinessUnitId, int flow, int stateCode)
        {
            string sql = "insert into Step(PapersId,Description,StepType,CheckBusinessUnitId,Flow,StateCode) values(@papersId,@description,@stepType,@checkBusinessUnitId,@flow,1) ";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@papersId",papersId),
                new SqlParameter("@description",description),
                new SqlParameter("@stepType",stepType),
                new SqlParameter("@checkBusinessUnitId",checkBusinessUnitId),
                new SqlParameter("@flow",flow)
                //new SqlParameter("@stateCode",stateCode)  ,
            };

            if (BaseDAL.DBHelper.Insert(sql, para) > 0)
                return true;
            else
                return false;
        }
        public bool Disabled(int stepId)
        {
            string sql = "Update Step Set StateCode = 2 where StepId=@stepId";
            SqlParameter[] para = new SqlParameter[] 
            { 
                new SqlParameter("@stepId",stepId),
            };
            DataTable dt = BaseDAL.DBHelper.GetList(sql, para);
            if (BaseDAL.DBHelper.Update(sql, para) > 0)
                return true;
            else
                return false;
        }
    }
}
