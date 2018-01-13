using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:Express
	/// </summary>
	public partial class ExpressDAL
	{
		public ExpressDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Express");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.Express model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Express(");
			strSql.Append("ID,ExpressId,UserId,Sender,SendPhone,Status,Remark)");
			strSql.Append(" values (");
			strSql.Append("@ID,@ExpressId,@UserId,@Sender,@SendPhone,@Status,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36),
					new SqlParameter("@ExpressId", SqlDbType.VarChar,36),
					new SqlParameter("@UserId", SqlDbType.VarChar,36),
					new SqlParameter("@Sender", SqlDbType.NVarChar,20),
					new SqlParameter("@SendPhone", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ExpressId;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.Sender;
			parameters[4].Value = model.SendPhone;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.Remark;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Express.Model.Express model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Express set ");
			strSql.Append("ExpressId=@ExpressId,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Sender=@Sender,");
			strSql.Append("SendPhone=@SendPhone,");
			strSql.Append("Status=@Status,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ExpressId", SqlDbType.VarChar,36),
					new SqlParameter("@UserId", SqlDbType.VarChar,36),
					new SqlParameter("@Sender", SqlDbType.NVarChar,20),
					new SqlParameter("@SendPhone", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,200),
					new SqlParameter("@ID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.ExpressId;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.Sender;
			parameters[3].Value = model.SendPhone;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Express ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Express ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Express.Model.Express GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ExpressId,UserId,Sender,SendPhone,Status,Remark from Express ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36)			};
			parameters[0].Value = ID;

			Express.Model.Express model=new Express.Model.Express();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Express.Model.Express DataRowToModel(DataRow row)
		{
			Express.Model.Express model=new Express.Model.Express();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["ExpressId"]!=null)
				{
					model.ExpressId=row["ExpressId"].ToString();
				}
				if(row["UserId"]!=null)
				{
					model.UserId=row["UserId"].ToString();
				}
				if(row["Sender"]!=null)
				{
					model.Sender=row["Sender"].ToString();
				}
				if(row["SendPhone"]!=null)
				{
					model.SendPhone= row["SendPhone"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ExpressId,UserId,Sender,SendPhone,Status,Remark ");
			strSql.Append(" FROM Express ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,ExpressId,UserId,Sender,SendPhone,Status,Remark ");
			strSql.Append(" FROM Express ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Express ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Express T ");
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
			parameters[0].Value = "Express";
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

