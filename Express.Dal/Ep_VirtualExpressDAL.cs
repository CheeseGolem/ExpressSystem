using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;

namespace Express.DAL
{
    /// <summary>
    /// 数据访问类:VirtualExpressDAL
    /// </summary>
    public partial class VirtualExpressDAL
    {
        public VirtualExpressDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VirtualExpress");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.VirtualExpress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VirtualExpress(");
            strSql.Append("ExpressCode,ReceivedName,ReceivedPhone,SendName,SendPhone,Address,Info)");
            strSql.Append(" values (");
            strSql.Append("@ExpressCode,@ReceivedName,@ReceivedPhone,@SendName,@SendPhone,@Address,@Info)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ExpressCode", SqlDbType.VarChar,20),
                    new SqlParameter("@ReceivedName", SqlDbType.NChar,10),
                    new SqlParameter("@ReceivedPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@SendName", SqlDbType.NChar,10),
                    new SqlParameter("@SendPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@Address", SqlDbType.NVarChar,50),
                    new SqlParameter("@Info", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.ExpressCode;
            parameters[1].Value = model.ReceivedName;
            parameters[2].Value = model.ReceivedPhone;
            parameters[3].Value = model.SendName;
            parameters[4].Value = model.SendPhone;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.Info;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Express.Model.VirtualExpress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VirtualExpress set ");
            strSql.Append("ExpressCode=@ExpressCode,");
            strSql.Append("ReceivedName=@ReceivedName,");
            strSql.Append("ReceivedPhone=@ReceivedPhone,");
            strSql.Append("SendName=@SendName,");
            strSql.Append("SendPhone=@SendPhone,");
            strSql.Append("Address=@Address,");
            strSql.Append("Info=@Info");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ExpressCode", SqlDbType.VarChar,20),
                    new SqlParameter("@ReceivedName", SqlDbType.NChar,10),
                    new SqlParameter("@ReceivedPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@SendName", SqlDbType.NChar,10),
                    new SqlParameter("@SendPhone", SqlDbType.VarChar,20),
                    new SqlParameter("@Address", SqlDbType.NVarChar,50),
                    new SqlParameter("@Info", SqlDbType.NVarChar,500),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ExpressCode;
            parameters[1].Value = model.ReceivedName;
            parameters[2].Value = model.ReceivedPhone;
            parameters[3].Value = model.SendName;
            parameters[4].Value = model.SendPhone;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.Info;
            parameters[7].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VirtualExpress ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VirtualExpress ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.VirtualExpress GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ExpressCode,ReceivedName,ReceivedPhone,SendName,SendPhone,Address,Info from VirtualExpress ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;

            Express.Model.VirtualExpress model = new Express.Model.VirtualExpress();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Express.Model.VirtualExpress DataRowToModel(DataRow row)
        {
            Express.Model.VirtualExpress model = new Express.Model.VirtualExpress();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ExpressCode"] != null)
                {
                    model.ExpressCode = row["ExpressCode"].ToString();
                }
                if (row["ReceivedName"] != null)
                {
                    model.ReceivedName = row["ReceivedName"].ToString();
                }
                if (row["ReceivedPhone"] != null)
                {
                    model.ReceivedPhone = row["ReceivedPhone"].ToString();
                }
                if (row["SendName"] != null)
                {
                    model.SendName = row["SendName"].ToString();
                }
                if (row["SendPhone"] != null)
                {
                    model.SendPhone = row["SendPhone"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Info"] != null)
                {
                    model.Info = row["Info"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ExpressCode,ReceivedName,ReceivedPhone,SendName,SendPhone,Address,Info ");
            strSql.Append(" FROM VirtualExpress ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,ExpressCode,ReceivedName,ReceivedPhone,SendName,SendPhone,Address,Info ");
            strSql.Append(" FROM VirtualExpress ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM VirtualExpress ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from VirtualExpress T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "VirtualExpress";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

