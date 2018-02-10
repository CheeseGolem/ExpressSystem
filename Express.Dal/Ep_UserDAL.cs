using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Express.DBUtility;//Please add references
namespace Express.DAL
{
	/// <summary>
	/// 数据访问类:Ep_UserDAL
	/// </summary>
	public partial class Ep_UserDAL
	{
		public Ep_UserDAL()
		{}
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ep_User");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Express.Model.Ep_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ep_User(");
            strSql.Append("Name,Phone,Address,NickName,OpenId,HeadImage,CreateTime,Remark)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Phone,@Address,@NickName,@OpenId,@HeadImage,@CreateTime,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@Phone", SqlDbType.VarChar,15),
                    new SqlParameter("@Address", SqlDbType.NVarChar,50),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,50),
                    new SqlParameter("@OpenId", SqlDbType.VarChar,50),
                    new SqlParameter("@HeadImage", SqlDbType.VarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime,3),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Address;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.OpenId;
            parameters[5].Value = model.HeadImage;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.Remark;

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
        public bool Update(Express.Model.Ep_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ep_User set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Address=@Address,");
            strSql.Append("NickName=@NickName,");
            strSql.Append("OpenId=@OpenId,");
            strSql.Append("HeadImage=@HeadImage,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.NVarChar,20),
                    new SqlParameter("@Phone", SqlDbType.VarChar,15),
                    new SqlParameter("@Address", SqlDbType.NVarChar,50),
                    new SqlParameter("@NickName", SqlDbType.NVarChar,50),
                    new SqlParameter("@OpenId", SqlDbType.VarChar,50),
                    new SqlParameter("@HeadImage", SqlDbType.VarChar,200),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime,3),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Address;
            parameters[3].Value = model.NickName;
            parameters[4].Value = model.OpenId;
            parameters[5].Value = model.HeadImage;
            parameters[6].Value = model.CreateTime;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.UserId;

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
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_User ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserId;

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
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ep_User ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
        public Express.Model.Ep_User GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,Name,Phone,Address,NickName,OpenId,HeadImage,CreateTime,Remark from Ep_User ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserId;

            Express.Model.Ep_User model = new Express.Model.Ep_User();
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
        public Express.Model.Ep_User DataRowToModel(DataRow row)
        {
            Express.Model.Ep_User model = new Express.Model.Ep_User();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["OpenId"] != null)
                {
                    model.OpenId = row["OpenId"].ToString();
                }
                if (row["HeadImage"] != null)
                {
                    model.HeadImage = row["HeadImage"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select UserId,Name,Phone,Address,NickName,OpenId,HeadImage,CreateTime,Remark ");
            strSql.Append(" FROM Ep_User ");
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
            strSql.Append(" UserId,Name,Phone,Address,NickName,OpenId,HeadImage,CreateTime,Remark ");
            strSql.Append(" FROM Ep_User ");
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
            strSql.Append("select count(1) FROM Ep_User ");
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
                strSql.Append("order by T.UserId desc");
            }
            strSql.Append(")AS Row, T.*  from Ep_User T ");
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
			parameters[0].Value = "Ep_User";
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

