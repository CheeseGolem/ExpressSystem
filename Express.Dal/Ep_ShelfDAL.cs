using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:Ep_ShelfDAL
	/// </summary>
	public partial class Ep_ShelfDAL
	{
        public Ep_ShelfDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ep_Shelf");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.Ep_Shelf model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ep_Shelf(");
            strSql.Append("Shelf,Location,Type,Remark,CreateTime,UpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@Shelf,@Location,@Type,@Remark,@CreateTime,@UpdateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Shelf", SqlDbType.VarChar,2),
                    new SqlParameter("@Location", SqlDbType.VarChar,2),
                    new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Shelf;
            parameters[1].Value = model.Location;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.UpdateTime;

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
        public bool Update(Express.Model.Ep_Shelf model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ep_Shelf set ");
            strSql.Append("Shelf=@Shelf,");
            strSql.Append("Location=@Location,");
            strSql.Append("Type=@Type,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UpdateTime=@UpdateTime");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@Shelf", SqlDbType.VarChar,2),
                    new SqlParameter("@Location", SqlDbType.VarChar,2),
                    new SqlParameter("@Type", SqlDbType.Int,4),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@SId", SqlDbType.Int,4)};
            parameters[0].Value = model.Shelf;
            parameters[1].Value = model.Location;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.SId;

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
        public bool Delete(int SId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_Shelf ");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;

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
        public bool DeleteList(string SIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_Shelf ");
            strSql.Append(" where SId in (" + SIdlist + ")  ");
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
        public Express.Model.Ep_Shelf GetModel(int SId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SId,Shelf,Location,Type,Remark,CreateTime,UpdateTime from Ep_Shelf ");
            strSql.Append(" where SId=@SId");
            SqlParameter[] parameters = {
                    new SqlParameter("@SId", SqlDbType.Int,4)
            };
            parameters[0].Value = SId;

            Express.Model.Ep_Shelf model = new Express.Model.Ep_Shelf();
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
        public Express.Model.Ep_Shelf DataRowToModel(DataRow row)
        {
            Express.Model.Ep_Shelf model = new Express.Model.Ep_Shelf();
            if (row != null)
            {
                if (row["SId"] != null && row["SId"].ToString() != "")
                {
                    model.SId = int.Parse(row["SId"].ToString());
                }
                if (row["Shelf"] != null)
                {
                    model.Shelf = row["Shelf"].ToString();
                }
                if (row["Location"] != null)
                {
                    model.Location = row["Location"].ToString();
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = int.Parse(row["Type"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
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
            strSql.Append("select SId,Shelf,Location,Type,Remark,CreateTime,UpdateTime ");
            strSql.Append(" FROM Ep_Shelf ");
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
            strSql.Append(" SId,Shelf,Location,Type,Remark,CreateTime,UpdateTime ");
            strSql.Append(" FROM Ep_Shelf ");
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
            strSql.Append("select count(1) FROM Ep_Shelf ");
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
                strSql.Append("order by T.SId desc");
            }
            strSql.Append(")AS Row, T.*  from Ep_Shelf T ");
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
			parameters[0].Value = "Ep_Shelf";
			parameters[1].Value = "SId";
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
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

