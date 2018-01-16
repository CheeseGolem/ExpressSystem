using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:Ep_AdminDAL
	/// </summary>
	public partial class Ep_AdminDAL
	{
		public Ep_AdminDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserId", "Ep_Admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Ep_Admin");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Express.Model.Ep_Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Ep_Admin(");
			strSql.Append("Username,Password,RealName,Phone,UserType,Status,CreateDate)");
			strSql.Append(" values (");
			strSql.Append("@Username,@Password,@RealName,@Phone,@UserType,@Status,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@Password", SqlDbType.Char,32),
					new SqlParameter("@RealName", SqlDbType.NVarChar,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,15),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
			parameters[0].Value = model.Username;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.UserType;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CreateDate;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Express.Model.Ep_Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Ep_Admin set ");
			strSql.Append("Username=@Username,");
			strSql.Append("Password=@Password,");
			strSql.Append("RealName=@RealName,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.VarChar,16),
					new SqlParameter("@Password", SqlDbType.Char,32),
					new SqlParameter("@RealName", SqlDbType.NVarChar,10),
					new SqlParameter("@Phone", SqlDbType.VarChar,15),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
			parameters[0].Value = model.Username;
			parameters[1].Value = model.Password;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.UserType;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.CreateDate;
			parameters[7].Value = model.UserId;

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
		public bool Delete(int UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Ep_Admin ");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
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
			strSql.Append("delete from Ep_Admin ");
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
		public Express.Model.Ep_Admin GetModel(int UserId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate from Ep_Admin ");
			strSql.Append(" where UserId=@UserId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
			parameters[0].Value = UserId;

			Express.Model.Ep_Admin model=new Express.Model.Ep_Admin();
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
		public Express.Model.Ep_Admin DataRowToModel(DataRow row)
		{
			Express.Model.Ep_Admin model=new Express.Model.Ep_Admin();
			if (row != null)
			{
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["Username"]!=null)
				{
					model.Username=row["Username"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
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
			strSql.Append("select UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate ");
			strSql.Append(" FROM Ep_Admin ");
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
			strSql.Append(" UserId,Username,Password,RealName,Phone,UserType,Status,CreateDate ");
			strSql.Append(" FROM Ep_Admin ");
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
			strSql.Append("select count(1) FROM Ep_Admin ");
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
			strSql.Append(")AS Row, T.*  from Ep_Admin T ");
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
			parameters[0].Value = "Ep_Admin";
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
        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public object isExistsUsername(string username, int userId)
        {
            string sql = "select COUNT(*) from Ep_Admin where UserId=@UserId and Username=@Username";

            SqlParameter[] ps =
            {
                new SqlParameter("@Username",username),
                new SqlParameter("@UserId",userId),
            };

            return DbHelperSQL.GetSingle(sql, ps);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户对象</param>
        /// <param name="isUpdatePassword">是否修改密码</param>
        /// <returns></returns>
        public bool Update(Express.Model.Ep_Admin model, bool isUpdatePassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update Ep_Admin set ");
            strSql.Append("Username=@Username,");
            if (isUpdatePassword)
            {
                strSql.Append("Password=@Password,");//判断是否修改密码
            }
            strSql.Append("RealName=@RealName,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("Status=@Status,");
            strSql.Append("where UserId=@UserId");

            //两个数组
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username",SqlDbType.VarChar,16),
                new SqlParameter("@RealName",SqlDbType.NVarChar,10),
                new SqlParameter("@Phone",SqlDbType.VarChar,15),
                new SqlParameter("@UserType",SqlDbType.TinyInt,1),
                new SqlParameter("@Status",SqlDbType.TinyInt,1),
                new SqlParameter("@UserId",SqlDbType.Int,4)
            };
            parameters[0].Value = model.Username;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.UserType;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.UserId;

            SqlParameter[] newPs = null;
            if (isUpdatePassword)
            {
                newPs = new SqlParameter[parameters.Length + 1];
                newPs.CopyTo(parameters, 0);
                newPs[newPs.Length - 1] = new SqlParameter("@Password", SqlDbType.Char, 32);
                newPs[newPs.Length - 1].Value = model.Password;
            }

            //返回受影响的行数
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), isUpdatePassword ? newPs : parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}

