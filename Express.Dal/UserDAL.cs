﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:User
	/// </summary>
	public partial class UserDAL
    {
		public UserDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,36)			};
			parameters[0].Value = UserId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Express.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User(");
			strSql.Append("UserId,Name,Phone,Address,WechatId,Remark)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@Name,@Phone,@Address,@WechatId,@Remark)");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,36),
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Phone", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@WechatId", SqlDbType.VarChar,36),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Address;
			parameters[4].Value = model.WechatId;
			parameters[5].Value = model.Remark;

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
		public bool Update(Express.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Address=@Address,");
			strSql.Append("WechatId=@WechatId,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@Phone", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@WechatId", SqlDbType.VarChar,36),
					new SqlParameter("@Remark", SqlDbType.NVarChar,200),
					new SqlParameter("@UserId", SqlDbType.VarChar,36)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Phone;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.WechatId;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.UserId;

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
		public bool Delete(string UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User ");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,36)			};
			parameters[0].Value = UserId;

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
		public bool DeleteList(string UserIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User ");
			strSql.Append(" where UserId in ("+UserIdlist + ")  ");
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
		public Express.Model.User GetModel(string UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserId,Name,Phone,Address,WechatId,Remark from User ");
			strSql.Append(" where UserId=@UserId ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.VarChar,36)			};
			parameters[0].Value = UserId;

			Express.Model.User model=new Express.Model.User();
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
		public Express.Model.User DataRowToModel(DataRow row)
		{
			Express.Model.User model=new Express.Model.User();
			if (row != null)
			{
				if(row["UserId"]!=null)
				{
					model.UserId=row["UserId"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone= row["Phone"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["WechatId"]!=null)
				{
					model.WechatId=row["WechatId"].ToString();
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
			strSql.Append("select UserId,Name,Phone,Address,WechatId,Remark ");
			strSql.Append(" FROM User ");
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
			strSql.Append(" UserId,Name,Phone,Address,WechatId,Remark ");
			strSql.Append(" FROM User ");
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
			strSql.Append("select count(1) FROM User ");
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
				strSql.Append("order by T.UserId desc");
			}
			strSql.Append(")AS Row, T.*  from User T ");
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
			parameters[0].Value = "User";
			parameters[1].Value = "UserId";
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

